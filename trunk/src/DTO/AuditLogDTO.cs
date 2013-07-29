namespace THS.UMS.DTO
{
    using System;

    public class AuditLogDTO
    {
        public Guid LogId { get; set; }
        public DateTime LogDate { get; set; }
        public DateTime LogDateUtc { get; set; }
        public string SubmittedBy { get; set; }
        public string UpnUsername { get; set; }

        public string FirstName_Old { get; set; }
        public string MiddleName_Old { get; set; }
        public string LastName_Old { get; set; }
        public string Email_Old { get; set; }
        public string Website_Old { get; set; }
        public string JobTitle_Old { get; set; }
        public string Office_Old { get; set; }
        public string Company_Old { get; set; }
        public string Department_Old { get; set; }
        public string EmployeeId_Old { get; set; }
        public string Manager_Old { get; set; }
        public string Address1_Old { get; set; }
        public string Address2_Old { get; set; }
        public string City_Old { get; set; }
        public string PostalCode_Old { get; set; }
        public string Province_Old { get; set; }
        public string Country_Old { get; set; }
        public string HomePhone_Old { get; set; }
        public string OfficePhone_Old { get; set; }
        public string Pager_Old { get; set; }
        public string MobilePhone_Old { get; set; }
        public string Fax_Old { get; set; }
        public string SipPhone_Old { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string JobTitle { get; set; }
        public string Office { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string EmployeeId { get; set; }
        public string Manager { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string OfficePhone { get; set; }
        public string Pager { get; set; }
        public string MobilePhone { get; set; }
        public string Fax { get; set; }
        public string SipPhone { get; set; }
    }
}
