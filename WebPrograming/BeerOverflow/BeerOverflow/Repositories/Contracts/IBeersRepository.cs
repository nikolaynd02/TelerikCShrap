using BeerOverflow.Models;
using System.Collections.Generic;

namespace BeerOverflow.Repositories.Contracts
{
    public interface IBeersRepository
    {
        IList<Beer> GetAll();
        IList<Beer> FilterBy(BeerQueryParameters beerQueryParameters);
        Beer GetById(int id);
        Beer Create(Beer beer);
        Beer Update(int id, Beer beer);
        void Delete(int id);
        bool BeerExists(string name);
        public Beer GetByName(string name);

    }

}
