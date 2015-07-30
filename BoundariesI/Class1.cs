using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoundariesI
{
    public class Class1
    {

        public static void DoSomething1()
        {
            throw new MyException("hi");
        }
    


    }

    internal class MyException : Exception
    {
        public string MyProperty { get; }

        public MyException(string w)
        {
            MyProperty = w;
        }
    }




}
