using Microsoft.EntityFrameworkCore;
using Web_Application_Rest_Api.Model;

namespace Web_Application_Rest_Api.Database
{
    public class DatabaseContext : DbContext {


        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base (options) {

        }

        public DbSet<User> Users { get; set; }

    }
}
