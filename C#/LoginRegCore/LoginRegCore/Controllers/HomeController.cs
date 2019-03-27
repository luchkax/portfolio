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

namespace LoginRegCore.Controllers
{
    public class HomeController : Controller
    {
        private BloggingContext _context;
        public HomeController(BloggingContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.Users.FromSql("sp_allusers").ToList();
            List<Register> user = _context.Users.ToList();

            return View();
        }

        [HttpPost]
        [ActionName("register")]
        public IActionResult Register(Register login)
        {
            if(login == null)
            {
                return RedirectToAction("Privacy");
            }
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pdkdf2 = new Rfc2898DeriveBytes(login.Password, salt, 10000);
            byte[] hash = pdkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string savedHashPass = Convert.ToBase64String(hashBytes);



            return RedirectToAction("Contact");
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
