
using System;
using System.ComponentModel;

namespace E203.uManage.Services.Models
{
    public class User
    {
        [ReadOnly(true)]
        public Guid UserId { get; set; }
        [ReadOnly(true)]
        public string UserPrincipalName { get; set; }
        [ReadOnly(true)]
        public string NtUserName { get; set; }
        [ReadOnly(true)]
        public string DistinguishedName { get; set; }
        [ReadOnly(true)]
        public bool? AccountIsLocked { get; set; }
        [ReadOnly(true)]
        public bool? AccountIsDisabled { get; set; }
        [ReadOnly(true)]
        public bool? AccountIsExpired { get; set; }
        [ReadOnly(true)]
        public bool? AccountWillExpire { get; set; }
        [ReadOnly(true)]
        public DateTime? AccountExpirationDate { get; set; }
        [ReadOnly(true)]
        public bool? PasswordIsExpired { get; set; }
        [ReadOnly(true)]
        public bool? PasswordWillExpire { get; set; }
        [ReadOnly(true)]
        public DateTime? PasswordExpirationDate { get; set; }
        [ReadOnly(true)]
        public DateTime? PasswordLastSetDate { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        [ReadOnly(true)]
        public string DisplayName
        {
            get
            {
                var name = "";

                if (!String.IsNullOrWhiteSpace(FirstName))
                    name += FirstName;

                if (!String.IsNullOrWhiteSpace(LastName))
                    name += " " + LastName;

                return name;
            }
        }
        [ReadOnly(true)]
        public string SortName
        {
            get
            {
                var name = "";
                if (!String.IsNullOrWhiteSpace(LastName) && String.IsNullOrWhiteSpace(FirstName))
                    name = LastName;

                if (!String.IsNullOrWhiteSpace(LastName) && !String.IsNullOrWhiteSpace(FirstName))
                    name = LastName + ", " + FirstName;

                if (String.IsNullOrWhiteSpace(MiddleName))
                    return name;

                if (MiddleName.Length > 2)
                    name += " " + MiddleName.Remove(1) + ".";
                else
                    name += " " + MiddleName + ".";

                return name;
            }
        }
    }
}
