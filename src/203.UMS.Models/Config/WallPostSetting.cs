using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _203.UMS.Models.Config
{
    public class WallPostSetting : IValidatableObject
    {
        [Display(Name = "Allow Wall Post Override?")]
        public bool IsOverrideEnabled { get; set; }

        [Display(Name = "RSS Url:")]
        [DataType(DataType.Url)]
        [StringLength(150, ErrorMessage = "You cannot provide a URL longer than {1} characters.")]
        public string RssOverrideUrl { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsOverrideEnabled && String.IsNullOrWhiteSpace(RssOverrideUrl))
            {
                yield return new ValidationResult("RSS Url is required when the override of wall posts is enabled!");
            }
        }
    }
}
