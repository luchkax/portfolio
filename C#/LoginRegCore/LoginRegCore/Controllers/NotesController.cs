using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginRegCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginRegCore.Controllers
{
    public class NotesController : Controller
    {
        private AppContext _context;
        public NotesController(AppContext context)
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
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NoteRender()
        {
            if (CheckLogStatus() == true)
            {
                int? id = HttpContext.Session.GetInt32("UserID");
                User user = _context.Users.FromSql($"sp_IfSession {id}").SingleOrDefault();
                Note userNotes = _context.Notes.FromSql($"sp_getAllUSerNotes {id}").SingleOrDefault();

                ViewData["Message"] = "Welcome back " + user.FirstName;

                return View("Notes");
            }


            return RedirectToAction("GetLogin", "Home")
;        }
    }
}
