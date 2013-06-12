using System.ComponentModel.DataAnnotations;
using _203.UMS.Annotations;

namespace _203.UMS.Models.Directory
{
    public class PasswordReminderSetting
    {
        [Required]
        [GreaterThan("Warning", false, "Reminder period must be greater than the Warning Period.", true)]
        [Display(Name = "Show/Send a Reminder After")]
        public double Reminder { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Additional Reminder Instructions")]
        public string ReminderText { get; set; }

        [Required]
        [GreaterThan("Error", false, "Warning period must be greater than the Error Period.", true)]
        [Display(Name = "Show/Send a Warning After")]
        public double Warning { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Additional Warning Instructions")]
        public string WarningText { get; set; }

        [Required]
        [Display(Name = "Show/Send an Error After")]
        public double Error { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Additional Error Instructions")]
        public string ErrorText { get; set; }
    }
}
