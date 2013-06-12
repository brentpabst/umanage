using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace _203.UMS.Models.App
{
    public class QuickLink
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Link ID", ShortName = "ID")]
        public Guid LinkId { get; set; }

        [Required(ErrorMessage = "You must specify the URL for the link")]
        [StringLength(100, ErrorMessage = "The URL cannot be longer than {1} characters.")]
        [DataType(DataType.Url)]
        [Display(Name = "URL")]
        public string Url { get; set; }

        [Required(ErrorMessage = "You must specify text for the link.")]
        [StringLength(50, ErrorMessage = "Link cannot be longer than {1} characters.")]
        [Display(Name = "Display Text")]
        public string Text { get; set; }

        [Required(ErrorMessage = "You must specify a display order for the link.")]
        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }

        [Display(Name = "Open in New Window")]
        public bool NewWindow { get; set; }
    }
}
