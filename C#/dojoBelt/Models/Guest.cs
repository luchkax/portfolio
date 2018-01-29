using System;
using System.Collections.Generic;

namespace dojoBelt.Models
{
    public class Guest : BaseEntity
    {
        public int GuestId{get;set;}
        public int ActivityId { get; set; }
        public Activity Activity{get; set;}
        public int UserId { get; set; }
        public User User {get;set;}


    }
}
