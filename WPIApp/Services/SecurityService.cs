using BLL.Interface;
using Common.Constants;
using Common.Enum;
using Common.Static;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.Models;
using Models.VMModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WPIApp.IServices;

namespace WPIApp.Services
{
    public class SecurityService: ISecurityService
    {
        private readonly ISecurityBLLManager _securityBll;
        private readonly string _jwtTokenKey;
        public SecurityService(IConfiguration configuration, ISecurityBLLManager sercurityBLL)
        {
            _securityBll = sercurityBLL;
            _jwtTokenKey = configuration.GetValue<string>("JWT");
        }

        public async Task<JsonResult> Login(VMLogin login)
        {
            ResponseMessage result = new ResponseMessage();

            try
            {
                var response = await _securityBll.Login(login);
                if (response.isSuccess == true)
                {
                    User user = (User)response.data;
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenKey = Encoding.ASCII.GetBytes(_jwtTokenKey);
                    var tokenDescription = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    }),

                        Expires = DateTime.UtcNow.AddDays(30),

                        SigningCredentials = new SigningCredentials(
                            new SymmetricSecurityKey(tokenKey),
                            SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenDetails = tokenHandler.CreateToken(tokenDescription);

                    var jwtToken = tokenHandler.WriteToken(tokenDetails);

                     result = ResponseMapping.GetResponseMessage(jwtToken, (int)ResponseStatus.Success, Constants.ResponseMessage.LoginSuccessfull);
                }
                else
                {
                    result = ResponseMapping.GetResponseMessage(null, (int)ResponseStatus.Fail, response.message);
                }
            }catch(Exception ex)
            {
                result = ResponseMapping.GetResponseMessage(null, (int)ResponseStatus.Fail, ex.Message.ToString());
            }

            return new JsonResult(result);
        }
    }
}
