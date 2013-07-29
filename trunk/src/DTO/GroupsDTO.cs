namespace THS.UMS.DTO
{
    using System;

    public class GroupsDTO
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string DisplayName { get; set; }
        /// <summary>
        /// Gets or sets the discription.
        /// </summary>
        /// <value>
        /// The discription.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the Distinguished name.
        /// </summary>
        /// <value>
        /// The Distinguished name.
        /// </value>
        public string DistinguishedName { get; set; }
        /// <summary>
        /// Gets or sets the Guid.
        /// </summary>
        /// <value>
        /// The Guid.
        /// </value>
        public Guid groupGuid { get; set; }
        /// <summary>
        /// Gets or sets the Full Path.
        /// </summary>
        /// <value>
        /// The Path.
        /// </value>
        public string LDAPPath { get; set; }

        /// <summary>
        /// Gets or sets isSecurityGroup
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public Boolean isSecurityGroup { get; set; }
        /// <summary>
        /// Gets or sets ManagedBy
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public String ManagedBy { get; set; }




    }
}
