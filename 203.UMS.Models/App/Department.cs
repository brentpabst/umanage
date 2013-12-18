using System;
using System.ComponentModel.DataAnnotations;

namespace _203.UMS.Models.App
{
    public class Department
    {
        public Guid DepartmentId { get; set; }

        [Required(ErrorMessage = "You must specify a name for the department.")]
        [StringLength(50, ErrorMessage = "The name of the department cannot be longer than {1} characters.")]
        public string Name { get; set; }

        public DateTime AddedOn { get; set; }
    }
}
