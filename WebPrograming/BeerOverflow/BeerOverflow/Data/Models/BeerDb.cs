using BeerOverflow.Models;
using System.ComponentModel.DataAnnotations;

namespace BeerOverflow.Data.Models
{
    public class BeerDb : ISoftDelete
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Abv { get; set; }

        public int StyleId { get; set; }
        public StyleDb Style { get; set; }

        public int CreatedById { get; set; }
        public UserDb CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
