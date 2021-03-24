using Models.Models;
using Models.VMModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface ISecurityBLLManager
    {
        Task<ResponseMessage> Login(VMLogin login);
    }
}
