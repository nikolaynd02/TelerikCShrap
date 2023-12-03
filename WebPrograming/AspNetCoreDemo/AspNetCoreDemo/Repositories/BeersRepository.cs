using BeerOverflow.Exceptions;
using BeerOverflow.Models;
using BeerOverflow.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerOverflow.Repositories
{
    public class BeersRepository : IBeersRepository
    {
        private static int nextId;
        private readonly IStylesRepository stylesRepository;
        private readonly List<Beer> beers;
        public BeersRepository(IStylesRepository stylesRepository)
        {
            this.stylesRepository = stylesRepository;

            beers = new List<Beer>()
        {
            new Beer
            {
                Id = 1,
                Name = "Glarus English Ale",
                Abv = 4.6,
                Style = stylesRepository.GetById(1)
            },
            new Beer
            {
                Id = 2,
                Name = "Rhombus Porter",
                Abv = 5.0,
                Style = stylesRepository.GetById(2)
            },
            new Beer
                {
                    Id = 3,
                    Name = "Opasen Char",
                    Abv = 6.6,
                    Style = this.stylesRepository.GetById(3), // Indian Pale Ale
				}
        };
            nextId = beers.Count + 1;
        }

        public Beer Create(Beer beer)
        {
            beer.Id = nextId++;
            beers.Add(beer);
            return beer;
        }

        public void Delete(int id)
        {
            var beerToDelete = beers.FirstOrDefault(beer => beer.Id == id)
                ?? throw new EntityNotFoundException($"Beer with id {id} not found");
            beers.Remove(beerToDelete);
        }

        public IList<Beer> GetAll()
        {
            return beers;
        }
        public IList<Beer> FilterBy(BeerQueryParameters beerQueryParameters)
        {
            List<Beer> beersToReturn = beers;
            if (!string.IsNullOrEmpty(beerQueryParameters.Name))
            {
                beersToReturn = beersToReturn.FindAll(b => b.Name.Contains(beerQueryParameters.Name));
            }
            if (beerQueryParameters.MinAbv.HasValue)
            {
                beersToReturn = beersToReturn.FindAll(b => b.Abv >= beerQueryParameters.MinAbv.Value);
            }
            if (beerQueryParameters.MaxAbv.HasValue)
            {
                beersToReturn = beersToReturn.FindAll(b => b.Abv <= beerQueryParameters.MaxAbv.Value);
            }
            if (beerQueryParameters.StyleId.HasValue)
            {
                beersToReturn = beersToReturn.FindAll(b => b.Style.Id == beerQueryParameters.StyleId.Value);
            }
            if (!string.IsNullOrEmpty(beerQueryParameters.SortBy))
            {
                if (beerQueryParameters.SortBy == "name")
                {
                    beersToReturn = beersToReturn.OrderBy(b => b.Name).ToList();
                }
                else if (beerQueryParameters.SortBy == "abv")
                {
                    beersToReturn = beersToReturn.OrderBy(b => b.Abv).ToList();
                }
                else if (beerQueryParameters.SortBy == "styleid")
                {
                    beersToReturn = beersToReturn.OrderBy(b => b.Style.Id).ToList();
                }
                if (!string.IsNullOrEmpty(beerQueryParameters.SortOrder) && beerQueryParameters.SortOrder == "desc")
                {
                    beersToReturn.Reverse();
                }
            }



            return beersToReturn;
        }

        public Beer GetById(int id)
        {
            var beer = beers.FirstOrDefault(beer => beer.Id == id)
                ?? throw new EntityNotFoundException($"Beer with id {id} not found");
            return beer;
        }

        public Beer Update(int id, Beer beer)
        {
            var beerToUpdate = beers.FirstOrDefault(b => b.Id == id)
                ?? throw new EntityNotFoundException($"Beer with id {id} not found");

            beerToUpdate.Abv = beer.Abv;
            beerToUpdate.Name = beer.Name;
            beerToUpdate.Style = beer.Style;

            return beerToUpdate;

        }
        public bool BeerExists(string name)
        {
            return beers.Any(beer => beer.Name == name);
        }

        public Beer GetByName(string name)
        {
            Beer beer = beers.FirstOrDefault(b => b.Name == name);

            return beer ?? throw new EntityNotFoundException($"Beer with name={name} doesn't exist."); ;
        }
    }
}
