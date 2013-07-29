using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UMS.Web.ViewModels
{
    public class ChangePassword
    {
        [Display(Name = "Current Password")]
        [Required(ErrorMessage = "You must enter your current password!")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Display(Name = "New Password")]
        [Required(ErrorMessage = "You must enter a new password!")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "The password must be at least {2} characters!")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "You must confirm your new password!")]
        [Compare("NewPassword", ErrorMessage = "Your passwords do not match!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}