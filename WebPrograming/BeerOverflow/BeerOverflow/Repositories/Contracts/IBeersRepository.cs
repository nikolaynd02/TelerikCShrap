using BeerOverflow.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerOverflow.Repositories.Contracts
{
    public interface IBeersRepository
    {
        public Task<IEnumerable<Beer>> GetAll();
        public Task<IEnumerable<Beer>> FilterBy(BeerQueryParameters beerQueryParameters);
        public Task<Beer> GetById(int id);
        public Beer Create(Beer beer, int styleId, int userId);
        public Task<Beer> Update(int id, Beer beer);
        void Delete(int id);
        public Task<bool> BeerExists(string name);
        public Task<Beer> GetByName(string name);

    }

}
