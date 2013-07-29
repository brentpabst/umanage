using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UMS.Core.Data.Models.App
{
    public class Department
    {
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Department ID", ShortName = "ID")]
        public Guid DepartmentId { get; set; }

        [Required(ErrorMessage = "You must specify a name for the department.")]
        [StringLength(50, ErrorMessage = "The name of the department cannot be longer than {1} characters.")]
        [Display(Name = "Department Name")]
        public string Name { get; set; }

        [Display(Name = "Date Added")]
        [HiddenInput(DisplayValue = false)]
        public DateTime AddedOn { get; set; }
    }
}
