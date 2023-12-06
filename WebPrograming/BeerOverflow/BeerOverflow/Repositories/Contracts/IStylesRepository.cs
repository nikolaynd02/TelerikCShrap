using BeerOverflow.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerOverflow.Repositories.Contracts
{
    public interface IStylesRepository
    {
        public Task<IEnumerable<Style>> GetAll();
        public Task<Style> GetById(int id);
    }
}
