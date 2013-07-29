using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Security;
using PPI.UMS.AD;
using PPI.UMS.DTO;

namespace PPI.UMS.BLL
{
    [System.ComponentModel.DataObject()]
    public class Employees
    {
        #region Public

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<Employee> GetAllEmployees()
        {
            List<Employee> emps = new List<Employee>();
            Group grp = new Group();

            foreach (User user in grp.GetGroupMembers(ConfigurationManager.AppSettings["AdGroupName"].ToString()))
            {
                emps.Add(BuildEmployeeFromUser(user));
            }
            return emps.OrderBy(u => u.SortName).ToList();
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public Employee GetEmployeeByUsername(string username)
        {
            if (!String.IsNullOrWhiteSpace(username))
            {
                return BuildEmployeeFromUser(new User(username));
            }
            else
                return null;
        }

        public bool AddEmployee(Employee emp, out string retVal)
        {
            string username = Common.UiHelper.GetNewUsernameFromName(emp.FirstName, emp.MiddleName, emp.LastName, ConfigurationManager.AppSettings["NewUsernameFormat"]);
            string password = Membership.GeneratePassword(10, 3);
            
            Directory dir = new Directory();
            if (dir.CreateNewUser(username, password, AD.Common.GetDisplayName(emp.FirstName, emp.MiddleName, emp.LastName), out retVal))
            {
                // Created user, now updated properties
                User user = new User(username);
                if (user != null)
                {
                    user.FirstName = emp.FirstName;
                    user.MiddleName = emp.MiddleName;
                    user.LastName = emp.LastName;
                    user.Email = emp.Email;
                    user.Website = emp.Website;
                    user.Company = emp.Company;
                    user.Department = emp.Department;
                    user.Manager = emp.Manager;
                    user.EmployeeID = emp.EmployeeId;
                    user.JobTitle = emp.JobTitle;
                    user.Address1 = emp.Address1;
                    user.Address2 = emp.Address2;
                    user.City = emp.City;
                    user.State = emp.State;
                    user.ZipCode = emp.PostalCode;
                    user.Country = emp.Country;
                    user.OfficePhone = emp.PhoneOffice;
                    user.HomePhone = emp.PhoneHome;
                    user.MobilePhone = emp.PhoneMobile;
                    user.Pager = emp.PhonePager;
                    user.Fax = emp.PhoneFax;
                    user.SIP = emp.PhoneSip;
                    user.Office = emp.Office;
                                        
                    if (user.UpdateUser(out retVal))
                    {
                        if (emp.Picture != null)
                        {
                            if (user.SaveUserImage(emp.Picture))
                            {
                                return true;
                            }
                            else return false;
                        }
                        else return true;
                    }
                    else return true;
                }
                else return false;
            }
            else return false;
        }

        #endregion

        #region Private

        private Employee BuildEmployeeFromUser(User user)
        {
            Employee emp = new Employee();

            emp.DisplayName = user.DisplayName;
            emp.SortName = user.SortName;
            emp.FirstName = user.FirstName;
            emp.MiddleName = user.MiddleName;
            emp.LastName = user.LastName;
            emp.Email = user.Email;
            emp.Website = user.Website;
            emp.Picture = user.GetUserImage();
            emp.Office = user.Office;
            emp.Address1 = user.Address1;
            emp.Address2 = user.Address2;
            emp.City = user.City;
            emp.State = user.State;
            emp.PostalCode = user.ZipCode;
            emp.Country = user.Country;
            emp.PhoneOffice = user.OfficePhone;
            emp.PhoneHome = user.HomePhone;
            emp.PhonePager = user.Pager;
            emp.PhoneMobile = user.MobilePhone;
            emp.PhoneFax = user.Fax;
            emp.PhoneSip = user.SIP;
            emp.Company = user.Company;
            emp.Department = user.Department;
            emp.Manager = user.Manager;
            emp.EmployeeId = user.EmployeeID;
            emp.JobTitle = user.JobTitle;
            emp.Username = user.Username;
            emp.UsernameUpn = user.FullUsername;
            emp.DistinguishedName = user.DistinguishedName;
            emp.AccountStatus = Common.UiHelper.GetUserStatus(user.Username);
            emp.Notes = user.Notes;
            emp.AccountLocked = user.AccountLocked;
            emp.AccountDisabled = user.AccountDisabled;
            emp.AccountExpDate = user.AccountExpDate;
            emp.PasswordExpDate = user.PasswordExpDate;

            return emp;
        }

        #endregion
    }
}
