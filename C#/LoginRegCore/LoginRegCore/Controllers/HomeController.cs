using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginRegCore.Models;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace LoginRegCore.Controllers
{
    public class HomeController : Controller
    {
        private AppContext _context;
        public HomeController(AppContext context)
        {
            _context = context;
        }


        private bool CheckLogStatus()
        {
            int? id = HttpContext.Session.GetInt32("UserID");
            if (id == null)
            {
                TempData["UserError"] = "You must be logged in!";
                return false;
            }
            else
            {
                return true;
            }
        }


        [Route("logout")]
        public ActionResult LogOut()
        {
            try
            {
                HttpContext.Session.Clear();
                return RedirectToAction("GetLogin");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

            public IActionResult Index()
        {
            if (CheckLogStatus() == true)
            {
                return RedirectToAction("NoteRender", "Notes");
            }
            //var users = _context.Users.FromSql("sp_allusers").ToList();
            //List<User> usrs = _context.Users.ToList();

            return View();
        }

        [Route("/log_in")]
        public IActionResult GetLogin()
        {
            if(CheckLogStatus() == true)
            {
                return RedirectToAction("NoteRender", "Notes");
            }


            return View();
        }

        [HttpPost]
        [ActionName("register")]
        public IActionResult Register(Register reg)
        {
            if(reg == null)
            {
                return View(reg);
            }
            if (ModelState.IsValid)
            {
                try
                {
                    User exist = _context.Users.FromSql($"sp_IfExists {reg.Email}").SingleOrDefault();
                    if (exist != null)
                    {
                        ModelState.AddModelError("Email", "User already exists with given email");
                        return View("Index", reg);
                    }
                    if (reg.Password != reg.PasswordRep)
                    {
                        ModelState.AddModelError("Password", "Passwords should match");
                        return View("Index", reg);
                    }
                    byte[] salt;
                    new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

                    var pdkdf2 = new Rfc2898DeriveBytes(reg.Password, salt, 10000);
                    byte[] hash = pdkdf2.GetBytes(20);
                    byte[] hashBytes = new byte[36];

                    Array.Copy(salt, 0, hashBytes, 0, 16);
                    Array.Copy(hash, 0, hashBytes, 16, 20);

                    //PasswordHasher<Register> hasher = new PasswordHasher<Register>();
                    //string hashed = hasher.HashPassword(reg, reg.Password);

                    string savedHashPass = Convert.ToBase64String(hashBytes);


                    var newuser = _context.Users.FromSql("sp_CreateUser @p0, @p1, @p2, @p3",
                        parameters: new[] { reg.FirstName, reg.LastName, reg.Email, savedHashPass }).SingleOrDefault();


                    HttpContext.Session.SetInt32("UserID", newuser.UserID); //set userid to session

                    return RedirectToAction("NoteRender", "Notes");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    ViewData["Error"] = e.Message;
                    return View("Index");
                }
            }
            else
            {
                Console.WriteLine("Input Error");
                return View("Index", reg);
            }
        }


        [HttpPost]
        [ActionName("login")]
        public IActionResult Login(Login log)
        {
            if (log == null)
            {
                return View("GetLogin", log);
            }
            if (ModelState.IsValid)
            {
                try
                {
                    User exist = _context.Users.FromSql($"sp_IfExists {log.Email}").SingleOrDefault();
                    if (exist == null)
                    {
                        ModelState.AddModelError("Email", "User with given email do not exists");
                        return View("GetLogin", log);
                    }

                    byte[] hashbytes = Convert.FromBase64String(exist.Password);
                    byte[] salt = new byte[16];
                    Array.Copy(hashbytes, 0, salt, 0, 16);
                    var pbkdf2 = new Rfc2898DeriveBytes(log.Password, salt, 10000);
                    byte[] hash = pbkdf2.GetBytes(20);

                    int ok = 1;
                    for (int i = 0; i < 20; i++)
                    {
                        if (hashbytes[i + 16] != hash[i]) ok = 0;
                    }
                    if (ok == 1)
                    {
                        Console.WriteLine("Success");
                        HttpContext.Session.SetInt32("UserID", exist.UserID);
                        HttpContext.Session.SetString("FirstName", exist.FirstName);

                        return RedirectToAction("NoteRender", "Notes");
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    ViewData["Error"] = e.Message;
                    return View("GetLogin");
                }
                ModelState.AddModelError("Password", "Password invalid. Please try again");
                return View("GetLogin", log);

            }
            else
            {
                Console.WriteLine("Input Error");
                return View("GetLogin", log);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
