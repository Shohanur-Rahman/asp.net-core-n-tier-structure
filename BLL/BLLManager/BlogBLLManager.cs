using BLL.Interface;
using Common.Constants;
using Common.Enum;
using Common.Static;
using Models.DB;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BLLManager
{
    public class BlogBLLManager : IBlogBLLManager
    {
        private readonly ApplicationDbContext _context;

        public BlogBLLManager(ApplicationDbContext db)
        {
            _context = db;
        }

        public ResponseMessage GetCategories()
        {
            ResponseMessage responseMessage = new ResponseMessage();

            try
            {
                var categories = _context.Category;
                responseMessage = ResponseMapping.GetResponseMessage(categories, (int)ResponseStatus.Success, Constants.ResponseMessage.RetrieveSuccess);
            }
            catch (Exception ex)
            {
                responseMessage = ResponseMapping.GetResponseMessage(null, (int)ResponseStatus.Success, ex.Message.ToString());
            }

            return responseMessage;
        }
    }
}
