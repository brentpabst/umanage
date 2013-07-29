namespace THS.UMS.DTO
{
    using System;

    /// <summary>
    /// An employee data transfer object
    /// </summary>
    public class EmployeeDTO
    {
        #region Basic Information
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string DisplayName { get; set; }
        /// <summary>
        /// Gets or sets the name of the sort.
        /// </summary>
        /// <value>
        /// The name of the sort.
        /// </value>
        public string SortName { get; set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        /// <value>
        /// The name of the middle.
        /// </value>
        public string MiddleName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>
        /// The website.
        /// </value>
        public string Website { get; set; }
        #endregion

        #region Organization Information
        /// <summary>
        /// Gets or sets the job title.
        /// </summary>
        /// <value>
        /// The job title.
        /// </value>
        public string JobTitle { get; set; }
        /// <summary>
        /// Gets or sets the office.
        /// </summary>
        /// <value>
        /// The office.
        /// </value>
        public string Office { get; set; }
        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        public string Company { get; set; }
        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        /// <value>
        /// The department.
        /// </value>
        public string Department { get; set; }
        /// <summary>
        /// Gets or sets the employee id.
        /// </summary>
        /// <value>
        /// The employee id.
        /// </value>
        public string EmployeeId { get; set; }
        /// <summary>
        /// Gets or sets the badge id.
        /// </summary>
        /// <value>
        /// The badge id.
        /// </value>
        public string BadgeId { get; set; }
        /// <summary>
        /// Gets or sets the manager.
        /// </summary>
        /// <value>
        /// The manager.
        /// </value>
        public EmployeeDTO Manager { get; set; }
        #endregion

        #region Address
        /// <summary>
        /// Gets or sets the address1.
        /// </summary>
        /// <value>
        /// The address1.
        /// </value>
        public string Address1 { get; set; }
        /// <summary>
        /// Gets or sets the address2.
        /// </summary>
        /// <value>
        /// The address2.
        /// </value>
        public string Address2 { get; set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public string City { get; set; }
        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        public string PostalCode { get; set; }
        /// <summary>
        /// Gets or sets the province.
        /// </summary>
        /// <value>
        /// The province.
        /// </value>
        public string Province { get; set; }
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country { get; set; }
        #endregion

        #region Phone Numbers
        /// <summary>
        /// Gets or sets the home phone.
        /// </summary>
        /// <value>
        /// The home phone.
        /// </value>
        public string HomePhone { get; set; }
        /// <summary>
        /// Gets or sets the office phone.
        /// </summary>
        /// <value>
        /// The office phone.
        /// </value>
        public string OfficePhone { get; set; }
        /// <summary>
        /// Gets or sets the pager.
        /// </summary>
        /// <value>
        /// The pager.
        /// </value>
        public string Pager { get; set; }
        /// <summary>
        /// Gets or sets the mobile phone.
        /// </summary>
        /// <value>
        /// The mobile phone.
        /// </value>
        public string MobilePhone { get; set; }
        /// <summary>
        /// Gets or sets the fax.
        /// </summary>
        /// <value>
        /// The fax.
        /// </value>
        public string Fax { get; set; }
        /// <summary>
        /// Gets or sets the sip phone.
        /// </summary>
        /// <value>
        /// The sip phone.
        /// </value>
        public string SipPhone { get; set; }
        #endregion

        #region Account Information
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username { get; set; }
        /// <summary>
        /// Gets or sets the upn username.
        /// </summary>
        /// <value>
        /// The upn username.
        /// </value>
        public string UpnUsername { get; set; }
        /// <summary>
        /// Gets or sets the name of the distinguished.
        /// </summary>
        /// <value>
        /// The name of the distinguished.
        /// </value>
        public string DistinguishedName { get; set; }
        /// <summary>
        /// Gets or sets the account status.
        /// </summary>
        /// <value>
        /// The account status.
        /// </value>
        public string AccountStatus { get; set; }
        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        public string Notes { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [account locked].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [account locked]; otherwise, <c>false</c>.
        /// </value>
        public bool AccountLocked { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [account disabled].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [account disabled]; otherwise, <c>false</c>.
        /// </value>
        public bool AccountDisabled { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [account expired].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [account expired]; otherwise, <c>false</c>.
        /// </value>
        public bool AccountExpired { get; set; }
        /// <summary>
        /// Gets or sets the account exp date.
        /// </summary>
        /// <value>
        /// The account exp date.
        /// </value>
        public DateTime AccountExpDate { get; set; }
        /// <summary>
        /// Gets or sets the password exp date.
        /// </summary>
        /// <value>
        /// The password exp date.
        /// </value>
        public DateTime PasswordExpDate { get; set; }
        #endregion
    }
}
