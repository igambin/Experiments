using System;

namespace IG.Validations
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class ValidationClassAttribute : Attribute
    {
    }   
}