using System;
using System.ComponentModel.DataAnnotations;

namespace restauranter.Models
{
    public class Reviews
    {
            [Key]
            public int ReviewId { get; set; }
            [Required]
            [MinLength(2)]
            public string Reviewer{ get; set; }
            
            [Required]
            [MinLength(5)]
            public string Content { get; set; }

            [Required]
            [MinLength(2)]
            public string Restaurant { get; set; }

            public int Rating { get; set; }

            [Required(ErrorMessage="Date field is required")]
            public DateTime? Date {get;set;}
    }

}