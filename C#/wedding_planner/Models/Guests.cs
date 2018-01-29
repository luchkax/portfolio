using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace wedding_planner.Models
{
    public class Guests : BaseEntity
    {
        [Key]
        public int EventId { get; set; }
        public int WeddingId { get; set; }
        public Event Wedding { get; set; }
        public int UserId { get; set; }
        public User user { get; set; }
    }
}

