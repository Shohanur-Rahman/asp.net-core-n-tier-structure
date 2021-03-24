using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPIApp.IServices;

namespace WPIApp.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        public LoginController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody] VMLogin login)
        {
            return await _securityService.Login(login);
        }
    }
}
