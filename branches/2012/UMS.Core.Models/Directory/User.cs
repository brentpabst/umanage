using System;



namespace UMS.Core.Data.Models.Directory
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string DistinguishedName { get; set; }
        public bool IsLocked { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsExpired { get; set; }
        public DateTime ExpiresOn { get; set; }
        public DateTime PasswordExpiresOn { get; set; }

        public string Name { get; set; }
        private string _displayName;
        public string DisplayName
        {
            get { return String.IsNullOrWhiteSpace(_displayName) ? FirstName + " " + LastName : _displayName; }
            set { _displayName = value; }
        }
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
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

        public string Organization { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        public string Office { get; set; }
        public string EmployeeId { get; set; }
        public string BadgeId { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }

        public string HomePhone { get; set; }
        public string OfficePhone { get; set; }
        public string MobilePhone { get; set; }
        public string SipPhone { get; set; }
        public string Pager { get; set; }
        public string Fax { get; set; }

    }
}
