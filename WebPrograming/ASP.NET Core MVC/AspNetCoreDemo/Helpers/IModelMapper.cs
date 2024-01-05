using AspNetCoreDemo.Models.DTO;
using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Helpers
{
	public interface IModelMapper
	{
		Beer Map(BeerDto dto);
		BeerResponseDto Map(Beer beerModel);
	}
}
