using IG.Validations.Resources;
using System;

namespace IG.Validations.Exceptions
{
    public class InvalidValidationTypeException : Exception
    {
        public InvalidValidationTypeException(Type type)
            : base(FrameworkMessages.InvalidValidationType.FormattedMessage(type.Name))
        {

        }
    }
}
