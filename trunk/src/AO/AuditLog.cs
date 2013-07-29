namespace THS.UMS.AO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using THS.UMS.DTO;
    using THS.UMS.EF;

    public class AuditLog
    {
        public bool SaveAuditLog(EmployeeDTO old, EmployeeDTO current)
        {
            using (var ctx = new AppEntities())
            {
                var l = new EF.AuditLog
                            {
                                LogId = Guid.NewGuid(),
                                LogDate = DateTime.Now,
                                LogDateUtc = DateTime.UtcNow,
                                SubmittedBy = HttpContext.Current.User.Identity.Name,
                                UpnUsername = current.UpnUsername,
                                FirstName_Old = old.FirstName,
                                MiddleName_Old = old.MiddleName,
                                LastName_Old = old.LastName,
                                Email_Old = old.Email,
                                Website_Old = old.Website,
                                JobTitle_Old = old.JobTitle,
                                Office_Old = old.Office,
                                Company_Old = old.Company,
                                Department_Old = old.Department,
                                EmployeeId_Old = old.EmployeeId,
                                Manager_Old = old.Manager == null ? null : old.Manager.DisplayName,
                                Address1_Old = old.Address1,
                                Address2_Old = old.Address2,
                                City_Old = old.City,
                                PostalCode_Old = old.PostalCode,
                                Province_Old = old.Province,
                                Country_Old = old.Country,
                                HomePhone_Old = old.HomePhone,
                                OfficePhone_Old = old.OfficePhone,
                                Pager_Old = old.Pager,
                                MobilePhone_Old = old.MobilePhone,
                                Fax_Old = old.Fax,
                                SipPhone_Old = old.SipPhone,
                                FirstName = String.IsNullOrWhiteSpace(current.FirstName) ? null : current.FirstName,
                                MiddleName = String.IsNullOrWhiteSpace(current.MiddleName) ? null : current.MiddleName,
                                LastName = String.IsNullOrWhiteSpace(current.LastName) ? null : current.LastName,
                                Email = String.IsNullOrWhiteSpace(current.Email) ? null : current.Email,
                                Website = String.IsNullOrWhiteSpace(current.Website) ? null : current.Website,
                                JobTitle = String.IsNullOrWhiteSpace(current.JobTitle) ? null : current.JobTitle,
                                Office = String.IsNullOrWhiteSpace(current.Office) ? null : current.Office,
                                Company = String.IsNullOrWhiteSpace(current.Company) ? null : current.Company,
                                Department = String.IsNullOrWhiteSpace(current.Department) ? null : current.Department,
                                EmployeeId = String.IsNullOrWhiteSpace(current.EmployeeId) ? null : current.EmployeeId,
                                Manager = current.Manager == null ? null : current.Manager.DisplayName,
                                Address1 = String.IsNullOrWhiteSpace(current.Address1) ? null : current.Address1,
                                Address2 = String.IsNullOrWhiteSpace(current.Address2) ? null : current.Address2,
                                City = String.IsNullOrWhiteSpace(current.City) ? null : current.City,
                                PostalCode = String.IsNullOrWhiteSpace(current.PostalCode) ? null : current.PostalCode,
                                Province = String.IsNullOrWhiteSpace(current.Province) ? null : current.Province,
                                Country = String.IsNullOrWhiteSpace(current.Country) ? null : current.Country,
                                HomePhone = String.IsNullOrWhiteSpace(current.HomePhone) ? null : current.HomePhone,
                                OfficePhone = String.IsNullOrWhiteSpace(current.OfficePhone) ? null : current.OfficePhone,
                                Pager = String.IsNullOrWhiteSpace(current.Pager) ? null : current.Pager,
                                MobilePhone = String.IsNullOrWhiteSpace(current.MobilePhone) ? null : current.MobilePhone,
                                Fax = String.IsNullOrWhiteSpace(current.Fax) ? null : current.Fax,
                                SipPhone = String.IsNullOrWhiteSpace(current.SipPhone) ? null : current.SipPhone
                            };
                try
                {
                    ctx.AuditLogs.AddObject(l);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public List<AuditLogDTO> GetLastAuditLogs()
        {
            using (var ctx = new AppEntities())
            {
                var log = new List<AuditLogDTO>();
                foreach (var l in ctx.AuditLogs.OrderByDescending(l => l.LogDate).Take(50))
                {
                    log.Add(BuildAuditLogFromEntity(l));
                }
                return log;
            }
        }

        public AuditLogDTO GetAuditLog(Guid id)
        {
            using (var ctx = new AppEntities())
            {
                return BuildAuditLogFromEntity(ctx.AuditLogs.Where(l => l.LogId == id).FirstOrDefault());
            }
        }

        private static AuditLogDTO BuildAuditLogFromEntity(EF.AuditLog l)
        {
            if (l == null) return null;
            return new AuditLogDTO
            {
                LogId = l.LogId,
                LogDate = l.LogDate,
                LogDateUtc = l.LogDateUtc,
                SubmittedBy = l.SubmittedBy,
                UpnUsername = l.UpnUsername,
                FirstName_Old = l.FirstName_Old,
                MiddleName_Old = l.MiddleName_Old,
                LastName_Old = l.LastName_Old,
                Email_Old = l.Email_Old,
                Website_Old = l.Website_Old,
                JobTitle_Old = l.JobTitle_Old,
                Office_Old = l.Office_Old,
                Company_Old = l.Company_Old,
                Department_Old = l.Department_Old,
                EmployeeId_Old = l.EmployeeId_Old,
                Manager_Old = l.Manager_Old,
                Address1_Old = l.Address1_Old,
                Address2_Old = l.Address2_Old,
                City_Old = l.City_Old,
                PostalCode_Old = l.PostalCode_Old,
                Province_Old = l.Province_Old,
                Country_Old = l.Country_Old,
                HomePhone_Old = l.HomePhone_Old,
                OfficePhone_Old = l.OfficePhone_Old,
                Pager_Old = l.Pager_Old,
                MobilePhone_Old = l.MobilePhone_Old,
                Fax_Old = l.Fax_Old,
                SipPhone_Old = l.SipPhone_Old,
                FirstName = l.FirstName,
                MiddleName = l.MiddleName,
                LastName = l.LastName,
                Email = l.Email,
                Website = l.Website,
                JobTitle = l.JobTitle,
                Office = l.Office,
                Company = l.Company,
                Department = l.Department,
                EmployeeId = l.EmployeeId,
                Manager = l.Manager,
                Address1 = l.Address1,
                Address2 = l.Address2,
                City = l.City,
                PostalCode = l.PostalCode,
                Province = l.Province,
                Country = l.Country,
                HomePhone = l.HomePhone,
                OfficePhone = l.OfficePhone,
                Pager = l.Pager,
                MobilePhone = l.MobilePhone,
                Fax = l.Fax,
                SipPhone = l.SipPhone
            };
        }
    }
}
