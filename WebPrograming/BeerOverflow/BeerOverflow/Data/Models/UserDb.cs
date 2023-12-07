using System.Collections;
using System.Collections.Generic;

namespace BeerOverflow.Data.Models
{
    public class UserDb : ISoftDelete
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<BeerDb> Beers { get; set; }

        public ICollection<RatingDb> Ratings { get; set; }
    }
}
