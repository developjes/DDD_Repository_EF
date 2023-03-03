using Example.Ecommerce.Transversal.Common.Enum;
using System.Text.RegularExpressions;

namespace Example.Ecommerce.Domain.Validator.Common
{
    public static class CommonValidator
    {
        public static (bool, EnumMessage) ValidateCustomRegex(string field, string regex) =>
            field is not null && regex is not null && new Regex(regex!).IsMatch(field) ?
                (true, EnumMessage.VALIDATION_SUCCESS) : (false, EnumMessage.VALIDATION_ERROR);
    }
}