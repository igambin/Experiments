using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ResourceAssistant
{
    public static class ResourceExtractor
    {

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
        /// Will read files marked as "EmbeddedResource" from the directory "Resources" of the calling Assembly
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static byte[] ExtractResource(String filename)
        {
            var assembly = Assembly.GetCallingAssembly();
            return ExtractResource(filename, assembly, null);
        }

        /// <summary>
        /// Will read files marked as "EmbeddedResource" from the directory (given as argument) of the calling Assembly
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="resourceDirectory"></param>
        /// <returns></returns>
        public static byte[] ExtractResource(String filename, string resourceDirectory)
        {
            var assembly = Assembly.GetCallingAssembly();
            return ExtractResource(filename, assembly, resourceDirectory);
        }


        /// <summary>
        /// Will read files marked as "EmbeddedResource" from the directory "Resources" of the given Assembly
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static byte[] ExtractResource(String filename, Assembly assembly)
        {
            return ExtractResource(filename, assembly, null);
        }

        /// <summary>
        /// Will read files marked as "EmbeddedResource" from the determined ResourceDirectory of the Assembly passed as argument
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="assembly"></param>
        /// <param name="resourceDirectory"></param>
        /// <returns></returns>
        public static byte[] ExtractResource(String filename, Assembly assembly, string resourceDirectory)
        {
            resourceDirectory = resourceDirectory ?? "Resources";

            using (Stream resFilestream = assembly.GetManifestResourceStream(String.Format("{0}.{1}.{2}", assembly.GetName().Name, resourceDirectory, filename)))
            {
                if (resFilestream == null) return null;
                var ba = new byte[resFilestream.Length];
                resFilestream.Read(ba, 0, ba.Length);
                return ba;
            }
        }

        /// <summary>
        /// Transforms Byte[] to String
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string AsString(this byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// Transforms String to Byte[]
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] AsByteArray(this string data)
        {
            return Encoding.UTF8.GetBytes(data);
        }
    }
}
