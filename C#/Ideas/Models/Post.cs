using System;
using System.Collections.Generic;

namespace dojoTest.Models
{
    public class Post : BaseEntity
    {
        public int PostId {get;set;}
        public string Content{get;set;}
        public DateTime Created_At{get;set;}
        public int UserId{get;set;}
        public User Poster{get;set;}
        public List<Like> Likes{get;set;}
        public Post()
        {
            Likes = new List<Like>();
        }
    }
}