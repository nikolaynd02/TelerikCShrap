using BeerOverflow.Data;
using BeerOverflow.Exceptions;
using BeerOverflow.Models;
using BeerOverflow.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly BeerOverflowDbContext context;
        public UsersRepository(BeerOverflowDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var entities = await context.Users.ToListAsync();

            return entities
                .Select(x => new User()
                {
                    Id = x.Id,
                    Username = x.Username,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Password = x.Password,
                    Email = x.Email,
                    IsAdmin = x.IsAdmin
                });                                
        }

        public async Task<User> GetById(int id)
        {
            var entity = await context.Users
                .FirstOrDefaultAsync(u => u.Id == id) ?? throw new EntityNotFoundException($"User with id {id} not found.");

            return new User()
            {
                Id = entity.Id,
                Username = entity.Username,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Password = entity.Password,
                Email = entity.Email,
                IsAdmin = entity.IsAdmin
            };

        }

        public async Task<User> GetByUsername(string username)
        {

            var entity = await context.Users
                .FirstOrDefaultAsync(u => u.Username == username);// ?? throw new EntityNotFoundException($"User with username {username} not found.");


            return new User()
            {
                Id = entity.Id,
                Username = entity.Username,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Password = entity.Password,
                Email = entity.Email,
                IsAdmin = entity.IsAdmin
            };
        }
    }
}
