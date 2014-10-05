using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XPerimentsTest.SelfmadeIoCTests.Environment;
using SelfmadeIoC;

namespace XPerimentsTest.SelfmadeIoCTests
{
    [TestClass]
    public class SelfmadeIoCTests
    {
        
        [TestMethod]
        public void RegisterDateTimeInstance()
        {
            IoCContainer container = new IoCContainer();

            container.Register<DateTime>(new DateTime(2000, 1, 1));

            var date = container.Resolve<DateTime>();

            Assert.AreEqual(new DateTime(2000, 1, 1), date);
        }

        [TestMethod]
        public void RegisterIVehicleAndIMotor()
        {
            IoCContainer container = new IoCContainer();

            container.Register<IVehicle, Truck>();
            container.Register<IMotor, DieselMotor>();

            var vehicle = container.Resolve<IVehicle>();

            Assert.AreEqual("This truck's exhaust strinks.", vehicle.Smells());
        }
    }
}
