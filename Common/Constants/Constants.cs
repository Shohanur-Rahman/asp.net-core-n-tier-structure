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
            public const string SaveSuccess = "Data successfully Saved.";
            public const string UpdateSuccess = "Data successfully Update.";
            public const string DeleteSuccess = "Data successfully Deleted.";
            public const string NotFound = "Existing data not found.";
            public const string AllReadyExist = "Data All Ready Exist.";
            public const string RetrieveSuccess = "Data retrieved Successfully.";
            public const string SuccessMessage = "Data save successfully.";
            public const string FailMessage = "Data save failed.";

            public const string Verification_Success = "Verification Success.";

            public const string Email_Notification = "Data sent to the email.";
            public const string LoginSuccessfull = "Log in successfully.";

        }
    }
}
