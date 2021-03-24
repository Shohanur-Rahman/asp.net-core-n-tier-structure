using Models.Models;
using Models.VMModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IUserBLLManager
    {
        Task<ResponseMessage> GetUsers();
        Task<ResponseMessage> SaveUser(VMUserModel model);
        Task<ResponseMessage> UpdateUser(VMUserModel model);
        Task<ResponseMessage> DeleteUser(long id);
        Task<ResponseMessage> GetUserById(long id);
    }
}
