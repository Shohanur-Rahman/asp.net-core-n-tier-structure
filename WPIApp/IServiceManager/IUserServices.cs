using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Models.VMModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WPIApp.IServiceManager
{
    public interface IUserServices
    {
        Task<JsonResult> GetUsers();
        Task<JsonResult> SaveUpdateUser(VMUserModel model);
        Task<JsonResult> DeleteUser(long id);
        Task<JsonResult> GetUserById(long id);
    }
}
