using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Static
{
    public class ResponseMapping
    {
        public static ResponseMessage GetResponseMessage(object any, int statusCode, string messge)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage.data = any;
            responseMessage.statusCode = statusCode;
            responseMessage.message = messge;
            responseMessage.isSuccess = true;

            return responseMessage;
        }
    }
}
