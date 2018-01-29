using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using wall.Models;

namespace wall.Controllers
{
    public class MainController : Controller
    {
        private readonly DbConnector _dbConnector;
 
        public MainController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        // GET: /Home/
        
        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {

            if(HttpContext.Session.GetString("name") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["id"] = HttpContext.Session.GetInt32("id");
                TempData["name"] = HttpContext.Session.GetString("name");
                return View("Success");
            }
        }

        [HttpGet]
        [Route("wall")]
        public IActionResult Wall()
        {

            if(HttpContext.Session.GetString("name") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["id"] = HttpContext.Session.GetInt32("id");
                TempData["name"] = HttpContext.Session.GetString("name");
                int id = (int)HttpContext.Session.GetInt32("id");
                string messageQuery = $"SELECT message, idmessage, messages.created_at, users.first_name, users.last_name FROM messages JOIN users ON messages.user_id WHERE (messages.user_id = users.id) ORDER BY messages.created_at DESC;";
                var messages = _dbConnector.Query(messageQuery);
                string commentQuery = $"SELECT comment, comments.created_at, users.first_name, users.last_name, comments.message_idmessage FROM comments JOIN users ON comments.user_id WHERE (comments.user_id = users.id) ORDER BY comments.created_at ASC;";
                var comments = _dbConnector.Query(commentQuery);
                ViewBag.messages = messages;
                ViewBag.comments = comments;
                return View("Wall");
            }
        }

        [HttpPost]
        [Route("mcreate")]
        public IActionResult CreateMessage(string message)
        {
            int? id = HttpContext.Session.GetInt32("id");
            if(HttpContext.Session.GetString("id") == null)
            {
                return RedirectToAction("Success");
            }
            else
            {
                if(message.Length > 0)
                {
                    int userID = (int)id;
                    string query = $"INSERT INTO messages (message, user_id, created_at) VALUES ('{message}', '{userID}', NOW());";
                    _dbConnector.Execute(query);
                    return RedirectToAction("Wall");
                }
                else
                {
                    return RedirectToAction("Success");
                }
            }
        }

        [HttpPost]
        [Route("ccreate")]
        public IActionResult CreateComment(string comment, int message_id)
        {
            int? id = HttpContext.Session.GetInt32("id");
            if(HttpContext.Session.GetString("id") == null)
            {
                return RedirectToAction("Success");
            }
            else
            {
                if(comment.Length > 0)
                {
                    int userID = (int)id;
                    // int messageID = (int)message_id;
                    string query = $"INSERT INTO comments (user_id, message_idmessage, comment, created_at) VALUES ({userID}, {message_id}, '{comment}', NOW());";
                    System.Console.WriteLine(query);
                    _dbConnector.Execute(query);
                    return RedirectToAction("Wall");
                }
                else
                {
                    return RedirectToAction("Success");
                }
            }
        }
    }
}