using System;
using System.ComponentModel.DataAnnotations;
namespace dojoBelt.Models
{
    public abstract class BaseEntity{};

    public class Register : BaseEntity
    {   
        [Key]
        public int UserId{get;set;}

        [Required]
        [MinLength(2)]
        public string FirstName{get;set;}

        [Required]
        [MinLength(2)]
        public string LastName{get;set;}

        [Required]
        [EmailAddress]
        public string Email{get;set;}

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password{get;set;}

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword{get;set;}


    }

    public class Login : BaseEntity
    {
        [Required]
        [EmailAddress]
        public string Email {get;set;}

        [Required]
        [MinLength(8, ErrorMessage="Passwords must be at least 8 characters")]
        [DataType(DataType.Password)]
        public string Password{get;set;}
    } 
    public class ActivityCheck : BaseEntity 
    {
        [Required]
        [MinLength(2,ErrorMessage="Title must be at least 2 characters")]
        public string Title {get;set;}   

        [Required]
        public double? ActivityTime {get;set;}

        [Required(ErrorMessage = "You must enter a Activity Date")]
        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ActivityDate {get;set;}

        [Required]
        public int? Duration {get;set;}

        [Required]
        [MinLength(10, ErrorMessage="Description must be more than 10 characters")]
        public string Description {get;set;}
    }


}
