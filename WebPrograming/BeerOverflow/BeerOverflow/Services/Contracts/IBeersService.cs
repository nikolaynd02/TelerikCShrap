using BeerOverflow.Models;
using BeerOverflow.Models.DTOs;
using System.Collections.Generic;

namespace BeerOverflow.Services.Contracts
{
    public interface IBeersService
    {
        IEnumerable<BeerResponseDTO> GetAll();
        IEnumerable<BeerResponseDTO> FilterBy(BeerQueryParameters beerQueryParameters);
        BeerResponseDTO GetById(int id);
        Beer Create(User user, Beer beer);
        Beer Update(User user, int id, Beer beer);
        void Delete(User user, int id);
    }
}
