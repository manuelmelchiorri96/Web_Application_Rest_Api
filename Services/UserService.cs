using Web_Application_Rest_Api.Database;
using Web_Application_Rest_Api.Model;
using Web_Application_Rest_Api.Model.Request;

namespace Web_Application_Rest_Api.Services {

    public class UserService : IUserService {

        private readonly DatabaseContext _context;

        public UserService(DatabaseContext context) {
            _context = context;
        }


        public IEnumerable<User> GetAllUsers() {
            return _context.Users.ToList();
        }

        public User GetUserById(int id) {
            return _context.Users.FirstOrDefault(x => x.Id == id)!;
        }

        public User AddUser(UserDto userDto) {
            var newUser = new User {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }

        public bool UpdateUser(int id, UserDto userDto) {
            var userToUpdate = _context.Users.FirstOrDefault(x => x.Id == id);

            if (userToUpdate == null) return false;

            userToUpdate.Name = userDto.Name;
            userToUpdate.Email = userDto.Email;
            userToUpdate.Password = userDto.Password;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteUser(int id) {
            var userToDelete = _context.Users.FirstOrDefault(x => x.Id == id);

            if (userToDelete == null) return false;

            _context.Users.Remove(userToDelete);
            _context.SaveChanges();
            return true;
        }
    }
}
