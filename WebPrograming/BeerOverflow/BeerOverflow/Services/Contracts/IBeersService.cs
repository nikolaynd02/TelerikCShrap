using BeerOverflow.Models;
using System.Collections.Generic;

namespace BeerOverflow.Services.Contracts
{
    public interface IBeersService
    {
        IEnumerable<Beer> GetAll();
        IEnumerable<Beer> FilterBy(BeerQueryParameters beerQueryParameters);
        Beer GetById(int id);
        Beer Create(User user, Beer beer);
        Beer Update(User user, int id, Beer beer);
        void Delete(User user, int id);
    }
}
