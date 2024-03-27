using ConsultationBack.dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using timsoft.entities;
using timsoft.services;

namespace timsoft.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(UserForm userForm)
        {

            User dbuser = new User();
            dbuser = _userService.AddUser(userForm);

            return Ok(dbuser);

        }

        [HttpGet]
        [Route("GetAllUser")]
        public ActionResult<List<User>> GetAllUser()
        {
            return Ok(_userService.getAllUser());
        }


        [HttpDelete]
        [Route("DeleteUser")]
        public ActionResult DeleteUser(int id)
        {
            var isDeleted = _userService.DeleteUser(id);
            if(isDeleted) return Ok(new { message = "user deleted sucsessfully" });

            return NotFound(new { message = "user not found !" });
        }

        [HttpPut]
        [Route("UpdateUser")]
        public ActionResult UpdateUser(UserForm user, int id)
        {
            var isUpdated = _userService.UpdateUser(user, id);

            if(isUpdated) return Ok(new { message = "user updated sucsessfully" });

            return NotFound(new { message = "user not found !" });
        }

        [HttpGet]
        [Route("GetUserById")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if(user!=null) return Ok(user);

            return NotFound(new { message = "User Not Found !" });
        }


        [HttpPost]
        [Route("Login")]
        public ActionResult Login([FromBody] SignIn signIn)
        {
            if (_userService.SignIn(signIn) == "wrong password")
            {

                return BadRequest(new
                {
                    message = "wrong password"
                });
            }
            if (_userService.SignIn(signIn) == "wrong userName")
            {

                return BadRequest(new
                {
                    message = "wrong userName"
                });
            }


            return Ok(new
            {
                token = _userService.SignIn(signIn),
                message = "Login successed !!"
            });

        }

    }
}
