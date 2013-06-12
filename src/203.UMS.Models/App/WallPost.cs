using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace _203.UMS.Models.App
{
    public class WallPost
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Post ID", ShortName = "ID")]
        public Guid PostId { get; set; }

        [Required(ErrorMessage = "You must specify the title for the Post")]
        [StringLength(50, ErrorMessage = "The title cannot be longer than {1} characters.")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [AllowHtml]
        [Display(Name = "Body")]
        public string Body { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Publish Date")]
        public DateTime PublishDate { get; set; }

        [Display(Name = "Save for Later?")]
        public bool IsDraft { get; set; }
    }
}
