using System;
using System.ComponentModel.DataAnnotations;

namespace _203.UMS.Models.App
{
    public class Setting
    {
        [Key]
        public Guid SettingId { get; set; }

        [Required(ErrorMessage = "You must specify the key for the setting.")]
        [StringLength(50, ErrorMessage = "The key cannot be longer than {0} characters.")]
        public string Key { get; set; }

        [StringLength(2048, ErrorMessage = "The value cannot be longer than {0} characters.")]
        public string Value { get; set; }

        [StringLength(2050, ErrorMessage = "The value cannot be longer than {0} characters.")]
        public byte[] ByteValue { get; set; }
        
        public bool IsEncrypted { get; set; }
    }
}
