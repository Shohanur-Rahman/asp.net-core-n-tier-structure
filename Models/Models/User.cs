using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class User:BaseClassinfo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool  IsDeactive{ get; set; }
        public bool IsLock { get; set; }
    }
}
