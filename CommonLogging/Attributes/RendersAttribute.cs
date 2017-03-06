using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLogging.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class RendersAttribute : Attribute
    {
        public RendersAttribute(Type type)
        {
            RendersType = type;
        }

        public Type RendersType { get; }
    }
}
