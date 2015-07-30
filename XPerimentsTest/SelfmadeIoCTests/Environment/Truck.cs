using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPerimentsTest.SelfmadeIoCTests.Environment
{
    public class Truck : IVehicle
    {

        public Truck(IMotor motor)
        {
            Motor = motor;
        }

        public IMotor Motor { get; }

        public string Smells()
        {
            var line = string.Format("This truck's exhaust {0}.", Motor.Smell());
            Console.WriteLine(line);
            return line;
        }
    }
}
