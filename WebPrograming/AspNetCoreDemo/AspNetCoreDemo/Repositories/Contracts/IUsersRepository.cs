using BeerOverflow.Models;
using System.Collections.Generic;

namespace BeerOverflow.Repositories.Contracts
{
    public interface IUsersRepository
    {
        public IEnumerable<User> GetAll();
        public User GetById(int id);
        public User GetByUsername(string username);
    }
}
