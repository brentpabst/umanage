namespace THS.UMS.AO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using THS.UMS.DTO;
    using THS.UMS.EF;

    public class Offices
    {
        /// <summary>
        /// Gets the active offices.
        /// </summary>
        /// <returns></returns>
        public List<OfficeDTO> GetActiveOffices()
        {
            using (var ctx = new AppEntities())
            {
                var r = new List<OfficeDTO>();
                foreach (var o in ctx.Offices.Where(o => o.IsEnabled))
                {
                    r.Add(BuildOfficeFromEntity(o));
                }
                return r.OrderBy(o => o.Name).ToList();
            }
        }

        /// <summary>
        /// Gets the office.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public OfficeDTO GetOffice(Guid key)
        {
            using (var ctx = new AppEntities())
            {
                return BuildOfficeFromEntity(ctx.Offices.Where(o => o.OfficeId == key).FirstOrDefault());
            }
        }

        public OfficeDTO GetOfficeByName(string name)
        {
            using (var ctx = new AppEntities())
            {
                var e = ctx.Offices.Where(o => o.Name == name && o.IsEnabled).FirstOrDefault();
                return e != null ? BuildOfficeFromEntity(e) : null;
            }
        }

        /// <summary>
        /// Adds the office.
        /// </summary>
        /// <param name="dto">The <c>OfficeDTO</c> to add.</param>
        /// <returns></returns>
        public bool AddOffice(OfficeDTO dto)
        {
            using (var ctx = new AppEntities())
            {
                try
                {
                    var o = new Office
                                {
                                    IsEnabled = true,
                                    OfficeId = Guid.NewGuid(),
                                    Name = dto.Name,
                                    Description = dto.Description
                                };
                    ctx.Offices.AddObject(o);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Updates the office.
        /// </summary>
        /// <param name="dto">The <c>OfficeDTO</c> to update.</param>
        /// <returns></returns>
        public bool UpdateOffice(OfficeDTO dto)
        {
            using (var ctx = new AppEntities())
            {
                try
                {
                    var e = ctx.Offices.Where(o => o.OfficeId == dto.OfficeId).FirstOrDefault();
                    e.Name = dto.Name;
                    e.Description = dto.Description;
                    e.IsEnabled = dto.IsEnabled;

                    ctx.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Builds the office from entity.
        /// </summary>
        /// <param name="o">The entity to build.</param>
        /// <returns></returns>
        private static OfficeDTO BuildOfficeFromEntity(Office o)
        {
            if (o != null)
                return new OfficeDTO
                            {
                                OfficeId = o.OfficeId,
                                Name = o.Name,
                                Description = o.Description,
                                IsEnabled = o.IsEnabled
                            };
            return null;
        }
    }
}
