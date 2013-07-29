namespace THS.UMS.DTO
{
    using System;

    public class EmailDTO
    {
        /// <summary>
        /// Gets or sets the email id.
        /// </summary>
        /// <value>
        /// The email id.
        /// </value>
        public Guid EmailId { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }
        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        public string Subject { get; set; }
        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public string Body { get; set; }
        /// <summary>
        /// Gets or sets the submitted on.
        /// </summary>
        /// <value>
        /// The submitted on.
        /// </value>
        public DateTime SubmittedOn { get; set; }
        /// <summary>
        /// Gets or sets the started on.
        /// </summary>
        /// <value>
        /// The started on.
        /// </value>
        public DateTime? StartedOn { get; set; }
        /// <summary>
        /// Gets or sets the completed on.
        /// </summary>
        /// <value>
        /// The completed on.
        /// </value>
        public DateTime? CompletedOn { get; set; }
        /// <summary>
        /// Gets or sets the effective date.
        /// </summary>
        /// <value>
        /// The effective date.
        /// </value>
        public DateTime EffectiveDate { get; set; }
        /// <summary>
        /// Gets or sets the number of attempts.
        /// </summary>
        /// <value>
        /// The attempts.
        /// </value>
        public int Attempts { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is complete.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is complete; otherwise, <c>false</c>.
        /// </value>
        public bool IsComplete { get; set; }
    }
}
