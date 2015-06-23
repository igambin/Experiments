using IG.Validations.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.Validations.Exceptions
{
    public class InvalidValidationTypeException : Exception
    {
        public InvalidValidationTypeException(Type type)
            : base(FrameworkMessages.InvalidValidationTypeFormat(type.Name))
        {

        }
    }
}
