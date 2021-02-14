using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Constants
{
    public class Constants
    {
        public class HttpHeaders
        {
            public const string Token = "Authorization";
            public const string AuthenticationSchema = "Bearer";

        }

        public static class ResponseMessage
        {
            public const string SuccessMessage = "Data save successfully.";
            public const string FailMessage = "Data save failed.";
            public const string ExistingData = "Existing data not found.";
            public const string RetrieveSuccess = "Data retrieved Successfully.";
            public const string FailRetrieve = "Data not found.";
            public const string TrainSuccess = "Image trained Successfully.";
            public const string TrainFail = "Image trained failed.";
            public const string PERSON_NOT_FOUND = "Person not found.";
            public const string Verification_Success = "Verification Success.";

            public const string Email_Notification = "Data sent to the email.";
            public const string LoginSuccessfull = "Log in successfully.";

        }
    }
}
