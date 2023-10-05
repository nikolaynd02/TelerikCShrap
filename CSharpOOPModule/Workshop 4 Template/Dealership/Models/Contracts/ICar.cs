namespace Dealership.Models.Contracts
{
    public interface ICar : IVehicle, IPriceable
    {
        int Seats { get; }
    }
}
