using System;
//using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using LoginRegCore.Models;
using Microsoft.EntityFrameworkCore;



namespace LoginRegCore
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options) : base(options) { }

        public virtual DbSet<Register> Users { get; set; }


    }
}