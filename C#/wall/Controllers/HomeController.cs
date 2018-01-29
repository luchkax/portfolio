using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using wall.Models;

namespace wall.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnector _dbConnector;
 
        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("name") == null)
            {
                return View("Index");
            }
            else{
                return RedirectToAction("Success", "Main");
            }
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(ViewModels model)
        {
            if(ModelState.IsValid)
            {
                string checkEmail = $"SELECT * FROM users WHERE(email = '{model.Reg.Email}')";
                var exists = _dbConnector.Query(checkEmail);
                if(exists.Count > 0)
                {
                    ViewBag.email = "This email is already taken!";
                    return View("Index");
                }
                else
                {
                    string query = $"INSERT INTO users(first_name, last_name, email, password, created_at)VALUES('{model.Reg.FirstName}', '{model.Reg.LastName}', '{model.Reg.Email}', '{model.Reg.Password}', NOW());";
                    System.Console.WriteLine(query);
                    _dbConnector.Execute(query);
                    HttpContext.Session.SetString("user", model.Reg.FirstName);
                    var sessionQuery = _dbConnector.Query(checkEmail);
                    int sessionID = (int)sessionQuery[0]["id"];
                    return RedirectToAction("Success", "Main");
                }
            }
            else
            {
                return View("Index");
            }
        }

        // [HttpGet]
        // [Route("success")]
        // public IActionResult Success()
        // {
        //     string user = HttpContext.Session.GetString("user");
        //     ViewBag.user = user;
        //     return View();
        // }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(ViewModels model)
        {
            if(ModelState.IsValid)
            {
                string query = $"SELECT * FROM users WHERE(email = '{model.Log.Email}');";
                var exists = _dbConnector.Query(query);
                if(exists.Count == 0)
                {
                    ViewBag.email = "Email not found";
                    return View("Index");
                }
                else
                {
                    string pass = (exists[0]["password"]).ToString();
                    if(pass != model.Log.Password)
                    {
                        ViewBag.password = "Incorrect password!";
                        return View("Index");
                    }
                    else
                    {
                        int id = (int)exists[0]["id"];
                        HttpContext.Session.SetInt32("id", id);
                        TempData["id"] = HttpContext.Session.GetInt32("id");
                        string firstName = (exists[0]["first_name"]).ToString();
                        string lastName = (exists[0]["last_name"]).ToString();
                        string name = firstName + " " + lastName;
                        HttpContext.Session.SetString("name", name);
                        TempData["name"] = HttpContext.Session.GetString("name");

                        return RedirectToAction("Success", "Main");
                    }
                }
            }
            else
            {
                return View("Index");
            }
        }   
    }
}
