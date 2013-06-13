using System;
using System.ComponentModel.DataAnnotations;

namespace _203.UMS.Models.App
{
    public class Office
    {
        public Guid OfficeId { get; set; }

        [Required(ErrorMessage = "You must specify a name for the office.")]
        [StringLength(50, ErrorMessage = "The name of the office cannot be longer than {1} characters.")]
        public string Name { get; set; }

        public DateTime AddedOn { get; set; }
    }
}
