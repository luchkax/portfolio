using Microsoft.EntityFrameworkCore;

namespace wedding_planner.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options){}
        public DbSet<User> User {get; set;}
        public DbSet<Event> Event { get; set; }
        public DbSet<Guests> Guests {get;set;}
    }
}