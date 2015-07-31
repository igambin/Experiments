using IG.Validations.Resources;
using System;

namespace IG.Validations.Exceptions
{
    public class MissingConstructorInValidationException : Exception
    {
        public MissingConstructorInValidationException(Type type)
            : base(FrameworkMessages.MissingValidConstructorInValidationFormat(type.Name))
        {

        }

        public MissingConstructorInValidationException(Type type, Exception e)
            : base(FrameworkMessages.MissingValidConstructorInValidationFormat(type.Name), e)
        {

        }
    }
}
