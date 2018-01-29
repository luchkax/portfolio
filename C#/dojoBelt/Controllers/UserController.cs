using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using dojoBelt.Models;
using Microsoft.AspNetCore.Identity;

namespace dojoBelt.Controllers
{
    public class UserController : Controller
    {
        private DojoContext _context;
        public UserController(DojoContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult RegisterPage()
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if(id == null)
            {
                return View("Register");                           
            }
            else
            {   
                return RedirectToAction("Dashboard", "Home");
            }    
        }

        [HttpGet]
        [Route("login")]
        public IActionResult LoginPage()
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if(id == null)
            {
                return View("Login");                           
            }
            else
            {   
                return RedirectToAction("Dashboard", "Home");
            }    
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register (Register regUser)
        {   
            if(ModelState.IsValid)
            {
                User exists = _context.Users.SingleOrDefault(user=>user.Email == regUser.Email);
                if(exists !=null)
                {
                    ModelState.AddModelError("Email", "An account with this email already exists!");
                    return View("Register");
                }
                else
                {
                    PasswordHasher<Register> Hasher = new PasswordHasher<Register>();
                    string hashed = Hasher.HashPassword(regUser, regUser.Password);
                    User newUser = new User
                    {
                        FirstName = regUser.FirstName,
                        LastName = regUser.LastName,
                        Email = regUser.Email,  
                        Password = hashed
                    };
                    _context.Add(newUser);
                    _context.SaveChanges();
                    User user = _context.Users.Where(u=>u.Email == regUser.Email).SingleOrDefault();
                    HttpContext.Session.SetInt32("userId", user.UserId);
                    HttpContext.Session.SetString("userName", user.FirstName);

                    return RedirectToAction("Dashboard", "Home");
                }
            }
            else
            {
                return View("Register");
            }
        }

        [HttpPost]
        [Route("loginuser")]
        public IActionResult Login (Login loginUser)
        {   
            if(ModelState.IsValid)
            {
                User exists = _context.Users.Where(u=>u.Email == loginUser.Email).SingleOrDefault();
                if(exists == null)
                {
                    ModelState.AddModelError("Error", "Email not found");
                    return View("Login");
                } 
                else
                {
                    var hasher = new PasswordHasher<User>();
                    if(hasher.VerifyHashedPassword(exists, exists.Password, loginUser.Password) == 0)
                    {
                        ModelState.AddModelError("Password", "Password incorrect");
                        return View("Login");
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("userId", exists.UserId);
                        HttpContext.Session.SetString("userFirstName", exists.FirstName);
                        HttpContext.Session.SetString("userLastName", exists.LastName);
                        int? id = HttpContext.Session.GetInt32("userId");

                        return RedirectToAction("Dashboard", "Home");
                    }
                }
            }
            else
            {
                return View("Login");
            }
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginPage");
        }


    }
}