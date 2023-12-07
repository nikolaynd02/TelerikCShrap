using BeerOverflow.Models;
using BeerOverflow.Models.DTOs;
using BeerOverflow.Repositories.Contracts;

namespace BeerOverflow.Helpers
{
    public class ModelMapper
    {
        private readonly IStylesRepository stylesRepository;
        public ModelMapper(IStylesRepository stylesRepository)
        {
            this.stylesRepository = stylesRepository;
        }
        public Beer Map(BeerDTO beerDTO)
        {
            var beer = new Beer
            {
                Name = beerDTO.Name,
                Abv = beerDTO.Abv,
                Style = stylesRepository.GetById(beerDTO.StyleId).Result,
            };
            return beer;
        }
    }
}
