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
            responseMessage.message = messge;
            responseMessage.isSuccess = (statusCode == 1) ? true : false;

            return responseMessage;
        }
    }
}
