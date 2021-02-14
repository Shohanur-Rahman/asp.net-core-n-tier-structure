using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceManager.IManager
{
    public interface IBlogManager
    {
        ResponseMessage GetCategories();
    }
}
