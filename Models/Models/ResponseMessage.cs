using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class ResponseMessage
    {
        public object data { get; set; }
        public string message { get; set; }
        public bool isSuccess { get; set; }

    }
}
