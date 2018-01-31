using System;
using System.Collections.Generic;

namespace dojoTest.Models
{
    public class Like : BaseEntity
    {   
        public int LikeId{get;set;}
        public int UserId{get;set;}
        public User LikedBy{get;set;}
        public int PostId{get;set;}
        public Post Post{get;set;}
    }
}