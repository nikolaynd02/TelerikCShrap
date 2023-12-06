using BeerOverflow.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerOverflow.Repositories.Contracts
{
    public interface IUsersRepository
    {
        public Task<IEnumerable<User>> GetAll();
        public Task<User> GetById(int id);
        public Task<User> GetByUsername(string username);
    }
}
