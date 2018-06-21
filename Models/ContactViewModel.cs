using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace SimpleHornesPiano.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "* Required *")]
        public string Name { get; set; }

        [Required(ErrorMessage = "* Required *")]
        [EmailAddress(ErrorMessage = "* Please Enter A Valid Email Address *")]
        public string Email { get; set; }

        [Required(ErrorMessage = "* Required *")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "* Required *")]
        public string Message { get; set; }
    }
}