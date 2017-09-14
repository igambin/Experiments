using System;

namespace IG.CommonLogging.Attributes
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
