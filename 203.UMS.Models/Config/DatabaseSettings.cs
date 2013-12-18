
using System.ComponentModel.DataAnnotations;

namespace _203.UMS.Models.Config
{
    public class DatabaseSettings
    {
        [Required(ErrorMessage = "You must specify the server name")]
        [StringLength(75, ErrorMessage = "The name of the server cannot be longer than {1} characters.")]
        public string Server { get; set; }

        [Required(ErrorMessage = "You must specify a name for the database.")]
        [StringLength(50, ErrorMessage = "The name of the database cannot be longer than {1} characters.")]
        public string Catalog { get; set; }

        public bool IntegratedSecurity { get; set; }

        [StringLength(50, ErrorMessage = "The username cannot be longer than {1} characters.")]
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
