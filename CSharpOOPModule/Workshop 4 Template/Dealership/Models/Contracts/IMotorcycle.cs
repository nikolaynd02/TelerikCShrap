namespace Dealership.Models.Contracts
{
    public interface IMotorcycle : IVehicle, IPriceable
    {
        string Category { get; }
    }
}
