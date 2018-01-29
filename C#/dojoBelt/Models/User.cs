using System;
using System.Collections.Generic;

namespace dojoBelt.Models
{
    public class User : BaseEntity
    {   
    
        public int UserId{get;set;}
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public string Email{get;set;}
        public string Password{get;set;}
        public List<Activity> Activities{get;set;}
        public User()
        {
            Activities = new List<Activity>();
        }
        
    }
}