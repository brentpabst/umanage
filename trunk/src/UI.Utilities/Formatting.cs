namespace THS.UMS.UI.Utilities
{
    using System;

    public static class Formatting
    {
        /// <summary>
        /// Formats the password expiration.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="expDate">The exp date.</param>
        /// <returns></returns>
        public static string FormatPasswordExpiration(string firstName, DateTime expDate)
        {
            string msg = "";

            if (expDate == DateTime.MaxValue)
            {
                //Password will never expire

                msg = String.Format("{0}, your password will never expire.", firstName);
            }
            if (DateTime.Now.AddMonths(1) >= expDate)
            {
                //Password expires either next month
                msg = String.Format("{0}, your password will not expire for a while.", firstName);
            }
            if (DateTime.Now.AddMonths(1) == expDate && DateTime.Now.Year == expDate.Year)
            {
                //Password expires either next month
                msg = String.Format("{0}, your password will expire next month.", firstName);
            }
            if (DateTime.Now.Month == expDate.Month && DateTime.Now.Year == expDate.Year)
            {
                //Password Expires this month
                msg = String.Format("{0}, your password will expire this month.", firstName);
            }
            if (DateTime.Now.AddDays(1).Date == expDate.Date)
            {
                //Password Expires tomorrow
                msg = String.Format("{0}, your password will expire <span style=\"color:red;\">tomorrow!</span>", firstName);
            }
            if (DateTime.Now.Date == expDate.Date)
            {
                //Password Expires Today
                msg = String.Format("{0}, your password will expire <span style=\"color:red;\">today!</span>", firstName);
            }

            return msg;
        }

        /// <summary>
        /// Formats the password expiration.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static string FormatPasswordExpiration(DateTime date)
        {
            string msg;

            if (date == DateTime.MaxValue)
            {
                //Never Expires
                msg = "Never";
            }
            else if (date == DateTime.MinValue)
            {
                //Already Expired
                msg = "Expired";
            }
            else
            {
                //Has a valid expiration
                msg = String.Format("{0:g}", date);
            }

            return msg;
        }

        /// <summary>
        /// Formats the account expiration.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static string FormatAccountExpiration(DateTime date)
        {
            string msg;

            if (date == DateTime.MaxValue)
            {
                //Never Expires
                msg = "Never";
            }
            else if (date == DateTime.MinValue || date <= DateTime.Now)
            {
                //Already Expired
                msg = "Expired";
            }
            else
            {
                //Has a valid expiration
                msg = String.Format("{0:g}", date);
            }

            return msg;
        }

        /// <summary>
        /// Formats a Boolean.
        /// </summary>
        /// <param name="val">if set to <c>true</c> [val].</param>
        /// <returns></returns>
        public static string FormatBoolean(bool val)
        {
            if (val)
                return "Yes";
            return "No";
        }
    }
}
