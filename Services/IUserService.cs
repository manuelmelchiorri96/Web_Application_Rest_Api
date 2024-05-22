using Web_Application_Rest_Api.Model.Request;
using Web_Application_Rest_Api.Model;

namespace Web_Application_Rest_Api.Services {

    public interface IUserService {

        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        User AddUser(UserDTO userDto);
        bool UpdateUser(int id, UserDTO userDto);
        bool DeleteUser(int id);


    }
}
