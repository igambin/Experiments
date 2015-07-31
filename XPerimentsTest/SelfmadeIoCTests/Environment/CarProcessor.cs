using SelfmadeIoC;

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


        internal object CheckExhaust() => Vehicle.Smells();
    }
}
