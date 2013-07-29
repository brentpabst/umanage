
using System.ComponentModel.DataAnnotations;

namespace UMS.Core.Data.Models.Config
{
    public class DatabaseSetting
    {
        [Required(ErrorMessage = "You must specify the server name")]
        [StringLength(75, ErrorMessage = "The name of the server cannot be longer than {1} characters.")]
        [Display(Name = "Database Server:")]
        public string Server { get; set; }

        [Required(ErrorMessage = "You must specify a name for the database.")]
        [StringLength(50, ErrorMessage = "The name of the database cannot be longer than {1} characters.")]
        [Display(Name = "Catalog / Database:")]
        public string Catalog { get; set; }

        [Display(Name = "Integrated Security")]
        public bool IntegratedSecurity { get; set; }

        [StringLength(50, ErrorMessage = "The username cannot be longer than {1} characters.")]
        [Display(Name = "Username:")]
        public string Username { get; set; }

        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
