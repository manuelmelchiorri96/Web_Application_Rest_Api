using Microsoft.AspNetCore.Mvc;
using Web_Application_Rest_Api.Exceptions;
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


        [HttpGet("{idUser}")]
        public IActionResult GetUser(int idUser) {
            try{
                var user = _userService.GetUserById(idUser);
                return Ok(user);
            }
            catch (UserNotFoundException ex) {
                return NotFound(ex.Message);
            }
            catch (Exception ex) {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("all")]
        public IActionResult AllUsers() {
            try {
                var users = _userService.GetAllUsers();
                return Ok(users);
            }
            catch (EmptyUserListException ex) {
                return NotFound(ex.Message);
            }
            catch (Exception) {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserDto user) {
            try{
                var newUser = _userService.AddUser(user);
                return CreatedAtAction(nameof(GetUser), new { idUser = newUser.Id }, newUser);
            }
            catch (DuplicateUserException ex) {
                return Conflict(ex.Message);
            }
            catch (UserValidationException ex) {
                return BadRequest(ex.Message);
            }
            catch (Exception ex) {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{idUser}")]
        public IActionResult UpdateUser(int idUser, [FromBody] UserDto user) {
            try {
                var updated = _userService.UpdateUser(idUser, user);
                if (!updated) {
                    return NotFound();
                }
                return NoContent();
            }
            catch (UpdateUserFailedException ex) {
                return NotFound(ex.Message);
            }
            catch (UserValidationException ex) {
                return BadRequest(ex.Message);
            }
            catch (Exception ex) {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{idUser}")]
        public IActionResult DeleteUser(int idUser) {
            try {
                var deleted = _userService.DeleteUser(idUser);
                if (!deleted) {
                    return NotFound();
                }
                return NoContent();
            }
            catch (DeleteUserFailedException ex) {
                return NotFound(ex.Message);
            }
            catch (Exception ex) {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
