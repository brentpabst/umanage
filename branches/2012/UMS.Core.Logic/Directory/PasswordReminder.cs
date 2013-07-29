using UMS.Core.Data.Models.Directory;

namespace UMS.Core.Logic.Directory
{
    public class PasswordReminder
    {
        public static PasswordReminderSetting GetSettings()
        {
            return new PasswordReminderSetting
                {
                    Reminder = Config.Settings.Get<double>("PasswordNotificationReminder"),
                    ReminderText = Config.Settings.Get<string>("PasswordNotificationReminderText"),
                    Warning = Config.Settings.Get<double>("PasswordNotificationWarning"),
                    WarningText = Config.Settings.Get<string>("PasswordNotificationWarningText"),
                    Error = Config.Settings.Get<double>("PasswordNotificationError"),
                    ErrorText = Config.Settings.Get<string>("PasswordNotificationErrorText")
                };
        }

        public static bool UpdateSettings(PasswordReminderSetting settings)
        {
            try
            {
                Config.Settings.Put("PasswordNotificationReminder", settings.Reminder);
                Config.Settings.Put("PasswordNotificationReminderText", settings.ReminderText);
                Config.Settings.Put("PasswordNotificationWarning", settings.Warning);
                Config.Settings.Put("PasswordNotificationWarningText", settings.WarningText);
                Config.Settings.Put("PasswordNotificationError", settings.Error);
                Config.Settings.Put("PasswordNotificationErrorText", settings.ErrorText);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
