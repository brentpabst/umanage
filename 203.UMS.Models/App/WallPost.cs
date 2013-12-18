using System;
using System.ComponentModel.DataAnnotations;

namespace _203.UMS.Models.App
{
    public class WallPost
    {
        [Key]
        public Guid PostId { get; set; }

        [Required(ErrorMessage = "You must specify the title for the Post")]
        [StringLength(50, ErrorMessage = "The title cannot be longer than {1} characters.")]
        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime PublishDate { get; set; }

        public bool IsDraft { get; set; }
    }
}
