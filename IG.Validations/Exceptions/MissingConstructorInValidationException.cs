using IG.Validations.Resources;
using System;

namespace IG.Validations.Exceptions
{
    public class MissingConstructorInValidationException : Exception
    {
        public MissingConstructorInValidationException(Type type)
            : base(FrameworkMessages.MissingValidConstructorInValidation.FormattedMessage(type.Name))
        {

        }

        public MissingConstructorInValidationException(Type type, Exception e)
            : base(FrameworkMessages.MissingValidConstructorInValidation.FormattedMessage(type.Name), e)
        {

        }
    }
}
