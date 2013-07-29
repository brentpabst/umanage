namespace THS.UMS.DTO
{
    using System;

    public class SiteMenuDTO
    {
        public int MenuID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Roles { get; set; }
        public Int32 Parent { get; set; }
        public string routeName { get; set; }
        public Boolean Enabled { get; set; }

    }

}
