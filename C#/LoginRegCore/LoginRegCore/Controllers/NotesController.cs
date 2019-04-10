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
        [HttpPost]
        [ActionName("addnote")]
        public IActionResult AddNote(Note notes)
        {
            if (CheckLogStatus() == true && ModelState.IsValid)
            {
                try
                {
                    if (notes == null) return null;
                    int? id = HttpContext.Session.GetInt32("UserID");
                    var newnote = _context.Notes.FromSql(
                        $"sp_AddNote @p0, @p1, @p2",
                        parameters: new [] { notes.Title, notes.Content, id.ToString() }).ToList();

                    return RedirectToAction("NoteRender");

                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }

            return View("Notes", notes);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult DeleteNote(int id)
        {
            if (CheckLogStatus() == true && ModelState.IsValid)
            {
               var allnotes =  _context.Notes.FromSql($"sp_DeleteNote {id}").ToList();

                return RedirectToAction("NoteRender");
            }
            return View("Notes");
        }

        [HttpGet]
        [Route("add")]
        public IActionResult AddNotePartial()
        {
            if (CheckLogStatus() == true)
            {
                ViewBag.Render = "Add";
                return PartialView("RenderNoteID");
            }
            return View("Notes");
        }

        [HttpGet]
        [Route("asnotes")]
        public async Task<List<Note>> GetNote()
        {
            if (CheckLogStatus() == true && ModelState.IsValid)
            {
                int? id = HttpContext.Session.GetInt32("UserID");
                var notes = await _context.Notes.FromSql($"sp_getAllUSerNotes {id}").ToListAsync();

                if (notes == null)
                {
                    return null;
                }

                ViewBag.Note = notes;
                ViewBag.Render = "Display";
                return notes;
            }
            return null;
        }

        [HttpGet]
        [Route("notes/{id}")]
        public IActionResult NoteRenderID(int? id)
        {
            if (CheckLogStatus() == true && ModelState.IsValid)
            {
                var note = _context.Notes.FromSql($"sp_GetNote {id}").SingleOrDefault();
                var model = new Note { };

                ViewBag.Note = note;
                ViewBag.Render = "Display";
                //ViewBag.Render = "Add";
                return PartialView("RenderNoteID", model);
            }
            return View("Notes");
        }

        [HttpPost]
        [Route("/edit")]
        public IActionResult EditNote(int id, string title, string content)
        {
            if (CheckLogStatus() == true && ModelState.IsValid)
            {
                //var note = _context.Notes.FromSql($"sp_GetNote {id}").SingleOrDefault();
                if (title == null || content == null) return null;
                
                    var allnotes = _context.Notes.FromSql($"sp_UpdateNote @p0, @p1, @p2",
                        parameters: new[] { id.ToString(), title, content }).ToList();

                return null;
            }
            return View("Notes");
        }

        [Route("notes")]
        public IActionResult NoteRender()
        {
            if (CheckLogStatus() == true)
            {
                int? id = HttpContext.Session.GetInt32("UserID");
                User user = _context.Users.FromSql($"sp_IfSession {id}").SingleOrDefault();
                List<Note> userNotes = _context.Notes.FromSql($"sp_getAllUSerNotes {id}").ToList();

                ViewData["Message"] = "Welcome back " + user.FirstName;
                ViewBag.UserNotes = userNotes;

                return View("Notes");
            }


            return RedirectToAction("GetLogin", "Home")
;        }
    }
}
