using System;
using XPerimentsTest.SelfmadeIoCTests.Environment;
using SelfmadeIoC;
using NUnit.Framework;
using System.IO;

namespace XPerimentsTest.SelfmadeIoCTests
{
    [TestFixture]
    public class SelfmadeIoCTests
    {
        
        [Test]
        public void RegisterDateTimeInstance()
        {
            IoCContainer container = new IoCContainer();

            container.Register<DateTime>(new DateTime(2000, 1, 1));

            var date = container.Resolve<DateTime>();

            Assert.AreEqual(new DateTime(2000, 1, 1), date);
        }

        [Test]
        public void ReregisterDateTimeInstance()
        {
            IoCContainer container = new IoCContainer();

            container.Register<DateTime>(new DateTime(2000, 1, 1));

            container.Register<DateTime>(new DateTime(2010, 1, 1));

            var date = container.Resolve<DateTime>();

            Assert.AreEqual(new DateTime(2010, 1, 1), date);
        }

        [Test]
        public void RegisterIVehicleAndIMotor()
        {
            IoCContainer container = new IoCContainer();

            container.Register<IVehicle, Truck>();
            container.Register<IMotor, DieselMotor>();

            var vehicle = container.Resolve<IVehicle>();

            Assert.AreEqual("This truck's exhaust stinks.", vehicle.Smells());
        }

        [Test]
        public void RegisterDefaultStringInstance()
        {
            IoCContainer container = new IoCContainer();

            container.Register<String>("String always defaults to this string.");

            var str = container.Resolve<string>();

            Assert.AreEqual("String always defaults to this string.", str);
        }

        [Test]
        public void RegisterNormalPocoClass()
        {
            IoCContainer container = new IoCContainer();

            container.Register<CarProcessor, CarProcessor>();

            var processor = container.Resolve<CarProcessor>();

            Assert.AreEqual("CarProcessor", processor.GetType().Name);
        }

        [Test]
        public void RegisterResolvableConstructorWithName()
        {
            IoCContainer container = new IoCContainer();

            container.Register<CarProcessor, CarProcessor>();
            container.Register<IVehicle, MotorBike>();
            container.Register<IMotor, UnleadedMotor>();

            var processor1 = container.Resolve<CarProcessor>();
            var processor2 = container.Resolve<CarProcessor>("WithVehicle");

            Assert.IsNull(processor1.Vehicle);

            Assert.AreEqual("This motorbike's exhaust smells normal.", processor2.CheckExhaust());

            Console.WriteLine(processor2.CheckExhaust());

        }
        [Test]
        public void RegisterResolvableUnregisteredType()
        {
            IoCContainer container = new IoCContainer();

            var processor1 = container.Resolve<MemoryStream>();

            Assert.IsInstanceOf<MemoryStream>(processor1);
            Assert.AreEqual(processor1.Length, 0);
        }

        [Test]
        [ExpectedException(typeof(TypeNotRegisteredException))]
        public void RegisterUnresolvableUnregisteredType()
        {
            IoCContainer container = new IoCContainer();

            var processor1 = container.Resolve<DateTime>();

        }
    }
}
