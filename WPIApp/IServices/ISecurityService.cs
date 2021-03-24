using Microsoft.AspNetCore.Mvc;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WPIApp.IServices
{
    public interface ISecurityService
    {
        Task<JsonResult> Login(VMLogin login);
    }
}
