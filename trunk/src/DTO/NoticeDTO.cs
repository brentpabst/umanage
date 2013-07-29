namespace THS.UMS.DTO
{
    using System;

    public class NoticeDTO
    {
        /// <summary>
        /// Gets or sets the notice id.
        /// </summary>
        /// <value>
        /// The notice id.
        /// </value>
        public Guid NoticeId { get; set; }
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username { get; set; }
        /// <summary>
        /// Gets or sets the username upn.
        /// </summary>
        /// <value>
        /// The username upn.
        /// </value>
        public string UsernameUpn { get; set; }
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string DisplayName { get; set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Gets or sets the type of the notice.
        /// </summary>
        /// <value>
        /// The type of the notice.
        /// </value>
        public NoticeType Type { get; set; }
        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        /// <value>
        /// The expiration date.
        /// </value>
        public DateTime ExpirationDate { get; set; }
        /// <summary>
        /// Gets or sets the notice date.
        /// </summary>
        /// <value>
        /// The notice date.
        /// </value>
        public DateTime NoticeDate { get; set; }
    }
}
