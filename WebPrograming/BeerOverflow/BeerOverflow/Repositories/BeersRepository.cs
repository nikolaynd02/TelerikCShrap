using BeerOverflow.Data;
using BeerOverflow.Data.Models;
using BeerOverflow.Exceptions;
using BeerOverflow.Models;
using BeerOverflow.Models.DTOs;
using BeerOverflow.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Repositories
{
    public class BeersRepository : IBeersRepository
    {
        private readonly IStylesRepository stylesRepository;
        private readonly BeerOverflowDbContext context;
        public BeersRepository(IStylesRepository stylesRepository, BeerOverflowDbContext context)
        {
            this.stylesRepository = stylesRepository;
            this.context = context;
        }

        public Beer Create(Beer beer, int styleId, int userId)
        {
            var entity = new BeerDb()
            {
                Id = beer.Id,
                Name = beer.Name,
                Abv = beer.Abv,
                StyleId = styleId,
                CreatedById = userId
            };

            context.Beers.Add(entity);
            context.SaveChangesAsync();

            return beer;
        }

        public void Delete(int id)
        {
            var entityCheck =context.
                Beers
                //.Include(b => b.Style)
                //.Include(b => b.CreatedBy)
                .Find(id) ?? throw new EntityNotFoundException($"Beer with id {id} not found");

            context.Beers.Remove(entityCheck);

            context.SaveChanges();

        }

        public async Task<IEnumerable<BeerResponseDTO>> GetAll()
        {
            var entitis = await context
                .Beers
                .Include(be => be.Style)
                .Include(be => be.CreatedBy)
                .Include(be => be.Ratings)
                .ToListAsync();

            return entitis
                .Select(e => new BeerResponseDTO()
                {
                    Name = e.Name,
                    Abv = e.Abv,
                    CreatedBy = new UserResponseDTO() 
                    { 
                        Username = e.CreatedBy.Username,
                        Fullname = $"{e.CreatedBy.FirstName} {e.CreatedBy.LastName}"
                    },
                    Style = new StyleResponseDTO()
                    {
                        Name = e.Style.Name,
                    },
                    AvgRating = e.Ratings.Count > 0 ? e.Ratings.Average(r => r.Value) : 0                    
                });
        }
        public async Task<IEnumerable<BeerResponseDTO>> FilterBy(BeerQueryParameters beerQueryParameters)
        {
            //This is not good. MUST BE OPTIMISED
            IQueryable<BeerDb> beersToReturn = context
                .Beers
                .Include(be => be.Style)
                .Include(be => be.CreatedBy)
                .Include(be => be.Ratings)
                ;

            //List<Beer> beersToReturn = beers;
            if (!string.IsNullOrEmpty(beerQueryParameters.Name))
            {
                beersToReturn = beersToReturn.Where(b => b.Name.Contains(beerQueryParameters.Name));
            }
            if (beerQueryParameters.MinAbv.HasValue)
            {
                beersToReturn = beersToReturn.Where(b => b.Abv >= beerQueryParameters.MinAbv.Value);
            }
            if (beerQueryParameters.MaxAbv.HasValue)
            {
                beersToReturn = beersToReturn.Where(b => b.Abv <= beerQueryParameters.MaxAbv.Value);
            }
            if (beerQueryParameters.StyleId.HasValue)
            {
                beersToReturn = beersToReturn.Where(b => b.Style.Id == beerQueryParameters.StyleId.Value);
            }
            if (!string.IsNullOrEmpty(beerQueryParameters.SortBy))
            {
                if (beerQueryParameters.SortBy == "name")
                {
                    beersToReturn = beersToReturn.OrderBy(b => b.Name);
                }
                else if (beerQueryParameters.SortBy == "abv")
                {
                    beersToReturn = beersToReturn.OrderBy(b => b.Abv);
                }
                else if (beerQueryParameters.SortBy == "styleid")
                {
                    beersToReturn = beersToReturn.OrderBy(b => b.Style.Id);
                }
                if (!string.IsNullOrEmpty(beerQueryParameters.SortOrder) && beerQueryParameters.SortOrder == "desc")
                {
                    beersToReturn.Reverse();
                }
            }

            var beers = await beersToReturn.ToListAsync();

            return beers
                .Select(e => new BeerResponseDTO()
                {
                    Name = e.Name,
                    Abv = e.Abv,
                    CreatedBy = new UserResponseDTO()
                    {
                        Username = e.CreatedBy.Username,
                        Fullname = $"{e.CreatedBy.FirstName} {e.CreatedBy.LastName}"
                    },
                    Style = new StyleResponseDTO()
                    {
                        Name = e.Style.Name,
                    },
                    AvgRating = e.Ratings.Count > 0 ? e.Ratings.Average(r => r.Value) : 0
                });
        }

        public async Task<BeerResponseDTO> GetById(int id)
        {
            var entity = await context
                .Beers
                .Include(b => b.Style)
                .Include(b => b.CreatedBy)
                .Include (b => b.Ratings)
                .FirstOrDefaultAsync(b => b.Id == id) ?? throw new EntityNotFoundException($"Beer with id {id} not found");



            return new BeerResponseDTO()
                {
                    Name = entity.Name,
                    Abv = entity.Abv,
                    CreatedBy = new UserResponseDTO()
                    {
                        Username = entity.CreatedBy.Username,
                        Fullname = $"{entity.CreatedBy.FirstName} {entity.CreatedBy.LastName}"
                    },
                    Style = new StyleResponseDTO()
                    {
                        Name = entity.Style.Name,
                    },
                    AvgRating = entity.Ratings.Count > 0 ? entity.Ratings.Average(r => r.Value) : 0
            };
        }

        public async Task<Beer> Update(int id, Beer beer)
        {
            //Hope it works

            var entityCheck = await context.
                Beers
                //.Include(b => b.Style)
                //.Include(b => b.CreatedBy)
                .FindAsync(id) ?? throw new EntityNotFoundException($"Beer with id {id} not found");
                
            
            var beerToUpdate = context.Beers.Include(b => b.CreatedBy).Include(b => b.Style).FirstOrDefault(b => b.Id == id);

            //beerToUpdate.IsDeleted = true;

            beerToUpdate.Abv = beer.Abv;
            beerToUpdate.Name = beer.Name;
            beerToUpdate.StyleId = (await context.Styles.FirstOrDefaultAsync(s => s.Id == beer.Style.Id)).Id;

            await context.SaveChangesAsync();

            return new Beer() 
            {
                Id = beerToUpdate.Id,
                Name = beerToUpdate.Name,
                Abv = beerToUpdate.Abv,
                CreatedBy = beerToUpdate.CreatedBy.Username,
                Style = new Style() { Id= beerToUpdate.Style.Id, Name= beerToUpdate.Style.Name }
            };

        }
        public async Task<bool> BeerExists(string name)
        {
            var entity = await context.Beers.FirstOrDefaultAsync(b => b.Name == name);

            return entity != null;
        }

        public async Task<Beer> GetByName(string name)
        {
            var entity = await context.Beers.Include(b => b.CreatedBy).Include(b => b.Style).FirstOrDefaultAsync(b => b.Name == name) ?? throw new EntityNotFoundException($"Beer with name={name} doesn't exist.");


            return new Beer()
            {
                Id = entity.Id,
                Name = entity.Name,
                Abv = entity.Abv,
                CreatedBy = entity.CreatedBy.Username,
                Style = new Style() { Id = entity.Style.Id, Name = entity.Style.Name }
            };
        }
    }
}
