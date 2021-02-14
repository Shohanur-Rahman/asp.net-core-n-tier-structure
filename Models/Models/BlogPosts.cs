using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Models
{
    public class BlogPosts : BaseClassinfo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
