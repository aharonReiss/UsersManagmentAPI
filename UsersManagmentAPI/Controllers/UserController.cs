using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using UsersManagmentAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsersManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddUser([FromBody] UserRequest userReq)
        {
            try
            {
                User user = new User() { Password = userReq.Password, UserName = userReq.UserName };
                var userId = await _userService.AddUserAsync(user);
                return Ok($"user created userid: {userId}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return Ok($"User Deleted userId {id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserRequest userReq)
        {
            try
            {
                User user = new User() { Password = userReq.Password, UserName = userReq.UserName };
                bool userAuthnticate = await _userService.ValidateUserAndPassword(user);
                if (userAuthnticate)
                    return Ok("User Authenticate");
                else
                    return Ok("UserName Or Password is wrong");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
