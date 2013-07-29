using System;

namespace PPI.UMS.DTO
{
    /// <summary>
    /// Provides the Data Transfer Object for all timeline messages
    /// </summary>
    public class Message
    {
        /// <summary>
        /// The Unique Identifier for the Message
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// The Title of the message
        /// </summary>
        public String Title { get; set; }
        /// <summary>
        /// The Description or content of the message
        /// </summary>
        public String Description { get; set; }
        /// <summary>
        /// The User who created the message or caused it to be created
        /// </summary>
        public String CreatedBy { get; set; }
        /// <summary>
        /// When the messages was created.
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// The Category the message falls into.
        /// </summary>
        public String Category { get; set; }
        /// <summary>
        /// Specifies if the message was triggered by a system configuration task
        /// </summary>
        public Boolean IsSysMsg { get; set; }
    }
}
