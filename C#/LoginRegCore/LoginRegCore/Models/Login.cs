using System;
using System.ComponentModel.DataAnnotations;

namespace LoginRegCore.Models
{
    public class Register
    {
        [Key]
        public int UserID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        //public string PasswordRep { get; set; }
    }
}
