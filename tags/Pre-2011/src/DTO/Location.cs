using System;

namespace PPI.UMS.DTO
{
    /// <summary>
    /// Provides the Data Transfer Object for locations
    /// </summary>
    public class Location
    {
        /// <summary>
        /// The Name of the location
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Specifies if the location is enabled
        /// </summary>
        public bool IsEnabled { get; set; }
        /// <summary>
        /// Who created the location
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// When the location was created
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// Who last modified the location
        /// </summary>
        public string ModifiedBy { get; set; }
        /// <summary>
        /// When the location was last modified
        /// </summary>
        public DateTime ModifiedOn { get; set; }
    }
}
