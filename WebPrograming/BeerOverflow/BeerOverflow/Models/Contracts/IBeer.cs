namespace BeerOverflow.Models.Contracts
{
    public interface IBeer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Abv { get; set; }
    }
}
