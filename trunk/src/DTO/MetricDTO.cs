namespace THS.UMS.DTO
{
    public class MetricDTO
    {
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public LocationDTO Location { get; set; }
        /// <summary>
        /// Gets or sets the total user count.
        /// </summary>
        /// <value>
        /// The total user count.
        /// </value>
        public int TotalUserCount { get; set; }
        /// <summary>
        /// Gets or sets the expired account count.
        /// </summary>
        /// <value>
        /// The expired account count.
        /// </value>
        public int ExpiredAccountCount { get; set; }
        /// <summary>
        /// Gets or sets the expired password count.
        /// </summary>
        /// <value>
        /// The expired password count.
        /// </value>
        public int ExpiredPasswordCount { get; set; }
        /// <summary>
        /// Gets or sets the expiring account count.
        /// </summary>
        /// <value>
        /// The expiring account count.
        /// </value>
        public int ExpiringAccountCount { get; set; }
        /// <summary>
        /// Gets or sets the expiring password count.
        /// </summary>
        /// <value>
        /// The expiring password count.
        /// </value>
        public int ExpiringPasswordCount { get; set; }
    }
}
