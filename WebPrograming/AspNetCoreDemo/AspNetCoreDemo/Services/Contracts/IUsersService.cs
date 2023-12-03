using BeerOverflow.Models;
using System.Collections.Generic;

namespace BeerOverflow.Services.Contracts
{
    public interface IUsersService
    {
        public IEnumerable<User> GetAll();
        public User GetById(int id);
        public User GetByUsername(string username);
    }
}
