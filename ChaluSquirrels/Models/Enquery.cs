using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChaluSquirrels.Models
{
    public class Enquery
    {
        [Required(ErrorMessage="Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage="Please enter correct email id.")]
        public string Email { get; set; }
        
        [MaxLength(50, ErrorMessage="Please provide the long description in Message field, here just 50 char.")]
        public string Subject { get; set; }
        
        [Required]
        [MinLength(50, ErrorMessage="Please describe you need in at least 50 char.")]           
        public string Message { get; set; }
    }
}