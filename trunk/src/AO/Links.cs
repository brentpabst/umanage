namespace THS.UMS.AO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using THS.UMS.DTO;
    using THS.UMS.EF;

    public class Links
    {
        public List<LinkDTO> GetLinks()
        {
            using (var ctx = new AppEntities())
            {
                var ls = new List<LinkDTO>();
                foreach (var l in ctx.QuickLinks)
                {
                    ls.Add(this.BuildLinkDtoFromEntity(l));
                }
                return ls.OrderBy(l => l.Order).ThenBy(l => l.Text).ToList();
            }
        }

        public LinkDTO GetLink(Guid id)
        {
            using (var ctx = new AppEntities())
            {
                var ls = ctx.QuickLinks.Where(l => l.LinkId == id).FirstOrDefault();
                return ls != null ? this.BuildLinkDtoFromEntity(ls) : null;
            }
        }

        public bool AddLink(LinkDTO l)
        {
            using (var ctx = new AppEntities())
            {
                try
                {
                    var link = new QuickLink { DisplayOrder = l.Order, DisplayText = l.Text, LinkId = Guid.NewGuid(), Url = l.Url };
                    ctx.QuickLinks.AddObject(link);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool UpdateLink(LinkDTO l)
        {
            using (var ctx = new AppEntities())
            {
                try
                {
                    var link = ctx.QuickLinks.Where(ls => ls.LinkId == l.LinkId).FirstOrDefault();
                    if (link == null) return false;

                    link.DisplayText = l.Text;
                    link.Url = l.Url;
                    link.DisplayOrder = l.Order;

                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool DeleteLink(LinkDTO l)
        {
            using (var ctx = new AppEntities())
            {
                try
                {
                    ctx.DeleteObject(ctx.QuickLinks.Where(ls => ls.LinkId == l.LinkId).FirstOrDefault());
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        private LinkDTO BuildLinkDtoFromEntity(QuickLink e)
        {
            return new LinkDTO
                {
                    LinkId = e.LinkId,
                    Order = e.DisplayOrder,
                    Text = e.DisplayText,
                    Url = e.Url
                };
        }
    }
}
