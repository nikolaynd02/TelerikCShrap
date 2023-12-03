using System.ComponentModel.DataAnnotations;

namespace BeerOverflow.Models
{
    public class BeerDTO
    {
        [MinLength(2, ErrorMessage = "The {0} must be at least {1} characters long.")]
        [MaxLength(20, ErrorMessage = "The {0} must be no more than {1} characters long.")]
        public string Name { get; set; }

        [Range(0.1, 35, ErrorMessage = "The {0} must be between {1}% and {2}%.")]
        public double Abv { get; set; }
        public int StyleId { get; set; }
    }
}
