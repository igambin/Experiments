using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CopyHelper_DirRemover
{
    public class ConsoleInput
    {

        public static string GetDirectory(string paramName, string paramHelp)
        {
            string input = null;
            while (input == null)
            {
                Console.Write(paramName+": ");
                input = Console.ReadLine();

                if(input == "?") {
                    Console.WriteLine(paramHelp);
                    input = null;
                }
                else if (!Directory.Exists(input))
                {
                    Console.WriteLine("Directory does not exist, or you are not allowed to access it.");
                    input = null;
                }
            }
            return input;
        }

        public static Regex GetRegex(string paramName, string paramHelp, bool nullable = false)
        {
            Regex regex = null;
            string input = null;
            while (input == null)
            {
                Console.Write(paramName + ": ");
                input = Console.ReadLine();

                if (input == "?")
                {
                    Console.WriteLine(paramHelp);
                    input = null;
                }
                else if (String.IsNullOrEmpty(input))
                {
                    if (nullable)
                    {
                        return null;
                    }
                    input = null;
                }

                try
                {
                    regex = new Regex(input);
                    return regex;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    input = null;
                }

            }
            return regex;

        }
        
    }
}
