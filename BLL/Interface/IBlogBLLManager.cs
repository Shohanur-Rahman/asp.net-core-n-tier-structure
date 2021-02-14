using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interface
{
    public interface IBlogBLLManager
    {
        ResponseMessage GetCategories();
    }
}
