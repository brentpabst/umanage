using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PPI.UMS.DAL;
using PPI.UMS.DTO;

namespace PPI.UMS.BLL
{
    /// <summary>
    /// Provides the interface for interacting with the location objects
    /// </summary>
    [System.ComponentModel.DataObject()]
    public class Locations
    {
        #region Public

        /// <summary>
        /// Gets all locations
        /// </summary>
        /// <returns>A generic list collection</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<Location> GetAllLocations()
        {
            try
            {
                using (uManageEntities context = new uManageEntities())
                {
                    List<Location> locs = new List<Location>();
                    foreach (OfficeLocation loc in context.OfficeLocations)
                    {
                        locs.Add(BuildLocationFromEntity(loc));
                    }
                    return locs;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Gets all of the active locations
        /// </summary>
        /// <returns>A generic list collection</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<Location> GetActiveLocation()
        {
            try
            {
                using (uManageEntities context = new uManageEntities())
                {
                    List<Location> locs = new List<Location>();
                    foreach (OfficeLocation loc in context.OfficeLocations.Where(l => l.IsEnabled == true))
                    {
                        locs.Add(BuildLocationFromEntity(loc));
                    }
                    return locs;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Adds a new location to the data store
        /// </summary>
        /// <param name="location">The location to add</param>
        /// <returns>The number of records affected</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, false)]
        public int AddLocation(string location)
        {
            try
            {
                using (uManageEntities context = new uManageEntities())
                {
                    OfficeLocation loc = new OfficeLocation();

                    loc.Location = location;
                    loc.IsEnabled = true;
                    loc.CreatedBy = HttpContext.Current.User.Identity.Name;
                    loc.CreatedOn = DateTime.UtcNow;
                    loc.ModifiedBy = HttpContext.Current.User.Identity.Name;
                    loc.ModifiedOn = DateTime.UtcNow;

                    context.OfficeLocations.AddObject(loc);
                    return context.SaveChanges();
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Disabled a location for use in the system
        /// </summary>
        /// <param name="location">The location to disable</param>
        /// <returns>The number of records affected</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, false)]
        public int DisableLocation(string location)
        {
            try
            {
                using (uManageEntities context = new uManageEntities())
                {
                    OfficeLocation loc = context.OfficeLocations.Where(l => l.Location == location).FirstOrDefault();

                    context.OfficeLocations.DeleteObject(loc);
                    return context.SaveChanges();
                }
            }
            catch
            {
                return 0;
            }
        }

        #endregion

        #region Private

        /// <summary>
        /// Converts a persisted entity into a Location DTO
        /// </summary>
        /// <param name="loc">The entity to convert</param>
        /// <returns>A Location DTO object</returns>
        private Location BuildLocationFromEntity(OfficeLocation loc)
        {
            Location newLoc = new Location();

            newLoc.Name = loc.Location;
            newLoc.IsEnabled = loc.IsEnabled;
            newLoc.CreatedBy = loc.CreatedBy;
            newLoc.CreatedOn = loc.CreatedOn;
            newLoc.ModifiedBy = loc.ModifiedBy;
            newLoc.ModifiedOn = loc.ModifiedOn;

            return newLoc;
        }

        #endregion
    }
}
