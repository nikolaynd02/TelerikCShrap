using System.ComponentModel.DataAnnotations;

namespace BeerOverflow.Models
{
    public class Beer
    {
        public int Id { get; set; }

        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; }

        [Range(0.1, 35)]
        public double Abv { get; set; }
    }
    

}
