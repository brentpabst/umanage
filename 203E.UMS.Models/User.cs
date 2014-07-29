using System;

namespace _203E.UMS.Models
{
    public class User
    {
        #region Account Properties
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }
        /// <summary>
        /// Gets or sets the user principal name.
        /// </summary>
        /// <value>
        /// The name of the user principal.
        /// </value>
        public string UserPrincipalName { get; set; }
        /// <summary>
        /// Gets or sets the NT username.
        /// </summary>
        /// <value>
        /// The name of the nt user.
        /// </value>
        public string NtUserName { get; set; }
        /// <summary>
        /// Gets or sets the the distinguished name.
        /// </summary>
        /// <value>
        /// The name of the distinguished.
        /// </value>
        public string DistinguishedName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [account is locked].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [account is locked]; otherwise, <c>false</c>.
        /// </value>
        public bool AccountIsLocked { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [account is disabled].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [account is disabled]; otherwise, <c>false</c>.
        /// </value>
        public bool AccountIsDisabled { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [account is expired].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [account is expired]; otherwise, <c>false</c>.
        /// </value>
        public bool AccountIsExpired { get; set; }
        /// <summary>
        /// Gets or sets the account expiration date.
        /// </summary>
        /// <value>
        /// The account expiration date.
        /// </value>
        public DateTime AccountExpirationDate { get; set; }
        /// <summary>
        /// Gets or sets the password expiration date.
        /// </summary>
        /// <value>
        /// The password expiration date.
        /// </value>
        public DateTime PasswordExpirationDate { get; set; }
        #endregion

        #region Demographic Properties
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        private string _displayName;
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string DisplayName
        {
            get { return String.IsNullOrWhiteSpace(_displayName) ? FirstName + " " + LastName : _displayName; }
            set { _displayName = value; }
        }
        /// <summary>
        /// Gets the name of the sort.
        /// </summary>
        /// <value>
        /// The name of the sort.
        /// </value>
        public string SortName
        {
            get
            {
                if (String.IsNullOrWhiteSpace(MiddleName))
                    return LastName + ", " + FirstName;

                if (MiddleName.Length > 2)
                    return LastName + ", " + FirstName + " " + MiddleName.Remove(1) + ".";

                return LastName + ", " + FirstName + " " + MiddleName + ".";
            }
        }
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

        #region Organization Properties
        /// <summary>
        /// Gets or sets the organization.
        /// </summary>
        /// <value>
        /// The organization.
        /// </value>
        public string Organization { get; set; }
        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        /// <value>
        /// The department.
        /// </value>
        public string Department { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the office.
        /// </summary>
        /// <value>
        /// The office.
        /// </value>
        public string Office { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public string EmployeeId { get; set; }
        /// <summary>
        /// Gets or sets the badge identifier.
        /// </summary>
        /// <value>
        /// The badge identifier.
        /// </value>
        public string BadgeId { get; set; }
        #endregion

        #region Address Properties
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
        /// Gets or sets the province.
        /// </summary>
        /// <value>
        /// The province.
        /// </value>
        public string Province { get; set; }
        /// <summary>
        /// Gets or sets the post code.
        /// </summary>
        /// <value>
        /// The post code.
        /// </value>
        public string PostCode { get; set; }
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country { get; set; }
        #endregion

        #region Phone Properties
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
        /// Gets or sets the mobile phone.
        /// </summary>
        /// <value>
        /// The mobile phone.
        /// </value>
        public string MobilePhone { get; set; }
        /// <summary>
        /// Gets or sets the sip phone.
        /// </summary>
        /// <value>
        /// The sip phone.
        /// </value>
        public string SipPhone { get; set; }
        /// <summary>
        /// Gets or sets the pager.
        /// </summary>
        /// <value>
        /// The pager.
        /// </value>
        public string Pager { get; set; }
        /// <summary>
        /// Gets or sets the fax.
        /// </summary>
        /// <value>
        /// The fax.
        /// </value>
        public string Fax { get; set; }
        #endregion
    }
}
