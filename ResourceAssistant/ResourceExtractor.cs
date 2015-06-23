using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ResourceAssistant
{
    public static class ResourceHelper
    {
        private static Dictionary<string, byte[]> _resourceCache = new Dictionary<string, byte[]>();

        /// <summary>
        /// Gets all ResourceNames of the calling assembly or the assembly given as argument
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetResources(Assembly assembly = null)
        {
            assembly = assembly ?? Assembly.GetCallingAssembly();
            return assembly.GetManifestResourceNames();
        } 

        /// <summary>
        /// Will read files marked as "EmbeddedResource" from the directory "ResourceHelper" of the calling Assembly
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static byte[] ExtractResource(String filename, bool cache = true)
        {
            var assembly = Assembly.GetCallingAssembly();
            return ExtractResource(filename, assembly, null, cache);
        }

        /// <summary>
        /// Will read files marked as "EmbeddedResource" from the directory (given as argument) of the calling Assembly
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="resourceDirectory"></param>
        /// <returns></returns>
        public static byte[] ExtractResource(String filename, string resourceDirectory, bool cache = true)
        {
            var assembly = Assembly.GetCallingAssembly();
            return ExtractResource(filename, assembly, resourceDirectory, cache);
        }


        /// <summary>
        /// Will read files marked as "EmbeddedResource" from the directory "ResourceHelper" of the given Assembly
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static byte[] ExtractResource(String filename, Assembly assembly, bool cache = true)
        {
            return ExtractResource(filename, assembly, null, cache);
        }

        /// <summary>
        /// Will read files marked as "EmbeddedResource" from the determined ResourceDirectory of the Assembly passed as argument
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="assembly"></param>
        /// <param name="resourceDirectory"></param>
        /// <returns></returns>
        public static byte[] ExtractResource(String filename, Assembly assembly, string resourceDirectory, bool cache)
        {
            resourceDirectory = resourceDirectory ?? "Resources";

            var resourceKey = String.Format("{0}.{1}.{2}", assembly.GetName().Name, resourceDirectory, filename);

            var ba = new byte[] { };

            if (_resourceCache.ContainsKey(resourceKey))
            {
                ba = _resourceCache[resourceKey];
            }
            else
            {
                using (Stream resFilestream = assembly.GetManifestResourceStream(resourceKey))
                {
                    if (resFilestream == null) return null;
                    ba = new byte[resFilestream.Length];
                    resFilestream.Read(ba, 0, ba.Length);
                    if (cache)
                    {
                        _resourceCache[resourceKey] = ba;
                    }
                }
            }
            return ba;
        }

    }
}
