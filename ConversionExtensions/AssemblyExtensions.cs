using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IG.Extensions
{
    public static class AssemblyExtensions
    {

        public static string AssemblyDirectory(this Type type)
        {
            string codeBase = Assembly.GetAssembly(type).CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

    }
}
