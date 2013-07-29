using System;

namespace PPI.UMS.DTO
{
    /// <summary>
    /// Provides the Data Transfer Object for Employees
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// The full name of the employee for displaying
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// The full name of the employee organized in standard sort order
        /// </summary>
        public string SortName { get; set; }
        /// <summary>
        /// The first name for the employee
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The middle name of the employee
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// The last name or family name of the employee
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The email address for the employee
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// The website for the employee
        /// </summary>
        public string Website { get; set; }
        /// <summary>
        /// A photo of the employee
        /// </summary>
        public byte[] Picture { get; set; }
        /// <summary>
        /// The location or office number for the employee
        /// </summary>
        public string Office { get; set; }
        /// <summary>
        /// The employees primary mailing address
        /// </summary>
        public string Address1 { get; set; }
        /// <summary>
        /// The PO Box, Apartment, or FOB address for the employee
        /// </summary>
        public string Address2 { get; set; }
        /// <summary>
        /// The city or town the employee resides in
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// The state or region the employee resides in
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// The postal code the employee resides in
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        /// The country the employee resides in
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// The office phone number for the employee
        /// </summary>
        public string PhoneOffice { get; set; }
        /// <summary>
        /// The home phone number for the employee
        /// </summary>
        public string PhoneHome { get; set; }
        /// <summary>
        /// The pager or SMS number for the employee
        /// </summary>
        public string PhonePager { get; set; }
        /// <summary>
        /// The mobile or cell number for the employee
        /// </summary>
        public string PhoneMobile { get; set; }
        /// <summary>
        /// The fax number for the employee
        /// </summary>
        public string PhoneFax { get; set; }
        /// <summary>
        /// The SIP or Digital number for the employee
        /// </summary>
        public string PhoneSip { get; set; }
        /// <summary>
        /// The name of the company the employee works for
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// The department the employee belongs to
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// The employees manager or supervisor
        /// </summary>
        public string Manager { get; set; }
        /// <summary>
        /// The employees ID or number
        /// </summary>
        public string EmployeeId { get; set; }
        /// <summary>
        /// The employees job title
        /// </summary>
        public string JobTitle { get; set; }

        //Account Related
        /// <summary>
        /// The username for the employees account
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// The username for the employees account in UPN format
        /// </summary>
        public string UsernameUpn { get; set; }
        /// <summary>
        /// The fully qualified username for a user
        /// </summary>
        public string DistinguishedName { get; set; }
        /// <summary>
        /// A basic string describing the state of the employees account
        /// </summary>
        public string AccountStatus { get; set; }
        /// <summary>
        /// Notes about the employees account
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Specifies if the employees account is locked
        /// </summary>
        public bool AccountLocked { get; set; }
        /// <summary>
        /// Specifies if the employees account is disabled
        /// </summary>
        public bool AccountDisabled { get; set; }
        /// <summary>
        /// When the employees account will expire
        /// </summary>
        public DateTime AccountExpDate { get; set; }
        /// <summary>
        /// When the employees password will expire
        /// </summary>
        public DateTime PasswordExpDate { get; set; }
    }
}
