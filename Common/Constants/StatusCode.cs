using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Constants
{
    public class StatusCode
    {
        public const int BadRequest = 400;
        public const int NotFound = 404;
        public const int Unauthenticate = 401;
        public const int UnauthenticateInactivity = 402;
        public const int Unauthorize = 403;
        public const int InternalServerError = 500;
        public const int JsonNotValid = 502;
        public const int MqttException = 503;
        public const int InvalidTokenFormat = 406;
        public const int TokenMissing = 417;
        public const int SessionOut = 419;
        public const int InvalidObject = 204;
        public const int DataNotValid = 422;


        public const int ExceedAffordability = 499;
        public const int AgencyNotFound = 498;
        public const int NotAllowModifyActiveDeduction = 495;
        public const int WrongEffectiveMonth = 497;
        public const int LoanNotZero = 496;

    }
}
