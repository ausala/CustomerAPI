using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerAPI.Models
{
    public class Representatives
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string City { get; set; }
    }
}