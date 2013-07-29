using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;

namespace UMS.Core.Annotations
{
    public sealed class GreaterThanAttribute : ValidationAttribute, IClientValidatable
    {
        private const string GreaterThanErrorMessage = "{0} must be greater than {1}.";
        private const string GreaterThanOrEqualToErrorMessage = "{0} must be greater than or equal to {1}.";
        private readonly string _userErrorMessage;
        private readonly bool _ignoreZeros;

        private string OtherProperty { get; set; }

        private bool _allowEquality;
        private bool AllowEquality
        {
            get { return _allowEquality; }
            set
            {
                _allowEquality = value;
                ErrorMessage = (value ? GreaterThanOrEqualToErrorMessage : GreaterThanErrorMessage);
            }
        }

        public GreaterThanAttribute(string compareTo, bool allowEqualTo, string errorMessage, bool ignoreZeros)
            : base(GreaterThanErrorMessage)
        {
            if (compareTo == null) { throw new ArgumentNullException("compareTo"); }
            OtherProperty = compareTo;
            AllowEquality = allowEqualTo;
            _userErrorMessage = errorMessage;
            _ignoreZeros = ignoreZeros;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(String.IsNullOrWhiteSpace(_userErrorMessage)
                ? ErrorMessageString
                : _userErrorMessage,
                name, OtherProperty);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);

            if (otherPropertyInfo == null)
            {
                return new ValidationResult(String.Format(CultureInfo.CurrentCulture, "Could not find a property named {0}.", OtherProperty));
            }

            var otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

            decimal decValue;
            decimal decOtherPropertyValue;

            // Check to ensure the validating property is numeric
            if (!decimal.TryParse(value.ToString(), out decValue))
            {
                return new ValidationResult(String.Format("{0} is not a numeric value.", validationContext.DisplayName));
            }

            if (_ignoreZeros && decValue == 0)
                return null;

            // Check to ensure the other property is numeric
            if (!decimal.TryParse(otherPropertyValue.ToString(), out decOtherPropertyValue))
            {
                return new ValidationResult(String.Format("{0} is not a numeric value.", OtherProperty));
            }

            // Check for equality
            if (AllowEquality && decValue == decOtherPropertyValue)
            {
                return null;
            }

            // Check to see if the value is less than the other property value
            return decValue < decOtherPropertyValue ? new ValidationResult(FormatErrorMessage(validationContext.DisplayName)) : null;
        }

        private static string FormatPropertyForClientValidation(string property)
        {
            if (property == null)
            {
                throw new ArgumentException("Value cannot be null or empty.", "property");
            }
            return "*." + property;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationNumericLessThanRule(FormatErrorMessage(metadata.DisplayName), FormatPropertyForClientValidation(OtherProperty), AllowEquality, _ignoreZeros);
        }
    }

    public class ModelClientValidationNumericLessThanRule : ModelClientValidationRule
    {
        public ModelClientValidationNumericLessThanRule(string errorMessage, object other, bool allowEquality, bool ignoreZeros)
        {
            ErrorMessage = errorMessage;
            ValidationType = "greaterthan";
            ValidationParameters["other"] = other;
            ValidationParameters["allowequality"] = allowEquality;
            ValidationParameters["ignorezeros"] = ignoreZeros;
        }
    }

}
