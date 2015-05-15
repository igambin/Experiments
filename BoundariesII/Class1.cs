using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoundariesI;

namespace BoundariesII
{
    public class Class2
    {
        public static void DoSomething2()
        {
            try 
            {
                Class1.DoSomething1();
            } 
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
