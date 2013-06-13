using System;
using System.ComponentModel.DataAnnotations;

namespace _203.UMS.Models.App
{
    public class Location
    {
        public Guid LocationId { get; set; }

        [Required(ErrorMessage = "You must specify a name for the location.")]
        [StringLength(50, ErrorMessage = "The name of the location cannot be longer than {1} characters.")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "The name of the organization cannot be longer than {1} characters.")]
        public string OrgName { get; set; }

        [StringLength(100, ErrorMessage = "The address cannot be longer than {1} characters.")]
        public string Address { get; set; }

        [StringLength(50, ErrorMessage = "The name of the city cannot be longer than {1} characters.")]
        public string City { get; set; }

        [StringLength(50, ErrorMessage = "The name of the state or province cannot be longer than {1} characters.")]
        public string Province { get; set; }

        [StringLength(15, ErrorMessage = "The zip or postal code cannot be longer than {1} characters.")]
        public string PostalCode { get; set; }

        [StringLength(30, ErrorMessage = "The name of the country cannot be longer than {1} characters.")]
        public string Country { get; set; }

        [StringLength(20, ErrorMessage = "The phone number cannot be longer than {1} characters.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "You must specify a distinguished path.")]
        [StringLength(200, ErrorMessage = "The distinguished path cannot be longer than {1} characters.")]
        public string DistinguishedPath { get; set; }

        [Required(ErrorMessage = "You must specify a username format for new users.")]
        [StringLength(50, ErrorMessage = "The username format cannot be longer than {1} characters.")]
        public string NewUsernameFormat { get; set; }

        [Required(ErrorMessage = "You must specify the name of the group for the system to manage.")]
        [StringLength(100, ErrorMessage = "The managed group name cannot be longer than {1} characters.")]
        public string SearchableGroup { get; set; }

        [Required(ErrorMessage = "You must specify the name of the directory.")]
        [StringLength(50, ErrorMessage = "The directory cannot be longer than {1} characters.")]
        public string Directory { get; set; }

        [Required(ErrorMessage = "You must specify the name of the directory in NT format.")]
        [StringLength(50, ErrorMessage = "The NT directory cannot be longer than {1} characters.")]
        public string DirectoryNt { get; set; }

        public bool IsEnabled { get; set; }
    }
}
