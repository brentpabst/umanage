using UMS.Core.Enums;
using System;

namespace UMS.Core.Data.Models.App
{
    public class PasswordNotification
    {
        public PasswordNotificationType Type { get; set; }
        public double DaysRemaining { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string AdditionalText { get; set; }
    }
}
