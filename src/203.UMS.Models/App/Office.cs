using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace _203.UMS.Models.App
{
    public class Office
    {
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Office ID", ShortName = "ID")]
        public Guid OfficeId { get; set; }

        [Required(ErrorMessage = "You must specify a name for the office.")]
        [StringLength(50, ErrorMessage = "The name of the office cannot be longer than {1} characters.")]
        [Display(Name = "Office Name")]
        public string Name { get; set; }

        [Display(Name = "Date Added")]
        [HiddenInput(DisplayValue = false)]
        public DateTime AddedOn { get; set; }
    }
}
