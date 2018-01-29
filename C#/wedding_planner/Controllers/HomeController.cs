using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using wedding_planner.Models;
using wedding_planner.ActionFilters; 
using System.Linq;
using System.Net.Http;

namespace wedding_planner.Controllers
{
    public class HomeController : Controller
    {
        private UserContext _context;
        public HomeController(UserContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("/")]
        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Index", "LogReg");
            } else {
                List<Event> allEvents = _context.Event.Include(u => u.Guests).ToList();
                ViewBag.theEvents = allEvents;
                ViewBag.currentUser =(int) HttpContext.Session.GetInt32("UserId");
                return View();
            }
        }
        [HttpGet]
        [Route("createForm")]
        public IActionResult CreateForm()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Index", "LogReg");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [Route("create")]
        public IActionResult CreateEvent(EventViewModel submittedModel)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Index", "LogReg");
            }
            else
            {
                if(!ModelState.IsValid)
                {
                    return RedirectToAction("CreateForm");
                } else {
                    Event newEvent = new Event{
                        WedderOne = submittedModel.WedderOne,
                        WedderTwo = submittedModel.WedderTwo,
                        Event_Date = submittedModel.Event_Date,
                        Address = submittedModel.Address,
                        Creator_Id = (int)HttpContext.Session.GetInt32("UserId")
                    };
                    _context.Event.Add(newEvent);
                    _context.SaveChanges();
                    return RedirectToAction("Dashboard");
                }
            }
        }
        [HttpPost]
        [Route("RSVP")]
        public IActionResult RSVPEvent(int eventId)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Index", "LogReg");
            }
            else
            {
                int? currentUserId = HttpContext.Session.GetInt32("UserId");
                Event selectedEvent = _context.Event.SingleOrDefault(e => e.EventId == eventId);
                User currentUser = _context.User.SingleOrDefault(u =>u.UserId == (int)currentUserId);
                Guests newGuest = new Guests
                {
                    Wedding = selectedEvent,
                    user = currentUser
                };
                _context.Add(newGuest);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
        }
        [HttpPost]
        [Route("UN-RSVP")]
        public IActionResult UNRSVPEvent(int eventId)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Index", "LogReg");
            }
            else
            {
                int? currentUserId = HttpContext.Session.GetInt32("UserId");
                Guests currentGuest = _context.Guests.Where(w => w.WeddingId == eventId).Where(u => u.UserId == (int)currentUserId).SingleOrDefault();
                _context.Remove(currentGuest);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
        }
        [HttpGet]
        [Route("display/{eventId}")]
        public IActionResult Display(int eventId)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Index", "LogReg");
            }
            else
            {
                Event selectedEvent = _context.Event.Where(w => w.EventId == (int)eventId).Include(u => u.Guests).ThenInclude(g => g.user).SingleOrDefault();
                if(selectedEvent == null){
                    return RedirectToAction("Dashboard");
                } else {
                    ViewBag.Event = selectedEvent;
                    return View();
                }
            }
        }
        [HttpPost]
        [Route("delete")]
        public IActionResult DeleteEvent(int eventId)
        {
            Event selectedEvent = _context.Event.SingleOrDefault(e => e.EventId == eventId);
            _context.Event.Remove(selectedEvent);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }
}