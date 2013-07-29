using System;

namespace THS.UMS.DTO
{
    public class PostDTO
    {
        public Guid PostId { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public string PostedBy { get; set; }

        public DateTime PostedOn { get; set; }

        public DateTime VisibleFrom { get; set; }

        public DateTime VisibleTo { get; set; }
    }
}
