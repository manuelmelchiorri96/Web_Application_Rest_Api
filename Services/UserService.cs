using Web_Application_Rest_Api.Database;
using Web_Application_Rest_Api.Exceptions;
using Web_Application_Rest_Api.Model;
using Web_Application_Rest_Api.Model.Request;

namespace Web_Application_Rest_Api.Services {

    public class UserService : IUserService {

        private readonly DatabaseContext _context;

        public UserService(DatabaseContext context) {
            _context = context;
        }


        public IEnumerable<User> GetAllUsers() {
            var users = _context.Users.ToList();

            if (users.Count == 0) {
                throw new EmptyUserListException("Utenti non trovati.");
            }
            return users;
        }

        public User GetUserById(int id) {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null) {
                throw new UserNotFoundException($"Utente con id {id} non trovato.");
            }
            return user;
        }

        public User AddUser(UserDto userDto) {

            if (string.IsNullOrWhiteSpace(userDto.Name) || string.IsNullOrWhiteSpace(userDto.Email) || string.IsNullOrWhiteSpace(userDto.Password)) {
                throw new UserValidationException("I campi nome, email e password sono obbligatori.");
            }

            if (_context.Users.Any(u => u.Email == userDto.Email)) {
                throw new DuplicateUserException("Utente con questa e-mail già esistente.");
            }
           

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

            if (string.IsNullOrWhiteSpace(userDto.Name) || string.IsNullOrWhiteSpace(userDto.Email) || string.IsNullOrWhiteSpace(userDto.Password)) {
                throw new UserValidationException("I campi nome, email e password sono obbligatori.");
            }

            var userToUpdate = _context.Users.FirstOrDefault(x => x.Id == id);

            if (userToUpdate == null) {
                throw new UpdateUserFailedException($"Utente con {id} non trovato.");
            }

            userToUpdate.Name = userDto.Name;
            userToUpdate.Email = userDto.Email;
            userToUpdate.Password = userDto.Password;

            _context.SaveChanges();
            return true;
        }


        public bool DeleteUser(int id) {
            var userToDelete = _context.Users.FirstOrDefault(x => x.Id == id);

            if (userToDelete == null) {
                throw new DeleteUserFailedException($"Utente con id {id} non trovato.");
            }

            _context.Users.Remove(userToDelete);
            _context.SaveChanges();
            return true;
        }

    }
}
