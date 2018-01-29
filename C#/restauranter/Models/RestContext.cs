using Microsoft.EntityFrameworkCore;
 
namespace restauranter.Models
{
    public class RestContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public RestContext(DbContextOptions<RestContext> options) : base(options) { }
        //<Reviews> stands for Module , Review stands for table name of db
        public DbSet<Reviews> Review { get; set;}
    }
}
