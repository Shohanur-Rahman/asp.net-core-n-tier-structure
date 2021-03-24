using Microsoft.AspNetCore.Mvc;
using Models.VMModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPIApp.IServiceManager;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WPIApp.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userService;
        public UsersController(IUserServices userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet("all-users")]
        public async Task<IActionResult> Get()
        {
            return await _userService.GetUsers();
        }

        // GET api/<UsersController>/5
        [HttpGet("get-user")]
        public async Task<IActionResult> Get(long id)
        {
            return await _userService.GetUserById(id);
        }

        // POST api/<UsersController>
        [HttpPost("save-user")]
        public async Task<IActionResult> Post([FromBody] VMUserModel model)
        {
            return await _userService.SaveUpdateUser(model);
        }

        // PUT api/<UsersController>/5
        [HttpPost("update-user")]
        public async Task<IActionResult> Put([FromBody] VMUserModel model)
        {
            return await _userService.SaveUpdateUser(model);
        }

        // DELETE api/<UsersController>/5
        [HttpPost("delete-user")]
        public async Task<IActionResult> Delete(long id)
        {
            return await _userService.DeleteUser(id);
        }
    }
}
