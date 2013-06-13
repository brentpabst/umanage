using System.ComponentModel.DataAnnotations;

namespace _203.UMS.Models.Directory
{
    public class PasswordReminderSetting
    {
        [Required]
        public double Reminder { get; set; }

        public string ReminderText { get; set; }

        [Required]
        public double Warning { get; set; }

        public string WarningText { get; set; }

        [Required]
        public double Error { get; set; }

        public string ErrorText { get; set; }
    }
}
