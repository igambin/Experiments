using System.Linq;
using System.Reflection;

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
