namespace THS.UMS.DTO
{
    using System;

    public class LocationDTO
    {
        /// <summary>
        /// Gets or sets the location id.
        /// </summary>
        /// <value>
        /// The location id.
        /// </value>
        public Guid LocationId { get; set; }
        /// <summary>
        /// Gets or sets the name of the location.
        /// </summary>
        /// <value>
        /// The name of the location.
        /// </value>
        public string LocationName { get; set; }
        /// <summary>
        /// Gets or sets the name of the organization.
        /// </summary>
        /// <value>
        /// The name of the organization.
        /// </value>
        public string OrganizationName { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public string City { get; set; }
        /// <summary>
        /// Gets or sets the province.
        /// </summary>
        /// <value>
        /// The province.
        /// </value>
        public string Province { get; set; }
        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        public string PostalCode { get; set; }
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country { get; set; }
        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        public string Phone { get; set; }
        /// <summary>
        /// Gets or sets the new user distinguished path.
        /// </summary>
        /// <value>
        /// The new user distinguished path.
        /// </value>
        public string DistinguishedPath { get; set; }
        /// <summary>
        /// Gets or sets the new username format.
        /// </summary>
        /// <value>
        /// The new username format.
        /// </value>
        public string NewUsernameFormat { get; set; }
        /// <summary>
        /// Gets or sets the ums directory group.
        /// </summary>
        /// <value>
        /// The ums directory group.
        /// </value>
        public string UmsDirectoryGroup { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsEnabled { get; set; }
        /// <summary>
        /// Gets or sets the directory.
        /// </summary>
        /// <value>
        /// The directory.
        /// </value>
        public string Directory { get; set; }
        /// <summary>
        /// Gets or sets the directory in Windows NT mode.
        /// </summary>
        /// <value>
        /// The directory NT.
        /// </value>
        public string DirectoryNt { get; set; }
    }
}
