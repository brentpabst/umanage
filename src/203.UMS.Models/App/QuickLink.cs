using System;
using System.ComponentModel.DataAnnotations;

namespace _203.UMS.Models.App
{
    public class QuickLink
    {
        [Key]
        public Guid LinkId { get; set; }

        [Required(ErrorMessage = "You must specify the URL for the link")]
        [StringLength(100, ErrorMessage = "The URL cannot be longer than {1} characters.")]
        public string Url { get; set; }

        [Required(ErrorMessage = "You must specify text for the link.")]
        [StringLength(50, ErrorMessage = "Link cannot be longer than {1} characters.")]
        public string Text { get; set; }

        [Required(ErrorMessage = "You must specify a display order for the link.")]
        public int DisplayOrder { get; set; }

        public bool NewWindow { get; set; }
    }
}
