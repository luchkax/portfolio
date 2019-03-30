using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LoginRegCore.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        private DateTime Date { get; set; }

    }


    public class Register  
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please enter the user's first name")]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter the user's last name")]
        [MinLength(2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter the user's email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string PasswordRep { get; set; }

        [Required]
        [MinLength(2)]
        private DateTime Date { get; set; }

    }

    public class Login
    {

        [Required(ErrorMessage = "Please enter correct user email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter correct user password")]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }


}
