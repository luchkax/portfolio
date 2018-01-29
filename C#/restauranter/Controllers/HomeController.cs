using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using restauranter.Models;
using System.Linq;

namespace restauranter.Controllers
{
    public class HomeController : Controller
    {
        private RestContext _context;
 
        public HomeController(RestContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("result")]
        public IActionResult Result()
        {
            List<Reviews> ReturnedValues = _context.Review.ToList();
            ViewBag.reviews = ReturnedValues;
            return View();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(Reviews review)
        {
            if(ModelState.IsValid)
            {
                _context.Add(review);
                _context.SaveChanges();
                return RedirectToAction("Result");
            }
            else
            {
                return View("Index");
            }
        }

    }
}
