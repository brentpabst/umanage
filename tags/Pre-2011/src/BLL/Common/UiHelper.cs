using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using PPI.UMS.AD;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PPI.UMS.BLL.Common
{
    /// <summary>
    /// Contains all C# Logic needed in the web application
    /// </summary>
    public static class UiHelper
    {
        public static string FormatBoolean(bool input)
        {
            string retVal = "";

            if (input)
                retVal = Resources.User.Bool_Text_Yes;
            if (!input)
                retVal = Resources.User.Bool_Text_No;

            return retVal;
        }

        public static string FormatPasswordExpirationText(DateTime date)
        {
            string retVal = "";

            if (date == DateTime.MaxValue)
            {
                //Never Expires
                retVal = Resources.User.DateTime_Text_Never;
            }
            else if (date == DateTime.MinValue)
            {
                //Already Expired
                retVal = Resources.User.DateTime_Text_Expired;
            }
            else
            {
                //Has a valid expiration
                retVal = String.Format("{0:g}", date);
            }

            return retVal;
        }

        public static string FormatAccountExpirationText(DateTime date)
        {
            string retVal = "";

            if (date == DateTime.MaxValue)
            {
                //Already Expired
                retVal = Resources.User.DateTime_Text_Expired;
            }
            else if (date == DateTime.MinValue)
            {
                //Never Expires
                retVal = Resources.User.DateTime_Text_Never;
            }
            else
            {
                //Has a valid expiration
                retVal = String.Format("{0:g}", date);
            }

            return retVal;
        }

        public static string FormatPasswordExpirationText(string firstName, DateTime expDate)
        {
            string msg = "";

            if (expDate == DateTime.MaxValue)
            {
                //Password will never expire

                msg = String.Format(Resources.User.Password_Expires_Never, firstName);
            }
            if (DateTime.Now.AddMonths(1).Month >= expDate.Month)
            {
                //Password expires either next month
                msg = String.Format(Resources.User.Password_Expires_Future, firstName);
            }
            if (DateTime.Now.AddMonths(1).Month == expDate.Month)
            {
                //Password expires either next month
                msg = String.Format(Resources.User.Password_Expires_NextMonth, firstName);
            }
            if (DateTime.Now.Month == expDate.Month)
            {
                //Password Expires this month
                msg = String.Format(Resources.User.Password_Expires_ThisMonth, firstName);
            }
            if (DateTime.Now.AddDays(1).Date == expDate.Date)
            {
                //Password Expires tomorrow
                msg = String.Format(Resources.User.Password_Expires_Tomorrow, firstName);
            }
            if (DateTime.Now.Date == expDate.Date)
            {
                //Password Expires Today
                msg = String.Format(Resources.User.Password_Expires_Today, firstName);
            }

            return msg;
        }

        public static void TakeAppOffline()
        {
            //Get the app offline template and write it to the root of the site, asp.net does the rest
            try
            {
                string file = HttpContext.Current.Server.MapPath("~/App_Data/Templates/Offline.txt");
                StreamReader objReader = File.OpenText(file);
                StreamWriter objWriter = new StreamWriter(HttpContext.Current.Server.MapPath("~/App_Offline.htm"), true);
                objWriter.Write(objReader.ReadToEnd());
                objReader.Close();
                objWriter.Close();
            }
            catch
            {
                throw new IOException("Failed to read template file or create new file");
            }
        }

        public static void ProtectSection(string sectionName, string provider)
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~");

            ConfigurationSection section = config.GetSection(sectionName);

            if (section != null && !section.SectionInformation.IsProtected)
            {
                section.SectionInformation.ProtectSection(provider);
                config.Save();
            }
        }

        public static void UnProtectSection(string sectionName)
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~");

            ConfigurationSection section = config.GetSection(sectionName);

            if (section != null && section.SectionInformation.IsProtected)
            {
                section.SectionInformation.UnprotectSection();
                config.Save();
            }
        }

        public static void SendTestEmail(string host, int port, bool ssl, string from, string winAuth, string username, string password, string testUser)
        {
            string body;

            //Load the template
            try
            {
                string file = HttpContext.Current.Server.MapPath("~/App_Data/Templates/EmailTest.txt");
                StreamReader objReader = File.OpenText(file);
                body = objReader.ReadToEnd();
                objReader.Close();
            }
            catch
            {
                throw new IOException("Failed to read template file or create new file");
            }

            //Define the message
            MailMessage mm = new MailMessage(from, testUser);
            mm.Subject = "uManage Test Email";
            mm.Body = body;
            mm.IsBodyHtml = true;

            //Send the message
            try
            {
                //We need to define the smtp client since we have not saved the changes yet
                SmtpClient po = new SmtpClient(host, port);
                po.EnableSsl = ssl;

                if (winAuth == "WIN")
                {
                    po.UseDefaultCredentials = true;
                }
                else if (winAuth == "NA")
                {
                    po.UseDefaultCredentials = false;
                }
                else
                {
                    po.UseDefaultCredentials = false;
                    NetworkCredential creds = new NetworkCredential(username, password);
                    po.Credentials = creds;
                }

                po.Send(mm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetCurrentDomainName()
        {
            string retVal = "";

            retVal = ConfigurationManager.ConnectionStrings["ADService"].ConnectionString;

            retVal = retVal.Remove(0, 7);

            retVal = retVal.Remove(retVal.IndexOf("."));

            return retVal.ToUpperInvariant();
        }

        public static string GetUserStatus(string Username)
        {
            User user = new User(Username);

            DateTime exp = user.AccountExpDate;
            bool Expired = false;

            if (exp == DateTime.MaxValue || (exp <= DateTime.Now && exp != DateTime.MinValue))
                Expired = true;

            if (user.AccountLocked)
                return "Locked Out";
            else if (user.AccountDisabled)
                return "Disabled";
            else if (Expired)
                return "Expired";
            else return "Active";
        }

        public static string GetNewUsernameFromName(string FirstName, string MiddleName, string LastName, string FormatString)
        {
            string first = FirstName;
            string firstInitial = FirstName.Substring(0, 1);

            string middle = "";
            string middleInitial = "";

            if (MiddleName != String.Empty || MiddleName.Length > 0)
            {
                middle = MiddleName;
                middleInitial = MiddleName.Substring(0, 1);
            }

            string last = LastName;
            string lastInitial = LastName.Substring(0, 1);

            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("$fname$", first);
            dic.Add("$fi$", firstInitial);
            dic.Add("$mname$", middle);
            dic.Add("$mi$", middleInitial);
            dic.Add("$lname$", last);
            dic.Add("$li$", lastInitial);

            // Do the replacement
            // Run the replacements against the template
            Regex re = new Regex(@"\$(\w+)\$", RegexOptions.Compiled);
            return re.Replace(FormatString, match => dic[match.Groups[0].Value]);
        }
    }
}