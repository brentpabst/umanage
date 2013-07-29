namespace THS.UMS.AO
{
    using System.Collections.Generic;

    using THS.UMS.DTO;
    using THS.UMS.EF;

    class SiteMenus
    {

        //public List<SiteMenuDTO> GetSiteMenuNodes()
        //{
        //    using (var ctx = new AppEntities())
        //    {
        //        var nodes = new List<SiteMenuDTO>();
        //        foreach (var n in ctx.SiteMenus.OrderBy(n => n.Parent).Where(n => n.Enabled == true))
        //        {
        //            nodes.Add(BuildNodeFromEntity(n));
        //        }

        //        return nodes;
        //    }
        //}






        private static SiteMenuDTO BuildNodeFromEntity(SiteMenu n)
        {
            if ( n == null) return null;
            return new SiteMenuDTO
            {
                MenuID = n.MenuID,
                Title = n.Title,
                Description = n.Description,
                Url = n.URL,
                Roles = n.Roles,
                Parent = (int)n.Parent,
                routeName = n.routeName,
                Enabled = (bool)n.Enabled

            };

        }


    }
}
