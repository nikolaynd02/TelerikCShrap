using BeerOverflow.Exceptions;
using BeerOverflow.Models;
using BeerOverflow.Repositories.Contracts;
using BeerOverflow.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Net;

namespace BeerOverflow.Services
{
    public class BeersService : IBeersService
    {
        private readonly IBeersRepository beersRepository;
        public BeersService(IBeersRepository beersRepository)
        {
            this.beersRepository = beersRepository;
        }
        public Beer Create(User user, Beer beer)
        {
            EnsureBeerUniqueName(beer);

            beer.CreatedBy = user.Username;

            var createdBeer = beersRepository.Create(beer, beer.Style.Id, user.Id);
            return createdBeer;
        }

        public void Delete(User user, int id)
        {
            if (!AuthorizedUser(user, GetById(id)))
            {
                throw new AuthorizationException($"User {user.Username} is not admin nor is he beer's creator.");
            }
            beersRepository.Delete(id);
        }

        public IEnumerable<Beer> GetAll()
        {
            var beers = beersRepository.GetAll();
            return beers.Result;
        }

        public Beer GetById(int id)
        {
 
            var beer = beersRepository.GetById(id).Result;
            return beer;

        }

        public Beer Update(User user, int id, Beer beer)
        {
            if (!AuthorizedUser(user, GetById(id)))
            {
                throw new AuthorizationException($"User {user.Username} is not admin nor is he beer's creator.");
            }
            EnsureBeerUniqueName(id, beer);
            var updatedBeer = beersRepository.Update(id, beer).Result;
            return updatedBeer;
        }
        public IEnumerable<Beer> FilterBy(BeerQueryParameters beerQueryParameters)
        {
            return beersRepository.FilterBy(beerQueryParameters).Result;
        }
        //Validates unique name when creating a beer
        private void EnsureBeerUniqueName(Beer beer)
        {
            if (beersRepository.BeerExists(beer.Name).Result)
            {
                throw new DuplicateEntityException($"Beer with name {beer.Name} already exists");

            }
        }
        //Validates unique name when updating a beer
        private void EnsureBeerUniqueName(int id, Beer beer)
        {
            if (beersRepository.BeerExists(beer.Name).Result)
            {
                var beerToValidate = beersRepository.GetByName(beer.Name).Result;
                if (beerToValidate.Id != id && beer.Name == beerToValidate.Name)
                {
                    throw new DuplicateEntityException($"Beer with name {beer.Name} already exists");
                }

            }
        }

        private bool AuthorizedUser(User user, Beer beer)
        {
            if (!user.IsAdmin && beer.CreatedBy != user.Username)
            {
                return false;
            }

            return true;
        }

    }
}
