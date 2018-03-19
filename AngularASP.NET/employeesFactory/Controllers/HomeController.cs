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
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            Employee newEmployee = new Employee
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                CompanyId = person.CompanyId
            };
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

        [HttpPost]
        [Route("/delete_employee/{employeeId}")]
        public string DeleteEmployee(int employeeId)
        {
            if(employeeId != 0)
            {
                int id = Convert.ToInt32(employeeId);
                var employee = _context.Employees.Where(x=>x.EmployeeId == id).FirstOrDefault();
                _context.Employees.Remove(employee);
                _context.SaveChanges();

                return "Employee added!";
            }
            else
            {
                return "Oops! Error occered."; 
            }
        }
    }
}
