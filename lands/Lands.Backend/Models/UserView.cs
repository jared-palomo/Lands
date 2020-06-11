using Lands.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lands.Backend.Models
{
    [NotMapped]
    public class UserView : User
    {
        //[Display(Name ="Picture")]
        //public HttpPostedFileBase PictureFile { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(20, ErrorMessage = "The lenght for field {0} must be between {1} and {2} characters.", MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "The field {0} is required.")]
        [Compare("Password", ErrorMessage = "The password and confirm does not match.")]
        public string PasswordConfirm { get; set; }
    }
}