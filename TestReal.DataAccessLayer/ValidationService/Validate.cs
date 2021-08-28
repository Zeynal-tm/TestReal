using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace TestReal.Persistence.ValidationService
{
    public class ValidDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;

            DateTime.TryParse(value.ToString(), out dateTime);

            var isValid = DateTime.TryParseExact(Convert.ToString(dateTime.ToShortDateString()),
                "dd.MM.yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);

            return isValid;
        }
    }
}
