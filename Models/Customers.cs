using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerAPI.Models
{
    public class Customers
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string sex { get; set; }

        // Foreign Key
        public int RepresentatId { get; set; }
        // Navigation property
        public Representatives Representatives { get; set; }

    }
}