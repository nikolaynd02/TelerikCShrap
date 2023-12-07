using BeerOverflow.Models;
using System.ComponentModel.DataAnnotations;

namespace BeerOverflow.Data.Models
{
    public class RatingDb : ISoftDelete
    {
        public int Id { get; set; }

        public int? BeerId { get; set; }
        public BeerDb Beer { get; set; }

        public int? UserId { get; set; }
        public UserDb User { get; set; }

        [Range(1, 5)]
        public int Value { get; set; }
        public bool IsDeleted { get; set; }
    }
}
