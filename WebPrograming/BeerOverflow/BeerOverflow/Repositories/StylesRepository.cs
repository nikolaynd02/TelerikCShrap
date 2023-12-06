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
    public class StylesRepository : IStylesRepository
    {
        private readonly BeerOverflowDbContext context;

        public StylesRepository(BeerOverflowDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Style>> GetAll()
        {
            var entities = await context
                .Styles
                .ToListAsync();

            return entities
                .Select(e => new Style 
                { 
                    Id = e.Id,
                    Name = e.Name
                });
        }

        public async Task<Style> GetById(int id)
        {
            var entities = await context
                .Styles
                .FirstOrDefaultAsync(s => s.Id == id) ?? throw new EntityNotFoundException($"Style with id {id} does not exist.");

            return new Style 
            { 
                Id = entities.Id,
                Name =entities.Name
            };
        }
    }
}
