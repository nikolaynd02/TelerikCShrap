using BeerOverflow.Models;
using BeerOverflow.Repositories.Contracts;
using BeerOverflow.Services.Contracts;
using System.Collections.Generic;

namespace BeerOverflow.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public IEnumerable<User> GetAll()
        {
            return usersRepository.GetAll().Result;
        }

        public User GetById(int id)
        {
            return usersRepository.GetById(id).Result;
        }

        public User GetByUsername(string username)
        {
            return usersRepository.GetByUsername(username).Result;
        }
    }
}
