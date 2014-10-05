using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPerimentsTest.SelfmadeIoCTests.Environment
{
    public interface IVehicle
    {
        IMotor Motor { get; }
        string Smells();        
    }
}
