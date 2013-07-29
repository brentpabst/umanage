using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPI.UMS.Web.Forms.Admin.Config
{
    public partial class Conf_Dash : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        string lastDateValue = "";

        protected string AddGroupingRowIfDateHasChanged()
        {
            string retVal = "";

            //Get the data field value of interest for this row
            string currentDateValue = String.Format("{0:D}", Eval("CreatedOn"));

            //Set what to show if null
            if (String.IsNullOrWhiteSpace(currentDateValue))
            {
                currentDateValue = "Unknown";
            }

            //Check for a change
            if (lastDateValue != currentDateValue)
            {
                //Change found
                lastDateValue = currentDateValue;
                retVal = String.Format("<tr class=\"timeline-group\"><td colspan=\"4\">{0}</td></tr><tr><td class=\"timeline-group-spacer\" colspan=\"4\">&nbsp;</td></tr>", currentDateValue);
            }

            return retVal;
        }

        protected string TimeFormat()
        {
            string retVal = "";

            DateTime time = (DateTime)Eval("CreatedOn");

            if (time.Date == DateTime.UtcNow.Date)
            {
                //This is today... format it differently
                //Get the diff between now and then
                TimeSpan span = DateTime.UtcNow.Subtract(time);

                if (span.Hours != 0)
                {
                    //Couple hours difference
                    retVal = span.Hours.ToString() + " " + Resources.Global.Time_HoursAgo.ToLower();
                }
                else if (span.Minutes != 0)
                {
                    //Couple minutes difference
                    retVal = span.Minutes.ToString() + " " + Resources.Global.Time_MinutesAgo.ToLower();
                }
                else
                {
                    //Just done!
                    retVal = span.Seconds.ToString() + " " + Resources.Global.Time_SecondsAgo.ToLower();
                }
            }
            else
            {
                retVal = time.ToShortTimeString() + " UTC";
            }

            return retVal;
        }

        protected string GetUserImage()
        {
            //TODO: Build this out to pull the user's picture from AD if it exists
            return "~/Images/User-48.png";
        }

        protected string UserFullName()
        {
            AD.User user = new AD.User(Eval("CreatedBy").ToString());
            if (!String.IsNullOrWhiteSpace(user.DisplayName))
            {
                return user.DisplayName;
            }
            else
            {
                return "Unknown";
            }
        }
    }
}