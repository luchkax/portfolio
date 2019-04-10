using System;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Data.Entity.Core.Objects;
using LoginRegCore.Models;
using Microsoft.EntityFrameworkCore;



namespace LoginRegCore
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Note> Notes { get; set; }

    }
}