using Microsoft.EntityFrameworkCore;
using Web_Application_Rest_Api.Model;

namespace Web_Application_Rest_Api.Database
{
    public class DatabaseContext : DbContext {


        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base (options) {

        }

        public DbSet<User> Users { get; set; }

        /*
        private static int GlobalId = 0;

        public DatabaseContext() {
            Users = new List<User>();

            IncrementGlobalIdAndAddUserId(new User { Name = "Mario", Email = "mario@gmail.com", Password = "password" });
            IncrementGlobalIdAndAddUserId(new User { Name = "Gianni", Email = "gianni@gmail.com", Password = "password" });
            IncrementGlobalIdAndAddUserId(new User { Name = "Andrea", Email = "andrea@gmail.com", Password = "password" });
        }

        public List<User> Users { get; set; }

        public void AddUser(User user) {
            IncrementGlobalIdAndAddUserId(user);
        }

        private void IncrementGlobalIdAndAddUserId(User user) {
            GlobalId++;
            user.Id = GlobalId;
            Users.Add(user);
        }
        */

    }
}
