using System;
using System.Collections.Generic;
using System.Linq;
using THS.UMS.DTO;

namespace THS.UMS.AO
{
    using System.Web;

    using THS.UMS.EF;

    public class Posts
    {
        public List<PostDTO> GetPosts()
        {
            using (var ctx = new AppEntities())
            {
                var date = DateTime.Now;
                var ls = new List<PostDTO>();
                foreach (var p in ctx.Posts)
                {
                    ls.Add(this.BuildPostDtoFromEntity(p));
                }
                return ls.OrderBy(ps => ps.VisibleFrom).ToList();
            }
        }

        public List<PostDTO> GetVisiblePosts()
        {
            using (var ctx = new AppEntities())
            {
                var date = DateTime.Now;
                var ls = new List<PostDTO>();
                foreach (var p in ctx.Posts.Where(ps => ps.VisibleFrom < date && ps.VisibileTo > date))
                {
                    ls.Add(this.BuildPostDtoFromEntity(p));
                }
                return ls.OrderBy(ps => ps.VisibleFrom).ToList();
            }
        }

        public PostDTO GetPost(Guid id)
        {
            using (var ctx = new AppEntities())
            {
                return this.BuildPostDtoFromEntity(ctx.Posts.Where(ps => ps.PostId == id).FirstOrDefault());
            }
        }

        public bool AddPost(PostDTO p)
        {
            using (var ctx = new AppEntities())
            {
                try
                {
                    var ps = new Post
                        {
                            Message = p.Message,
                            PostedBy = HttpContext.Current.User.Identity.Name,
                            PostedOn = DateTime.Now,
                            PostId = Guid.NewGuid(),
                            Subject = p.Subject,
                            VisibleFrom = p.VisibleFrom,
                            VisibileTo = p.VisibleTo
                        };

                    ctx.Posts.AddObject(ps);
                    ctx.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool UpdatePost(PostDTO p)
        {
            using (var ctx = new AppEntities())
            {
                try
                {
                    var post = ctx.Posts.Where(ps => ps.PostId == p.PostId).FirstOrDefault();
                    if (post == null) return false;

                    post.Subject = p.Subject;
                    post.Message = p.Message;
                    post.VisibleFrom = p.VisibleFrom;
                    post.VisibileTo = p.VisibleTo;

                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool DeletePost(PostDTO p)
        {
            using (var ctx = new AppEntities())
            {
                try
                {
                    ctx.DeleteObject(ctx.Posts.Where(ps => ps.PostId == p.PostId).FirstOrDefault());
                    ctx.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        private PostDTO BuildPostDtoFromEntity(Post p)
        {
            if (p == null) return null;

            string postedBy;

            try
            {
                postedBy = new Employees().GetEmployeeByUsername(p.PostedBy).DisplayName;
            }
            catch (Exception)
            {
                postedBy = "System";
            }

            return new PostDTO
                {
                    Message = p.Message,
                    PostedBy = postedBy,
                    PostedOn = p.PostedOn,
                    PostId = p.PostId,
                    Subject = p.Subject,
                    VisibleFrom = p.VisibleFrom,
                    VisibleTo = p.VisibileTo
                };
        }
    }
}
