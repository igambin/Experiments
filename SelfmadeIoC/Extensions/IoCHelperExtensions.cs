using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SelfmadeIoC
{
    internal static class IoCHelperExtensions
    {

        public static ConstructorInfo FindByName(this ConstructorInfo[] infos, string name) => infos.FirstOrDefault(x =>
                                                                                                         {
                                                                                                             var attr = x.GetResolvableConstructorAttribute();
                                                                                                             return attr != null && attr.Name == name;
                                                                                                         });

        public static ResolvableConstructorAttribute GetResolvableConstructorAttribute(this ConstructorInfo cinfo) => cinfo.GetCustomAttribute<ResolvableConstructorAttribute>();

    }
}
