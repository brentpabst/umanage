namespace THS.UMS.DTO
{
    using System;

    public class OfficeDTO
    {
        /// <summary>
        /// Gets or sets the office id.
        /// </summary>
        /// <value>
        /// The office id.
        /// </value>
        public Guid OfficeId { get; set;}
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsEnabled { get; set;}
    }
}
