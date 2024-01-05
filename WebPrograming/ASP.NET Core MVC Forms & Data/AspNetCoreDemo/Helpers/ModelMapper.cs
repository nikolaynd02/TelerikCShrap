using AspNetCoreDemo.Models;
using AspNetCoreDemo.Models.DTO;
using System;
using System.Linq;

namespace AspNetCoreDemo.Helpers
{
    public class ModelMapper : IModelMapper
	{
		public Beer Map(BeerDto dto)
		{
			return new Beer
			{
				Name = dto.Name,
				Abv = dto.Abv,
				StyleId = dto.StyleId
			};
		}

		public BeerResponseDto Map(Beer beerModel)
		{
			return new BeerResponseDto()
			{
				Name = beerModel.Name,
				Abv = beerModel.Abv,
				Style = beerModel.Style.Name,
				Creator = beerModel.CreatedBy.Username,
				AvgRating = beerModel.Ratings.Average(r => r.Value),
				Ratings = beerModel.Ratings.ToDictionary(r => r.User.Username, r => r.Value)
			};
		}

        public Beer Map(BeerViewModel beerModel)
        {
            return new Beer()
            {
                Name = beerModel.Name,
                Abv = beerModel.Abv,
				StyleId = beerModel.StyleId
            };
        }

		public BeerViewModel MapViewModel(Beer beerModel)
		{
            return new BeerViewModel()
            {
                Name = beerModel.Name,
                Abv = beerModel.Abv,
                StyleId = beerModel.StyleId
            };
        }
    }
}
