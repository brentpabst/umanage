using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UMS.Web.ViewModels
{
    public class AuthorizeUser
    {
        [Display(Name = "Enter User Name")]
        [Required(ErrorMessage = "You must enter a username!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "User Name formats must be in user@domain.ext format!")]
        public string UserName { get; set; }

        [Display(Name = "Assigned Roles")]
        public Dictionary<string, bool> Roles { get; set; }
    }
}