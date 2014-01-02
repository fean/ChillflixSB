using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SickBeard.Schedule.Models
{
    public class LoginModel
    {
        [Required]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Text)]
        public string Username { get; set; }
        [Required]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }
        [Display(Name="Remember me")]
        public bool Remember { get; set; }
        public string ReturnUrl { get; set; }
    }
}