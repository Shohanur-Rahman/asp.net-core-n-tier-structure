using ServiceManager.IManager;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interface;

namespace ServiceManager.BLLManager
{
    public class BlogManager : IBlogManager
    {
        private readonly IBlogBLLManager _blogBLL;
        public BlogManager(IBlogBLLManager blogBLL)
        {
            _blogBLL = blogBLL;
        }

        public ResponseMessage GetCategories()
        {
            return _blogBLL.GetCategories();
        }
    }
}
