using IG.Validations.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
