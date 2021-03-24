using BLL.Interface;
using Common.Constants;
using Common.Encription;
using Common.Enum;
using Common.Static;
using Microsoft.EntityFrameworkCore;
using Models.DB;
using Models.Models;
using Models.VMModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLLManager
{
    public class SecurityBLLManager: ISecurityBLLManager
    {
        private readonly ApplicationDbContext _dbContext;
        public SecurityBLLManager(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseMessage> Login(VMLogin login)
        {
            ResponseMessage result = new ResponseMessage();
            try
            {
                string encryptedPassword = SimpleCryptService.Factory().Encrypt(login.Password);

                var listOfUser = await _dbContext.Users.Where(x => x.Email == login.UserID).ToListAsync();

                if(listOfUser == null)
                {
                    return result = ResponseMapping.GetResponseMessage(null, (int)ResponseStatus.Fail, Constants.ResponseMessage.NotFound);
                }

                var user = listOfUser.Where(x => x.Password == encryptedPassword).FirstOrDefault();

                if (user == null)
                {
                    return result = ResponseMapping.GetResponseMessage(null, (int)ResponseStatus.Fail, Constants.ResponseMessage.InvalidPassword);
                }

                if(user.IsLock == true)
                {
                    return result = ResponseMapping.GetResponseMessage(null, (int)ResponseStatus.Fail, Constants.ResponseMessage.AccountSuspend);
                }

                user.Password = "";

                return result = ResponseMapping.GetResponseMessage(user, (int)ResponseStatus.Success, Constants.ResponseMessage.LoginSuccessfull);


            }
            catch(Exception ex)
            {
                return result = ResponseMapping.GetResponseMessage(null, (int)ResponseStatus.Fail, ex.Message.ToString());
            }

        }
    }
}
