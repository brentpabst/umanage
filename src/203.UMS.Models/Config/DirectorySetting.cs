using System.ComponentModel.DataAnnotations;

namespace _203.UMS.Models.Config
{
    public class DirectorySetting
    {
        [Required(ErrorMessage = "You must specify the directory name")]
        [StringLength(50, ErrorMessage = "The name of the directory cannot be longer than {1} characters.")]
        [Display(Name = "Current Directory:")]
        public string Directory { get; set; }

        public string Container { get; set; }

        [Required(ErrorMessage = "You must specify the username")]
        [StringLength(50, ErrorMessage = "The username cannot be longer than {1} characters.")]
        [Display(Name = "Username:")]
        public string Username { get; set; }

        [Required(ErrorMessage = "You must specify the password")]
        [StringLength(50, ErrorMessage = "The password cannot be longer than {1} characters.")]
        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
