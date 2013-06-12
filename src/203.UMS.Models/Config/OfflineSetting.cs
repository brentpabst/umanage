using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using _203.UMS.Annotations;

namespace _203.UMS.Models.Config
{
    public class OfflineSetting
    {
        [Mandatory(ErrorMessage = "You must check this box to take the application offline.")]
        [Display(Name = "Take Application Offline?")]
        public bool TakeOffline { get; set; }

        [Display(Name = "Message:")]
        [AllowHtml]
        public string Message { get; set; }
    }
}
