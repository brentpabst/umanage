namespace THS.UMS.DTO
{
    using System;

    public class LinkDTO
    {
        public Guid LinkId { get; set; }

        public string Url { get; set; }

        public string Text { get; set; }

        public int Order { get; set; }
    }
}
