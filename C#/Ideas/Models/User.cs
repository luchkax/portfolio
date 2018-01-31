using System;
using System.Collections.Generic;

namespace dojoTest.Models
{
    public class User : BaseEntity
    {   
    
        public int UserId{get;set;}
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public string Email{get;set;}
        public string Password{get;set;}
        public List<Post> Posts{get;set;}
        public List<Like> Likes{get;set;}
        public User()
        {
            Posts = new List<Post>();
            Likes = new List<Like>();
        }
        
    }
}