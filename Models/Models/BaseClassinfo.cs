using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class BaseClassinfo
    {
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
