namespace THS.UMS.AO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using THS.UMS.DTO;
    using THS.UMS.EF;

    public class Locations
    {
        /// <summary>
        /// Gets the active locations.
        /// </summary>
        /// <returns></returns>
        public List<LocationDTO> GetActiveLocations()
        {
            using (var ctx = new AppEntities())
            {
                var r = new List<LocationDTO>();
                foreach (var l in ctx.Locations.Where(l => l.IsEnabled))
                {
                    r.Add(BuildLocationFromEntity(l));
                }
                return r.OrderBy(l => l.LocationName).ToList();
            }
        }

        /// <summary>
        /// Gets the location details.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public LocationDTO GetLocation(Guid id)
        {
            using (var ctx = new AppEntities())
            {
                return BuildLocationFromEntity(ctx.Locations.Where(l => l.LocationId == id).FirstOrDefault());
            }
        }

        /// <summary>
        /// Gets the domain location by Windows NT directory.
        /// </summary>
        /// <param name="d">The Windows NT Directory to look for.</param>
        /// <returns></returns>
        public string GetDirectoryByNtDirectory(string d)
        {
            using (var ctx = new AppEntities())
            {
                var dom = BuildLocationFromEntity(ctx.Locations.Where(o => o.IsEnabled && o.DirectoryNt == d).FirstOrDefault());

                if (dom == null) return null;
                return dom.Directory;
            }
        }

        /// <summary>
        /// Gets the location security groups.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetLocationSecurityGroup()
        {
            using (var ctx = new AppEntities())
            {
                var groups = new Dictionary<string, string>();
                foreach (var l in ctx.Locations.Where(o => o.IsEnabled))
                {
                    if (!String.IsNullOrWhiteSpace(l.UmsDirectoryGroup))
                    {
                        if (!groups.ContainsKey(l.Directory))
                            groups.Add(l.Directory, l.UmsDirectoryGroup);
                    }
                }
                return groups;
            }
        }

        /// <summary>
        /// Updates the location.
        /// </summary>
        /// <param name="dto">The location.</param>
        /// <returns></returns>
        public bool UpdateLocation(LocationDTO dto)
        {
            using (var ctx = new AppEntities())
            {
                try
                {
                    var loc = ctx.Locations.Where(l => l.LocationId == dto.LocationId).FirstOrDefault();

                    loc.LocationName = dto.LocationName;
                    loc.OrganizationName = dto.OrganizationName;
                    loc.Address = dto.Address;
                    loc.City = dto.City;
                    loc.Province = dto.Province;
                    loc.PostalCode = dto.PostalCode;
                    loc.Country = dto.Country;
                    loc.Phone = dto.Phone;
                    loc.DistinguishedPath = dto.DistinguishedPath;
                    loc.NewUsernameFormat = dto.NewUsernameFormat;
                    loc.UmsDirectoryGroup = dto.UmsDirectoryGroup;
                    loc.IsEnabled = dto.IsEnabled;
                    loc.Directory = dto.Directory;
                    loc.DirectoryNt = dto.Directory.Contains(".") ? dto.Directory.Substring(0, dto.Directory.IndexOf('.')) : dto.Directory;

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
        /// Inserts the location.
        /// </summary>
        /// <param name="dto">The location.</param>
        /// <returns></returns>
        public bool InsertLocation(LocationDTO dto)
        {
            using (var ctx = new AppEntities())
            {
                try
                {
                    var l = new Location
                                {
                                    IsEnabled = true,
                                    LocationId = Guid.NewGuid(),
                                    LocationName = dto.LocationName,
                                    OrganizationName = dto.OrganizationName,
                                    Address = dto.Address,
                                    City = dto.City,
                                    Province = dto.Province,
                                    PostalCode = dto.PostalCode,
                                    Country = dto.Country,
                                    Phone = dto.Phone,
                                    DistinguishedPath = dto.DistinguishedPath,
                                    NewUsernameFormat = dto.NewUsernameFormat,
                                    UmsDirectoryGroup = dto.UmsDirectoryGroup,
                                    Directory = dto.Directory,
                                    DirectoryNt = dto.Directory.Contains(".") ? dto.Directory.Substring(0, dto.Directory.IndexOf('.')) : dto.Directory
                                };

                    ctx.Locations.AddObject(l);
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
        /// Builds the location from entity.
        /// </summary>
        /// <param name="l">The l.</param>
        /// <returns></returns>
        private static LocationDTO BuildLocationFromEntity(Location l)
        {
            if (l != null)
                return new LocationDTO
                            {
                                LocationId = l.LocationId,
                                LocationName = l.LocationName,
                                OrganizationName = l.OrganizationName,
                                Address = l.Address,
                                City = l.City,
                                Province = l.Province,
                                PostalCode = l.PostalCode,
                                Country = l.Country,
                                Phone = l.Phone,
                                DistinguishedPath = l.DistinguishedPath,
                                NewUsernameFormat = l.NewUsernameFormat,
                                UmsDirectoryGroup = l.UmsDirectoryGroup,
                                IsEnabled = l.IsEnabled,
                                Directory = l.Directory,
                                DirectoryNt = l.DirectoryNt
                            };
            return null;
        }
    }
}
