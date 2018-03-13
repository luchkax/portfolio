using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using employeesFactory.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace employeesFactory.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        public HomeController(MyContext context)
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
        [Route("/form")]
        public IActionResult Form()
        {
            
            return View("Form");
        }

        [HttpPost]
        [Route("/addCompany")]
        public IActionResult Index2()
        {
            Company newCompany = new Company
           {
               Address = "sdsadafdsfafas CA",
               Name = "asdasfjfdhfdsf",
           };
           _context.Add(newCompany);
           _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        [Route("/addEmployee")]
        public IActionResult Add([FromBody] Employee person)
        {
            System.Console.WriteLine("-----------------------------------------------"+person.FirstName);
            System.Console.WriteLine("-----------------------------------------------"+person.CompanyId);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           _context.Add(person);
           _context.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpGet] 
        [Route("/api/companies")]
        public async Task<List<Company>>  ShowAllCompanies()
        {
            return await _context.Companies.ToListAsync();
        }


        [HttpGet]
        [Route("/api/employees")]
        public async Task<IActionResult> ShowAllEmployees()
        {
            var result  = await _context.Employees.ToListAsync();
            return Json(result);
        }
    }
}
