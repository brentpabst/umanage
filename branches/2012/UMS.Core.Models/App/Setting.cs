using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace UMS.Core.Data.Models.App
{
    public class Setting
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Setting ID", ShortName = "ID")]
        public Guid SettingId { get; set; }

        [Required(ErrorMessage = "You must specify the key for the setting.")]
        [StringLength(50, ErrorMessage = "The key cannot be longer than {0} characters.")]
        [Display(Name = "Key")]
        public string Key { get; set; }

        [Required(ErrorMessage = "You must specify the value for the setting.")]
        [StringLength(2048, ErrorMessage = "The value cannot be longer than {0} characters.")]
        [Display(Name = "Value")]
        public string Value { get; set; }
        
        [Display(Name="Is Encrypted")]
        public bool IsEncrypted { get; set; }
    }
}
