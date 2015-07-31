namespace XPerimentsTest.SelfmadeIoCTests.Environment
{
    public interface IVehicle
    {
        IMotor Motor { get; }
        string Smells();        
    }
}
