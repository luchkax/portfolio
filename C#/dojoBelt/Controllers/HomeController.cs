using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using dojoBelt.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace dojoBelt.Controllers
{
    public class HomeController : Controller
    {
        private DojoContext _context;
        public HomeController(DojoContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/dashboard")]
        public IActionResult Dashboard()
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if(id == null)
            {
                return RedirectToAction("RegisterPage", "User");                           
            }
            else
            {   
                List<User> allUsers = _context.Users.Include(u => u.Activities).ThenInclude(g=>g.Guests).ToList();
                List<Activity> allActivities = _context.Activities.Include(g=>g.Guests).OrderBy(x => x.ActivityDate).ToList();
                Activity Activ = _context.Activities.Where(u=>u.UserId == id).FirstOrDefault();
                User userlog = _context.Users.Where(u=>u.UserId == id).SingleOrDefault();
                

                ViewBag.ALL = allUsers;
                ViewBag.ACT = allActivities;
                ViewBag.DateTimeNow = DateTime.Now;
                ViewBag.loggeduser = id;
                ViewBag.name = userlog.FirstName;
                System.Console.WriteLine(ViewBag.name);



                return View("Dashboard");
            }    
        }

        [HttpGet]
        [Route("/new")]
        public IActionResult NewActivityPage()
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if(id == null)
            {
                return RedirectToAction("RegisterPage", "User");                           
            }
            else
            {   
                return View("NewActivity");
            }    
        }

        [HttpPost]
        [Route("/newactivity")]
        public IActionResult CreateActivity(ActivityCheck check)
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if(id == null)
            {
                return RedirectToAction("RegisterPage", "User");                           
            }
            else
            {   
                if(ModelState.IsValid)
                {
                    if(check.ActivityDate > DateTime.Now)
                    {
                        Activity newActivity = new Activity
                        {
                            Title = check.Title,
                            ActivityTime = check.ActivityTime,
                            ActivityDate = check.ActivityDate,
                            Duration = check.Duration,
                            Description = check.Description,
                            UserId = (int)HttpContext.Session.GetInt32("userId")
                        };
                        _context.Activities.Add(newActivity);
                        _context.SaveChanges();
                        return RedirectToAction("ActivityPage", new{activityId = newActivity.ActivityId});
                    }
                    else
                    {
                        return View("NewActivity");
                    }
                }
                else
                {
                    return View("NewActivity");
                }
            }
        }

        [HttpGet]
        [Route("/activity/{activityId}")]
        public IActionResult ActivityPage(int activityId)
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if(id == null)
            {
                return RedirectToAction("RegisterPage", "User");                           
            }
            else
            {   
                
                Guest selecteddActivity = _context.Guests.Where(b=>b.ActivityId == 3).FirstOrDefault();


                List<Activity> allActivities = _context.Activities.Include(g=>g.Guests).ToList();
                Activity selectedActivity = _context.Activities.Where(e => e.ActivityId == activityId).Include(g=>g.Guests).ThenInclude(u=>u.User).SingleOrDefault();
                Activity activity = _context.Activities.Where(e => e.ActivityId == activityId).FirstOrDefault();
                User user = _context.Users.Where(u => u.UserId == activity.UserId).SingleOrDefault();                
                ViewBag.tr = user.FirstName; 
                ViewBag.creator = activity;
                ViewBag.count = selectedActivity.Guests;
                ViewBag.act = selectedActivity;
                
                return View("Activity");
            }    
        }

        [HttpGet]
        [Route("/join/{activityId}")]
        public IActionResult Join(int activityId)
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if(id == null)
            {
                return RedirectToAction("RegisterPage", "User");                           
            }
            else
            {
                Guest exists = _context.Guests.Where(b=>b.ActivityId == activityId).Include(o=>o.User).FirstOrDefault();
                // if(exists.UserId == id)
                // {
                //     return RedirectToAction("Dashboard");
                // }
                // else
                // {
                    Guest newGuest = new Guest
                    {
                        ActivityId = activityId,
                        UserId = (int)id
                    };
                    _context.Guests.Add(newGuest);
                    if(newGuest.UserId != exists.User.UserId)
                    {
                        _context.SaveChanges();
                        return RedirectToAction("ActivityPage", new{activityId = activityId});

                    }
                    else
                    {
                        return RedirectToAction("Dashboard");
                    }
                // }
            }
        }

        [HttpGet]
        [Route("/delete/{activityId}")]
        public IActionResult Remove(int activityId)
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if(id == null)
            {
                return RedirectToAction("RegisterPage", "User");                           
            }
            else
            {
                Activity selectedActivity = _context.Activities.Where(e => e.ActivityId == activityId).Include(g=>g.Guests).ThenInclude(u=>u.User).SingleOrDefault();
                _context.Activities.Remove(selectedActivity);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
        }

        [HttpGet]
        [Route("/leave/{activityId}")]
        public IActionResult Leave(int activityId)
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if(id == null)
            {
                return RedirectToAction("RegisterPage", "User");                           
            }
            else
            {
                Guest selectedActivity = _context.Guests.Where(b=>b.ActivityId == activityId).FirstOrDefault();
                _context.Guests.Remove(selectedActivity);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
        }




        






    }
}