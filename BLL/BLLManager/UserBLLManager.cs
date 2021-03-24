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
    public class UserBLLManager : IUserBLLManager
    {
        private readonly ApplicationDbContext _dbContext;
        public UserBLLManager(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseMessage> DeleteUser(long id)
        {
            ResponseMessage result = new ResponseMessage();

            try
            {
                User user = await _dbContext.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (user == null)
                {
                    return result = ResponseMapping.GetResponseMessage(null, (int)ResponseStatus.Fail, Constants.ResponseMessage.NotFound);
                }

                user.IsLock = true;
                await _dbContext.SaveChangesAsync();

                return result = ResponseMapping.GetResponseMessage(user.Email, (int)ResponseStatus.Success, Constants.ResponseMessage.DeleteSuccess);


            }
            catch (Exception ex)
            {
                return result = ResponseMapping.GetResponseMessage(null, (int)ResponseStatus.Fail, ex.Message.ToString());
            }
        }

        public async Task<ResponseMessage> GetUserById(long id)
        {
            ResponseMessage result = new ResponseMessage();

            try
            {
                User user = await _dbContext.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (user == null)
                {
                    return result = ResponseMapping.GetResponseMessage(null, (int)ResponseStatus.Fail, Constants.ResponseMessage.NotFound);
                }
                user.Password = "";
                return result = ResponseMapping.GetResponseMessage(user, (int)ResponseStatus.Success, Constants.ResponseMessage.RetrieveSuccess);
            }
            catch (Exception ex)
            {
                return result = ResponseMapping.GetResponseMessage(null, (int)ResponseStatus.Fail, ex.Message.ToString());
            }
        }

        public async Task<ResponseMessage> GetUsers()
        {
            ResponseMessage result = new ResponseMessage();

            try
            {
                var listOfUsers = await (from user in _dbContext.Users
                                         select new VMUserModel()
                                         {
                                             Id = user.Id,
                                             Name = user.Name,
                                             Email = user.Email,
                                             IsDeactive = user.IsDeactive,
                                             IsLock = user.IsLock,
                                             CreatedDate = user.CreatedDate,
                                             CreateId = user.CreateId,
                                             UpdatedDate = user.UpdatedDate,
                                             UpdatedId = user.UpdatedId
                                         }).ToListAsync();

                if (listOfUsers == null)
                {
                    return result = ResponseMapping.GetResponseMessage(null, (int)ResponseStatus.Fail, Constants.ResponseMessage.NotFound);
                }

                return result = ResponseMapping.GetResponseMessage(listOfUsers, (int)ResponseStatus.Success, Constants.ResponseMessage.RetrieveSuccess);
            }
            catch (Exception ex)
            {
                return result = ResponseMapping.GetResponseMessage(null, (int)ResponseStatus.Fail, ex.Message.ToString());
            }
        }

        public async Task<ResponseMessage> SaveUser(VMUserModel model)
        {
            ResponseMessage result = new ResponseMessage();

            try
            {
                User existingUser = await _dbContext.Users.Where(x => x.Email == model.Email).FirstOrDefaultAsync();

                if (existingUser == null)
                {
                    var newUser = MapUserModel(new User(), model);

                    await _dbContext.Users.AddAsync(newUser);
                    await _dbContext.SaveChangesAsync();

                    newUser.Password = "";

                    return result = ResponseMapping.GetResponseMessage(newUser, (int)ResponseStatus.Success, Constants.ResponseMessage.SaveSuccess);
                }

                return result = ResponseMapping.GetResponseMessage(model.Email, (int)ResponseStatus.Fail, Constants.ResponseMessage.AllReadyExist);
            }
            catch (Exception ex)
            {
                return result = ResponseMapping.GetResponseMessage(null, (int)ResponseStatus.Fail, ex.Message.ToString());
            }
        }

        public async Task<ResponseMessage> UpdateUser(VMUserModel model)
        {
            ResponseMessage result = new ResponseMessage();

            try
            {
                User existingUser = await _dbContext.Users.Where(x => x.Id == model.Id).FirstOrDefaultAsync();

                if (existingUser == null)
                {
                    return result = ResponseMapping.GetResponseMessage(null, (int)ResponseStatus.Fail, Constants.ResponseMessage.NotFound);
                }

                existingUser = MapUserModel(existingUser, model);
                await _dbContext.SaveChangesAsync();

                existingUser.Password = "";

                return result = ResponseMapping.GetResponseMessage(existingUser, (int)ResponseStatus.Success, Constants.ResponseMessage.UpdateSuccess);
            }
            catch (Exception ex)
            {
                return result = ResponseMapping.GetResponseMessage(null, (int)ResponseStatus.Fail, ex.Message.ToString());
            }
        }


        #region"Mappper Section "

        private User MapUserModel(User user, VMUserModel model)
        {
            user.Id = model.Id;
            user.Name = model.Name;
            user.Email = model.Email;
            user.Password = (!string.IsNullOrEmpty(model.Password)) ? SimpleCryptService.Factory().Encrypt(model.Password) : user.Password;
            user.IsLock = model.IsLock;
            user.IsDeactive = model.IsDeactive;
            user.CreatedDate = (model.CreatedDate != null) ? model.CreatedDate : user.CreatedDate;
            user.CreateId = (model.CreateId != null) ? model.CreateId : user.CreateId;
            user.UpdatedDate = (model.UpdatedDate != null) ? model.UpdatedDate : user.UpdatedDate;
            user.UpdatedId = (model.UpdatedId != null) ? model.UpdatedId : user.UpdatedId;

            return user;
        }

        #endregion
    }
}
