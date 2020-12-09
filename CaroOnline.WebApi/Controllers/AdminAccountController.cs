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
    [Route("api/admin")]
    [ApiController]
    public class AdminAccountController : ControllerBase
    {
        private readonly IAdminAccountService _adminService;


        public AdminAccountController(IAdminAccountService adminService)
        {
            _adminService = adminService;
        }



        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var user = _adminService.Authenticate(model.Username, model.Password);
            if (user == null)
                return Unauthorized();
            return Ok(user);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] RegisterAdminModel model)
        {
            var admin = _adminService.Create(model.Username, model.Password);
            if(admin == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            }
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
        
    }
}
