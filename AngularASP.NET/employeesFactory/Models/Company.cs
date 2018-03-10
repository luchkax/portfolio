using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace employeesFactory.Models
{
    public class Company : BaseEntity
    {
        public int CompanyId{get;set;}
        public string Name{get;set;}
        public string Address{get;set;}
        public List <Employee> Workers { get; set; }
        public Company()
        {
            Workers = new List<Employee>();
        }

    }

    public class CompanyCheck : BaseEntity
    {
        public int CompanyId{get;set;}
        [Required]
        public string Name{get;set;}
        [Required]
        public string Address{get;set;}

    }
}