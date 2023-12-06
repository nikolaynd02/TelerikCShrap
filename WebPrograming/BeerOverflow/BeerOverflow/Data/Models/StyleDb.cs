using Microsoft.VisualBasic;
using System.Collections;
using System.Collections.Generic;

namespace BeerOverflow.Data.Models
{
    public class StyleDb : ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<BeerDb> Beers { get; set;}
    }
}
