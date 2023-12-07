using BeerOverflow.Models;
using BeerOverflow.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerOverflow.Repositories.Contracts
{
    public interface IBeersRepository
    {
        public Task<IEnumerable<BeerResponseDTO>> GetAll();
        public Task<IEnumerable<BeerResponseDTO>> FilterBy(BeerQueryParameters beerQueryParameters);
        public Task<BeerResponseDTO> GetById(int id);
        public Beer Create(Beer beer, int styleId, int userId);
        public Task<Beer> Update(int id, Beer beer);
        void Delete(int id);
        public Task<bool> BeerExists(string name);
        public Task<Beer> GetByName(string name);

    }

}
