using BeerOverflow.Exceptions;
using BeerOverflow.Models;
using BeerOverflow.Models.Contracts;
using BeerOverflow.Repositories.Contracts;
using BeerOverflow.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Services
{
    public class BeerService : IBeerService
    {
        private IBeersRepository context;

        public BeerService(IBeersRepository beersRepository)
        {
            context = beersRepository;
        }

        public IBeer Create(IBeer beer)
        {
            var beers = context.GetAll();
            if(beers.Any(b => b.Name == beer.Name))
            {
                throw new DuplicateEntityException($"Beer with name\"{beer.Name}\" already exists.");
            }

            context.Create(beer);


            return beer;
        }

        public void Delete(int id)
        {
            var beer = context.GetById(id);

            if(beer == null)
            {
                throw new EntityNotFoundException($"Beer with id: {id} does not exists.");
            }

            context.Delete(beer);

            return;
        }

        public IBeer Get(int id)
        {
            var beer = context.GetById(id);

            if (beer == null)
            {
                throw new EntityNotFoundException($"Beer with id: {id} does not exists.");
            }
            return beer;
        }

        public IEnumerable<IBeer> GetAll()
        {
            return context.GetAll();
        }


        public IBeer Update(int id, IBeer beer)
        {
            var oldBeer = this.Get(id);

            if (oldBeer == null)
            {
                throw new EntityNotFoundException($"Beer with id: {id} does not exists.");
            }

            if (context.GetAll().Any(b => b.Name == beer.Name))
            {
                throw new DuplicateEntityException($"Beer with name\"{beer.Name}\" already exists.");
            }

            oldBeer.Name = beer.Name;
            oldBeer.Abv = beer.Abv;

            return oldBeer;
        }
    }
}
