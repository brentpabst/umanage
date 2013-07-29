using System;
using UMS.Core.Data.Models.App;
using UMS.Core.Enums;
using User = UMS.Core.Data.Models.Directory.User;

namespace UMS.Core.Logic.App
{
    public class Users
    {
        public static PasswordNotification GetPasswordNotification(User user)
        {
            var daysRemaining = 0.0;
            var expirationDate = user.PasswordExpiresOn;
            var type = PasswordNotificationType.None;
            var additionalText = "";

            var reminder = Config.Settings.Get<int>("PasswordNotificationReminder");
            var warning = Config.Settings.Get<int>("PasswordNotificationWarning");
            var error = Config.Settings.Get<int>("PasswordNotificationError");

            // If the expiration date is less than or equal to UTC now the 
            // password has expired, no point in showing a message

            // If the expiration date is equal to the max value of a date time
            // the password never expires, no need for a message.

            if (expirationDate > DateTime.UtcNow && expirationDate != DateTime.MaxValue)
            {
                daysRemaining = (expirationDate - DateTime.UtcNow).TotalDays;

                if (reminder > 0 && daysRemaining <= reminder && daysRemaining > warning)
                {
                    type = PasswordNotificationType.Reminder;
                }

                if (warning > 0 && daysRemaining <= warning && daysRemaining > error)
                {
                    type = PasswordNotificationType.Warning;
                }

                if (error > 0 && daysRemaining <= error)
                {
                    type = PasswordNotificationType.Error;
                }
            }

            switch (type)
            {
                case PasswordNotificationType.Reminder:
                    additionalText = Config.Settings.Get<string>("PasswordNotificationReminderText");
                    break;
                case PasswordNotificationType.Warning:
                    additionalText = Config.Settings.Get<string>("PasswordNotificationWarningText");
                    break;
                case PasswordNotificationType.Error:
                    additionalText = Config.Settings.Get<string>("PasswordNotificationErrorText");
                    break;
            }

            return new PasswordNotification
                {
                    Type = type,
                    DaysRemaining = daysRemaining,
                    ExpirationDate = expirationDate,
                    AdditionalText = additionalText
                };
        }
    }
}
