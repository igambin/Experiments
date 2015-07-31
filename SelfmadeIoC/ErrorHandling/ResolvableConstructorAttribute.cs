using System;

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
