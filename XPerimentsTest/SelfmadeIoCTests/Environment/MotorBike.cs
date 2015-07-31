using System;

namespace XPerimentsTest.SelfmadeIoCTests.Environment
{
    public class MotorBike : IVehicle
    {

        public MotorBike(IMotor motor)
        {
            Motor = motor;
        }

        public IMotor Motor { get; }

        public string Smells()
        {
            var line = string.Format("This motorbike's exhaust {0}.", Motor.Smell());
            Console.WriteLine(line);
            return line;
        }

    }
}
