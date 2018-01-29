using System;
using System.Collections.Generic;

namespace dojoBelt.Models
{
    public class Activity : BaseEntity
    {
        public int ActivityId {get;set;}
        public string Title {get;set;}   
        public double? ActivityTime {get;set;}
        public DateTime ActivityDate {get;set;}
        public int? Duration {get;set;}
        public string Description {get;set;}
        public int UserId{get;set;}
        public User Creator{get;set;}
        public List<Guest> Guests{get;set;}
        public Activity()
        {
            Guests = new List<Guest>();
        }

    }
}