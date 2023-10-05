namespace Dealership.Models.Contracts
{
    public interface ITruck : IVehicle, IPriceable
    {
        int WeightCapacity { get; }
    }
}
