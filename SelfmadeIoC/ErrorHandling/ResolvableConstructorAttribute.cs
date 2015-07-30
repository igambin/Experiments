using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfmadeIoC
{
    public sealed class ResolvableConstructorAttribute : Attribute
    {
        public string Name { get; set; }

        public ResolvableConstructorAttribute(string name)
        {
            Name = name;
        }
    }

}
