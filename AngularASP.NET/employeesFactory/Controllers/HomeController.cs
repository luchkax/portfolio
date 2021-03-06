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
        [Route("/addCompany")]
        public IActionResult AddCompany([FromBody] Company company)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Company newCompany = new Company
           {
               Address = company.Address,
               Name = company.Name,
           };
           _context.Add(newCompany);
           _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("/updateCompany")]
        public IActionResult UpdateCompany([FromBody] Company company)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Company thisCompany = _context.Companies.Where(c=>c.CompanyId == company.CompanyId).SingleOrDefault();
            thisCompany.Name = company.Name;
            thisCompany.Address = company.Address;

           _context.SaveChanges();
            return RedirectToAction("Index");
        }

        
        [HttpPost]
        [Route("/update_employee")]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Employee thisEmployee = _context.Employees.Where(c=>c.EmployeeId == employee.EmployeeId).SingleOrDefault();
            thisEmployee.FirstName = employee.FirstName;
            thisEmployee.Email = employee.Email;
            thisEmployee.CompanyId = employee.CompanyId;

           _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("/addEmployee")]
        public IActionResult AddEmployee([FromBody] Employee person)
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

        [HttpPost]
        [Route("/delete_company/{companyId}")]
        public string DeleteCompany(int companyId)
        {
            if(companyId != 0)
            {
                int id = Convert.ToInt32(companyId);
                var company = _context.Companies.Where(x=>x.CompanyId == id).FirstOrDefault();
                // if(company.Workers != null)
                // {
                    foreach(var x in company.Workers)
                    {
                        System.Console.WriteLine(x.FirstName + " =-----------------------");
                        x.CompanyId = null;
                    }
                // }
                _context.Companies.Remove(company);
                _context.SaveChanges();

                return "Company added!";
            }
            else
            {
                return "Oops! Error occered."; 
            }
        }
    }
}
