using System.Collections.Generic;

namespace AspNetCoreDemo.Models
{
    public class CreateBeerViewModel
    {
        public string Name { get; set; }
        public double Abv { get; set; }
        public int StyleId { get; set; }
        public List<Style> Styles { get; set; }
    }
}
