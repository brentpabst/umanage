using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace UMS.Core.Data.Models.App
{
    public class Location
    {
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Location ID", ShortName = "ID")]
        public Guid LocationId { get; set; }

        [Required(ErrorMessage = "You must specify a name for the location.")]
        [StringLength(50, ErrorMessage = "The name of the location cannot be longer than {1} characters.")]
        [Display(Name = "Location Name")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "The name of the organization cannot be longer than {1} characters.")]
        [Display(Name = "Organization Name")]
        public string OrgName { get; set; }

        [StringLength(100, ErrorMessage = "The address cannot be longer than {1} characters.")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [StringLength(50, ErrorMessage = "The name of the city cannot be longer than {1} characters.")]
        [Display(Name = "City")]
        public string City { get; set; }

        [StringLength(50, ErrorMessage = "The name of the state or province cannot be longer than {1} characters.")]
        [Display(Name = "State/Province")]
        public string Province { get; set; }

        [StringLength(15, ErrorMessage = "The zip or postal code cannot be longer than {1} characters.")]
        [Display(Name = "Post/Zip Code")]
        public string PostalCode { get; set; }

        [StringLength(30, ErrorMessage = "The name of the country cannot be longer than {1} characters.")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [StringLength(20, ErrorMessage = "The phone number cannot be longer than {1} characters.")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "You must specify a distinguished path.")]
        [StringLength(200, ErrorMessage = "The distinguished path cannot be longer than {1} characters.")]
        [Display(Name = "Distinguished Path")]
        public string DistinguishedPath { get; set; }

        [Required(ErrorMessage = "You must specify a username format for new users.")]
        [StringLength(50, ErrorMessage = "The username format cannot be longer than {1} characters.")]
        [Display(Name = "Username Format")]
        public string NewUsernameFormat { get; set; }

        [Required(ErrorMessage = "You must specify the name of the group for the system to manage.")]
        [StringLength(100, ErrorMessage = "The managed group name cannot be longer than {1} characters.")]
        [Display(Name = "Managed Group")]
        public string SearchableGroup { get; set; }

        [Required(ErrorMessage = "You must specify the name of the directory.")]
        [StringLength(50, ErrorMessage = "The directory cannot be longer than {1} characters.")]
        [Display(Name = "Directory")]
        public string Directory { get; set; }

        [Required(ErrorMessage = "You must specify the name of the directory in NT format.")]
        [StringLength(50, ErrorMessage = "The NT directory cannot be longer than {1} characters.")]
        [Display(Name = "Directory NT")]
        public string DirectoryNt { get; set; }

        [Display(Name = "Is Enabled")]
        public bool IsEnabled { get; set; }
    }
}
