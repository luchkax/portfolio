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
        [Route("/add")]
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


        [HttpGet]
        [Route("/add2")]
        public IActionResult Add()
        {
            Employee newEmployee = new Employee
           {
               FirstName = "Larry",
               LastName = "Page",
               Email = "larry@google.com",
               CompanyId = 1
           };
           _context.Add(newEmployee);
           _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // [HttpGet]
        // [Route("/api/companies")]
        // public IActionResult ShowAllCompanies()
        // {
        //     var companies =  _context.Companies.All(w => w.Include(t=>t.Workers)).ToList();
        //     return Ok(companies);
        // }


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
