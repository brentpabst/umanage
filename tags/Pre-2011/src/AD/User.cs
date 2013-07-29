using System;
using System.Configuration;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace PPI.UMS.AD
{
    public class User
    {
        #region Properties

        private PrincipalContext context;
        private UserPrincipal userPrincipal;

        public string DisplayName { get; set; }
        public string SortName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Office { get; set; }
        public string OfficePhone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Pager { get; set; }
        public string MobilePhone { get; set; }
        public string Fax { get; set; }
        public string SIP { get; set; }
        public string EmployeeID { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Company { get; set; }
        public string Manager { get; set; }
        public string Username { get; set; }
        public string FullUsername { get; set; }
        public string DistinguishedName { get; set; }
        public string Notes { get; set; }
        public byte[] Photo { get; set; }
        public bool AccountLocked { get; set; }
        public bool AccountDisabled { get; set; }
        public DateTime AccountExpDate { get; set; }
        public DateTime PasswordExpDate { get; set; }

        #endregion

        #region Constructors

        public User() { }

        public User(string Username)
        {
            if (String.IsNullOrWhiteSpace(Username))
            {
                throw new ApplicationException("No username was specified.  uManage cannot ask the domain controller for a null user!");
            }

            ProviderSettings ps = Common.GetWebMembershipDetails();

            if (ps.Parameters.HasKeys())
            {
                this.context = new PrincipalContext(ContextType.Domain, Common.GetDomainName(ConfigurationManager.ConnectionStrings["ADService"]), null, ContextOptions.Negotiate, ps.Parameters["connectionUsername"], ps.Parameters["connectionPassword"]);
                this.userPrincipal = UserPrincipal.FindByIdentity(context, Username);

                if (this.userPrincipal != null)
                {
                    //Populate this object with the user's info
                    BuildUserFromPrincipal(userPrincipal);
                }
            }
            else
            {
                throw new ApplicationException("The configuration information for the domain could not be read!");
            }
        }

        #endregion

        #region Public

        public bool UpdateUser(out string result)
        {
            bool retVal = false;
            result = "";

            //Update and Validate the principal object
            if (String.IsNullOrWhiteSpace(this.FirstName))
            {
                result = "Cannot have an empty name!";
                return retVal;
            }
            else
            {
                userPrincipal.GivenName = this.FirstName;
            }

            if (!String.IsNullOrWhiteSpace(this.MiddleName))
                userPrincipal.MiddleName = this.MiddleName;
            else
                userPrincipal.MiddleName = null;

            if (String.IsNullOrWhiteSpace(this.FirstName))
            {
                result = "Cannot have an empty name!";
                return retVal;
            }
            else
            {
                userPrincipal.Surname = this.LastName;
            }

            //Get the display name
            this.DisplayName = Common.GetDisplayName(this.FirstName, this.MiddleName, this.LastName);
            if (!String.IsNullOrWhiteSpace(this.DisplayName))
            {
                userPrincipal.DisplayName = this.DisplayName;
            }
            else
                userPrincipal.DisplayName = null;

            if (!String.IsNullOrWhiteSpace(this.OfficePhone))
                userPrincipal.VoiceTelephoneNumber = this.OfficePhone;
            else
                userPrincipal.VoiceTelephoneNumber = null;

            if (!String.IsNullOrWhiteSpace(this.Email))
                userPrincipal.EmailAddress = this.Email;
            else
                userPrincipal.EmailAddress = null;

            //Save the easy ones
            try
            {
                userPrincipal.Save();
                retVal = true;
            }
            catch (Exception e)
            {
                retVal = false;
                result = e.GetBaseException().Message + "<br/>" + e.GetBaseException().StackTrace;
            }

            //Get the complex values
            if (userPrincipal.GetUnderlyingObjectType() == typeof(DirectoryEntry))
            {
                DirectoryEntry entry = (DirectoryEntry)userPrincipal.GetUnderlyingObject();

                if (!String.IsNullOrWhiteSpace(this.MiddleName))
                    if (this.MiddleName.Length > 1)
                        entry.Properties["initials"].Value = this.MiddleName.Remove(1);
                    else
                        entry.Properties["initials"].Value = this.MiddleName;
                else
                    entry.Properties["initials"].Value = null;

                if (!String.IsNullOrWhiteSpace(this.Address1))
                    entry.Properties["streetAddress"].Value = this.Address1;
                else
                    entry.Properties["streetAddress"].Value = null;

                if (!String.IsNullOrWhiteSpace(this.Office))
                    entry.Properties["physicalDeliveryOfficeName"].Value = this.Office;
                else
                    entry.Properties["physicalDeliveryOfficeName"].Value = null;

                if (!String.IsNullOrWhiteSpace(this.Website))
                    entry.Properties["wWWHomePage"].Value = this.Website;
                else
                    entry.Properties["wWWHomePage"].Value = null;

                if (!String.IsNullOrWhiteSpace(this.Address2))
                    entry.Properties["postOfficeBox"].Value = this.Address2;
                else
                    entry.Properties["postOfficeBox"].Value = null;

                if (!String.IsNullOrWhiteSpace(this.City))
                    entry.Properties["l"].Value = this.City;
                else
                    entry.Properties["l"].Value = null;

                if (!String.IsNullOrWhiteSpace(this.State))
                    entry.Properties["st"].Value = this.State;
                else
                    entry.Properties["st"].Value = null;

                if (!String.IsNullOrWhiteSpace(this.ZipCode))
                    entry.Properties["postalCode"].Value = this.ZipCode;
                else
                    entry.Properties["postalCode"].Value = null;

                if (!String.IsNullOrWhiteSpace(this.Country))
                    entry.Properties["c"].Value = this.Country;
                else
                    entry.Properties["c"].Value = null;

                if (!String.IsNullOrWhiteSpace(this.HomePhone))
                    entry.Properties["homephone"].Value = this.HomePhone;
                else
                    entry.Properties["homephone"].Value = null;

                if (!String.IsNullOrWhiteSpace(this.Pager))
                    entry.Properties["pager"].Value = this.Pager;
                else
                    entry.Properties["pager"].Value = null;

                if (!String.IsNullOrWhiteSpace(this.MobilePhone))
                    entry.Properties["mobile"].Value = this.MobilePhone;
                else
                    entry.Properties["mobile"].Value = null;

                if (!String.IsNullOrWhiteSpace(this.Fax))
                    entry.Properties["facsimileTelephoneNumber"].Value = this.Fax;
                else
                    entry.Properties["facsimileTelephoneNumber"].Value = null;

                if (!String.IsNullOrWhiteSpace(this.SIP))
                    entry.Properties["ipPhone"].Value = this.SIP;
                else
                    entry.Properties["ipPhone"].Value = null;

                if (!String.IsNullOrWhiteSpace(this.EmployeeID))
                    entry.Properties["employeeID"].Value = this.EmployeeID;
                else
                    entry.Properties["employeeID"].Value = null;

                if (!String.IsNullOrWhiteSpace(this.JobTitle))
                    entry.Properties["title"].Value = this.JobTitle;
                else
                    entry.Properties["title"].Value = null;

                if (!String.IsNullOrWhiteSpace(this.Department))
                    entry.Properties["department"].Value = this.Department;
                else
                    entry.Properties["department"].Value = null;

                if (!String.IsNullOrWhiteSpace(this.Company))
                    entry.Properties["company"].Value = this.Company;
                else
                    entry.Properties["company"].Value = null;

                if (!String.IsNullOrWhiteSpace(this.Manager))
                    entry.Properties["manager"].Value = this.Manager;
                else
                    entry.Properties["manager"].Value = null;

                if (!String.IsNullOrWhiteSpace(this.Notes))
                    entry.Properties["info"].Value = this.Notes;
                else
                    entry.Properties["info"].Value = null;

                //Save the hard ones
                try
                {
                    entry.CommitChanges();
                    userPrincipal.Save();
                }
                catch (Exception ex)
                {
                    retVal = false;
                    result = ex.GetBaseException().Message + "<br/>" + ex.GetBaseException().StackTrace;
                }
            }

            return retVal;
        }

        public bool ChangeUserPassword(string oldPass, string newPass, string confPass, out string result)
        {
            bool retVal = false;
            result = "";
            //Make sure the new passwords match
            if (newPass != confPass)
            {
                result = "The passwords did not match";
                return false;
            }

            //Attempt to update the password
            try
            {
                userPrincipal.ChangePassword(oldPass, newPass);
                retVal = true;
            }
            catch (PasswordException)
            {
                result = "The password supplier is not complex enough";
                retVal = false;
            }

            return retVal;
        }

        public bool SaveUserImage(Byte[] Photo)
        {
            bool retVal = false;

            //Clean up the image and re-size it so we save on space
            if (Photo != null)
            {
                byte[] photoToSave;
                using (MemoryStream ms = new MemoryStream(Photo))
                {
                    //Create Image Object
                    Image userPhoto = Image.FromStream(ms);

                    //Figure out the right height so it looks proportional
                    decimal ratio = (decimal)256 / userPhoto.Width;
                    int newHeight = 0;

                    newHeight = Convert.ToInt32(userPhoto.Height * ratio);

                    //Create a thumbnail
                    Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                    Image newThumb = userPhoto.GetThumbnailImage(256, newHeight, myCallback, IntPtr.Zero);

                    using (MemoryStream msSizer = new MemoryStream())
                    {
                        newThumb.Save(msSizer, ImageFormat.Png);
                        photoToSave = msSizer.ToArray();
                    }
                }
                //Save it to the Domain
                if (userPrincipal.GetUnderlyingObjectType() == typeof(DirectoryEntry))
                {
                    DirectoryEntry entry = (DirectoryEntry)userPrincipal.GetUnderlyingObject();

                    if (photoToSave != null)
                        entry.Properties["jpegPhoto"].Value = photoToSave;
                    else
                        entry.Properties["jpegPhoto"].Value = null;

                    //Save the hard ones
                    try
                    {
                        entry.CommitChanges();
                        retVal = true;
                    }
                    catch (Exception)
                    {
                        retVal = false;
                    }
                }
            }
            else
            {
                retVal = false;
            }

            return retVal;
        }

        public bool ClearUserImage()
        {
            bool retVal = false;

            if (userPrincipal.GetUnderlyingObjectType() == typeof(DirectoryEntry))
            {
                DirectoryEntry entry = (DirectoryEntry)userPrincipal.GetUnderlyingObject();

                entry.Properties["jpegPhoto"].Value = null;

                //Save the hard ones
                try
                {
                    entry.CommitChanges();
                    retVal = true;
                }
                catch (Exception)
                {
                    retVal = false;
                }
            }

            return retVal;
        }

        public byte[] GetUserImage()
        {
            byte[] retVal;

            DirectoryEntry entry = (DirectoryEntry)this.userPrincipal.GetUnderlyingObject();

            byte[] photo = (byte[])entry.Properties["jpegPhoto"].Value;

            if (photo == null)
            {
                //Image does not exist
                Image noThumb = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/User-256.png"));

                using (MemoryStream ms = new MemoryStream())
                {
                    noThumb.Save(ms, ImageFormat.Png);
                    retVal = ms.ToArray();
                }
            }
            else
            {
                //Stream the photo
                using (MemoryStream ms = new MemoryStream(photo))
                {
                    //Create Image Object
                    Image userThumb = Image.FromStream(ms);

                    //Figure out the right height so it looks proportional
                    decimal ratio = (decimal)256 / userThumb.Width;
                    int newHeight = 0;

                    newHeight = Convert.ToInt32(userThumb.Height * ratio);

                    //Create a thumbnail
                    Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                    Image newThumb = userThumb.GetThumbnailImage(256, newHeight, myCallback, IntPtr.Zero);

                    using (MemoryStream msSizer = new MemoryStream())
                    {
                        newThumb.Save(msSizer, ImageFormat.Png);
                        retVal = msSizer.ToArray();
                    }
                }
            }
            return retVal;
        }

        public byte[] GetUserImageThumbnail()
        {
            byte[] thumb;

            DirectoryEntry entry = (DirectoryEntry)this.userPrincipal.GetUnderlyingObject();

            byte[] photo = (byte[])entry.Properties["jpegPhoto"].Value;

            if (photo == null)
            {
                //Image does not exist
                Image noThumb = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/User-48.png"));

                using (MemoryStream ms = new MemoryStream())
                {
                    noThumb.Save(ms, ImageFormat.Png);
                    thumb = ms.ToArray();
                }
            }
            else
            {
                //Stream the photo
                using (MemoryStream ms = new MemoryStream(photo))
                {
                    //Create Image Object
                    Image userThumb = Image.FromStream(ms);

                    //Figure out the right height so it looks proportional
                    decimal ratio = (decimal)48 / userThumb.Width;
                    int newHeight = 0;

                    newHeight = Convert.ToInt32(userThumb.Height * ratio);

                    //Create a thumbnail
                    Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                    Image newThumb = userThumb.GetThumbnailImage(48, newHeight, myCallback, IntPtr.Zero);

                    using (MemoryStream msSizer = new MemoryStream())
                    {
                        newThumb.Save(msSizer, ImageFormat.Png);
                        thumb = msSizer.ToArray();
                    }
                }
            }
            return thumb;
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        #endregion

        #region Private        

        private void BuildUserFromPrincipal(UserPrincipal user)
        {
            //Populate the user with items available in the UserPrincipal object
            if (user != null)
            {
                this.DisplayName = user.DisplayName;
                this.SortName = user.Surname + ", " + user.GivenName + " " + user.MiddleName;
                this.FullUsername = user.UserPrincipalName;
                this.Username = user.SamAccountName;
                this.FirstName = user.GivenName;
                this.MiddleName = user.MiddleName;
                this.LastName = user.Surname;
                this.OfficePhone = user.VoiceTelephoneNumber;
                this.Email = user.EmailAddress;

                if (user.Enabled.HasValue)
                    this.AccountDisabled = (bool)user.Enabled ? false : true;

                if (user.AccountExpirationDate.HasValue)
                    this.AccountExpDate = (DateTime)user.AccountExpirationDate;

                if (user.AccountLockoutTime.HasValue)
                    this.AccountLocked = true;

                //Get the complex values
                if (user.GetUnderlyingObjectType() == typeof(DirectoryEntry))
                {
                    DirectoryEntry entry = (DirectoryEntry)user.GetUnderlyingObject();
                    PasswordExpires pe = new PasswordExpires();

                    this.PasswordExpDate = pe.GetExpiration(entry);
                    if (entry.Properties["distinguishedName"].Value != null)
                        this.DistinguishedName = entry.Properties["distinguishedName"].Value.ToString();
                    if (entry.Properties["streetAddress"].Value != null)
                        this.Address1 = entry.Properties["streetAddress"].Value.ToString();
                    if (entry.Properties["physicalDeliveryOfficeName"].Value != null)
                        this.Office = entry.Properties["physicalDeliveryOfficeName"].Value.ToString();
                    if (entry.Properties["wWWHomePage"].Value != null)
                        this.Website = entry.Properties["wWWHomePage"].Value.ToString();
                    if (entry.Properties["postOfficeBox"].Value != null)
                        this.Address2 = entry.Properties["postOfficeBox"].Value.ToString();
                    if (entry.Properties["l"].Value != null)
                        this.City = entry.Properties["l"].Value.ToString();
                    if (entry.Properties["st"].Value != null)
                        this.State = entry.Properties["st"].Value.ToString();
                    if (entry.Properties["postalCode"].Value != null)
                        this.ZipCode = entry.Properties["postalCode"].Value.ToString();
                    if (entry.Properties["c"].Value != null)
                        this.Country = entry.Properties["c"].Value.ToString();
                    if (entry.Properties["homephone"].Value != null)
                        this.HomePhone = entry.Properties["homephone"].Value.ToString();
                    if (entry.Properties["pager"].Value != null)
                        this.Pager = entry.Properties["pager"].Value.ToString();
                    if (entry.Properties["mobile"].Value != null)
                        this.MobilePhone = entry.Properties["mobile"].Value.ToString();
                    if (entry.Properties["facsimileTelephoneNumber"].Value != null)
                        this.Fax = entry.Properties["facsimileTelephoneNumber"].Value.ToString();
                    if (entry.Properties["ipPhone"].Value != null)
                        this.SIP = entry.Properties["ipPhone"].Value.ToString();
                    if (entry.Properties["employeeID"].Value != null)
                        this.EmployeeID = entry.Properties["employeeID"].Value.ToString();
                    if (entry.Properties["title"].Value != null)
                        this.JobTitle = entry.Properties["title"].Value.ToString();
                    if (entry.Properties["department"].Value != null)
                        this.Department = entry.Properties["department"].Value.ToString();
                    if (entry.Properties["company"].Value != null)
                        this.Company = entry.Properties["company"].Value.ToString();
                    if (entry.Properties["manager"].Value != null)
                        this.Manager = entry.Properties["manager"].Value.ToString();
                    if (entry.Properties["info"].Value != null)
                        this.Notes = entry.Properties["info"].Value.ToString();
                }
            }
        }

        #endregion
    }
}
