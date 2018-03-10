using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace employeesFactory.Models
{
    public class Employee : BaseEntity
    {
        public int EmployeeId{get;set;}
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public string Email{get;set;}
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

    }

    public class EmployeeCheck : BaseEntity
    {
        [Key]
        public int EmployeeId{get;set;}
        [Required]
        public string FirstName{get;set;}
        [Required]
        public string LastName{get;set;}
        [Required]
        public string Email{get;set;}
        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }


}