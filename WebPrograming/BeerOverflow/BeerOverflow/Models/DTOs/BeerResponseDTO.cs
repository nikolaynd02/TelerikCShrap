using System.ComponentModel.DataAnnotations;

namespace BeerOverflow.Models.DTOs
{
    public class BeerResponseDTO
    {
        public string Name { get; set; }

        public double Abv { get; set; }
        public StyleResponseDTO Style { get; set; }
        public UserResponseDTO CreatedBy { get; set; }
        public double AvgRating { get; set; }
    }
}
