using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace wedding_planner.Models
{
    public class Event : BaseEntity
    {
        [Key]
        public int EventId {get; set;}
        public string WedderOne {get; set;}
        public string WedderTwo { get; set; }
        public DateTime Event_Date { get; set; }
        public string Address { get; set; }
        public int Creator_Id {get;set;}
        public User Creator {get; set;}
        public List<Guests> Guests {get; set;}

        public Event()
        {
            Guests = new List<Guests>();
        }
    }

    
    public class EventViewModel
    {
        [Required (ErrorMessage = "You must enter a Wedder One")]
        [MinLength(2, ErrorMessage = "The name must be at least two charcters")]
        [Display(Name = "Wedder One")]
        public string WedderOne { get; set; }
        [Required (ErrorMessage = "You must enter a Wedder One")]
        [MinLength(2, ErrorMessage = "The name must be at least two charcters")]
        [Display(Name = "Wedder Two")]
        public string WedderTwo { get; set; }
        [Required(ErrorMessage = "You must enter a Wedding Date")]
        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Event_Date { get; set; }
        [Required(ErrorMessage = "You must enter a Wedding Address")]
        [MinLength(6, ErrorMessage = "The address must be more than six charcters")]
        public string Address { get; set; }
    }
}