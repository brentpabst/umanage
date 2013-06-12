using System;
using _203.UMS.Enums;

namespace _203.UMS.Models.App
{
    public class PasswordNotification
    {
        public PasswordNotificationType Type { get; set; }
        public double DaysRemaining { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string AdditionalText { get; set; }
    }
}
