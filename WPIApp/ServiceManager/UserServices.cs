using BLL.Interface;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Models.VMModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPIApp.IServiceManager;

namespace WPIApp.ServiceManager
{
    public class UserServices : IUserServices
    {
        private readonly IUserBLLManager _userBLL;
        public UserServices(IUserBLLManager userBLL)
        {
            _userBLL = userBLL;
        }
        public async Task<JsonResult> DeleteUser(long id)
        {
            var response =  await _userBLL.DeleteUser(id);
            return new JsonResult(response);
        }

        public async Task<JsonResult> GetUserById(long id)
        {
            var response = await _userBLL.GetUserById(id);
            return new JsonResult(response);
        }

        public async Task<JsonResult> GetUsers()
        {
            var response = await _userBLL.GetUsers();
            return new JsonResult(response);
        }

        public async Task<JsonResult> SaveUpdateUser(VMUserModel model)
        {
            var response = new ResponseMessage();
            if (model.Id > 0) {
                response = await _userBLL.UpdateUser(model);
            }
            else
            {
                response = await _userBLL.SaveUser(model);
            }
            return new JsonResult(response);
        }
    }
}
