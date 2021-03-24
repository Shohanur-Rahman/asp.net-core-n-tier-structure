using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.VMModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPIApp.IServices;

namespace WPIApp.Controllers
{
    [Route("api/")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserServices _userService;
        public RegisterController(IUserServices userService)
        {
            _userService = userService;
        }

        // POST api/<UsersController>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] VMUserModel model)
        {
            return await _userService.SaveUpdateUser(model);
        }
    }
}
