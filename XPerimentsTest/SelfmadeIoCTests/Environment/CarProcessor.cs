using SelfmadeIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPerimentsTest.SelfmadeIoCTests.Environment
{
    public class CarProcessor
    {

        public IVehicle Vehicle { get; set; }

        public CarProcessor()
        {

        }

        [ResolvableConstructor ("WithVehicle")]
        public CarProcessor(IVehicle vehicle)
        {
            Vehicle = vehicle;
        }


        internal object CheckExhaust()
        {
            return Vehicle.Smells();
        }
    }
}
