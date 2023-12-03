using BeerOverflow.Exceptions;
using BeerOverflow.Models;
using BeerOverflow.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BeerOverflow.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IList<User> users;
        public UsersRepository()
        {
            users = new List<User>() {
                new User() { Id = 1, Username = "Admin", FirstName ="Nikolay", LastName="Dobrev", Password="admin", Email="email@abv.bg", IsAdmin = true },
                new User() { Id = 2, Username = "Tester", FirstName = "Pencho", LastName="Penchov", Password="tester", Email="tester@mail.com", IsAdmin = false },
                };
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public User GetById(int id)
        {
            var user = users.FirstOrDefault(user => user.Id == id)
               ?? throw new EntityNotFoundException($"User with id {id} not found.");
            return user;
        }

        public User GetByUsername(string username)
        {
            var user = users.FirstOrDefault(user => user.Username == username)
              ?? throw new EntityNotFoundException($"User with username {username} not found.");
            return user;
        }
    }
}
