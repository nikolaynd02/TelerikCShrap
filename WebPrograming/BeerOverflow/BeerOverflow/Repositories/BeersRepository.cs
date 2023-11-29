using BeerOverflow.Models.Contracts;
using BeerOverflow.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Repositories
{
    public class BeersRepository : IBeersRepository
    {
        private readonly List<IBeer> beers = new List<IBeer>();

        public void Create(IBeer beer)
        {
            beers.Add(beer);
        }

        public void Delete(IBeer beer)
        {
            beers.Remove(beer);
        }

        public IEnumerable<IBeer> GetAll()
        {
            return beers;
        }

        public IBeer GetById(int id)
        {
            return beers.FirstOrDefault(b => b.Id == id);
        }

        //public IBeer Update(int id, IBeer beer)
        //{
        //    var oldbeer = beers.Find(b => b.Id == id);

        //    oldbeer.Name = beer.Name;
        //    oldbeer.Abv = beer.Abv;

        //    return beer;

        //}
    }
}
