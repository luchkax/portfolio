using System.ComponentModel.DataAnnotations;

namespace wall.Models
{
    public abstract class BaseEntity
    {
    }
    public class RegUser : BaseEntity
    {   
        [Required]
        [MinLength(2, ErrorMessage="First name must be at least 2 characters!")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage="First name can contain letters only")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage="Last name must be at least 2 characters!")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage="Last name can contain letters only")]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage="Passwords must match!")]
        public string confirmPassword {get;set;}

    }

    public class LoginUser : BaseEntity
    {
        [Required]
        [EmailAddress]
        
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class ViewModels
    {
        public RegUser Reg { get; set; }
        public LoginUser Log { get; set; }
    }
}   