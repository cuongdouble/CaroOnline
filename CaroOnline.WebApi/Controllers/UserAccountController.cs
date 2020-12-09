using CaroOnline.Data.Entities;
using CaroOnline.Services.Data.Repository;
using CaroOnline.WebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaroOnline.WebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService _userService;


        public UserAccountController(IUserAccountService userService)
        {
            _userService = userService;
        }



        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var user =  _userService.Authenticate(model.Username, model.Password);
            if (user == null)
                return Unauthorized();
            return Ok(user);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            var user = new User() { Username = model.Username, Firstname = model.Firstname, Lastname = model.Lastname };
            var result = _userService.Create(user, model.Password);
            if(result==null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            }
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
        
    }
}
