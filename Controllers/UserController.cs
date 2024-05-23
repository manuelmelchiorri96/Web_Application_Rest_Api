using Microsoft.AspNetCore.Mvc;
using Web_Application_Rest_Api.Model;
using Web_Application_Rest_Api.Model.Request;
using Web_Application_Rest_Api.Services;

namespace Web_Application_Rest_Api.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {

        private readonly IUserService _userService;

        public UserController(IUserService userService) {
            _userService = userService;
        }


        [HttpGet("all")]
        public IActionResult AllUsers() {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{idUser}")]
        public IActionResult GetUser(int idUser) {
            var user = _userService.GetUserById(idUser);

            if (user == null) {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserDto user) {
            var newUser = _userService.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { idUser = newUser.Id }, newUser);
        }

        [HttpPut("{idUser}")]
        public IActionResult UpdateUser(int idUser, [FromBody] UserDto user) {
            var updated = _userService.UpdateUser(idUser, user);

            if (!updated) {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{idUser}")]
        public IActionResult DeleteUser(int idUser) {
            var deleted = _userService.DeleteUser(idUser);

            if (!deleted) {
                return NotFound();
            }
            return NoContent();
        }
    }
}
