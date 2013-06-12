using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _203.UMS.Models.Config
{
    public class WeatherSetting : IValidatableObject
    {
        [Display(Name = "Allow Weather Display?")]
        public bool IsEnabled { get; set; }

        [Display(Name = "API Key:")]
        [StringLength(50, ErrorMessage = "You cannot provide an API key longer than {1} characters.")]
        public string ApiKey { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsEnabled && String.IsNullOrWhiteSpace(ApiKey))
            {
                yield return new ValidationResult("API Key is required when the weather display is enabled!");
            }
        }
    }
}
