using System.Collections.Generic;

using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Repositories;

namespace AspNetCoreDemo.Services
{
	public class BeersService : IBeersService
	{
		private const string ModifyBeerErrorMessage = "Only owner or admin can modify a beer.";
		private readonly IBeersRepository beersRepository;

		public BeersService(IBeersRepository repository)
		{
			this.beersRepository = repository;
		}

		public List<Beer> GetAll()
		{
			return beersRepository.GetAll();
		}

		public List<Beer> FilterBy(BeerQueryParameters filterParameters)
		{
			return beersRepository.FilterBy(filterParameters);
		}

		public Beer GetById(int id)
		{
			return beersRepository.GetById(id);
		}

        
        public Beer Create(Beer beer, User user)
        {
            EnsureBeerUniqueName(beer);
            beer.CreatedBy = user;
            var createdBeer = beersRepository.Create(beer);
            return createdBeer;
        }

        public Beer Update(int id, Beer beer, User user)
        {
            EnsureUserHasAuthorization(user, id);
            EnsureBeerUniqueName(id, beer);
            var updatedBeer = beersRepository.Update(id, beer);
            return updatedBeer;
        }

        public bool Delete(int id, User user)
		{
            EnsureUserHasAuthorization(user, id);
			return beersRepository.Delete(id);
		}

        //Validates unique name when creating a beer
        private void EnsureBeerUniqueName(Beer beer)
        {
            if (beersRepository.BeerExists(beer.Name))
            {
                throw new DuplicateEntityException($"Beer with name {beer.Name} already exists");
            }
        }

        //Validates unique name when updating a beer
        private void EnsureBeerUniqueName(int id, Beer beer)
        {
            if (beersRepository.BeerExists(beer.Name))
            {
                var beerToValidate = beersRepository.GetByName(beer.Name);
                if (beerToValidate.Id != id && beer.Name == beerToValidate.Name)
                {
                    throw new DuplicateEntityException($"Beer with name {beer.Name} already exists");
                }
            }
        }

        private void EnsureUserHasAuthorization(User user, int beerId)
        {
            var beer = beersRepository.GetById(beerId);

            if (beer.CreatedById != user.Id && !user.IsAdmin)
            {
                throw new UnauthorizedOperationException(ModifyBeerErrorMessage);
            }
        }
    }
}
