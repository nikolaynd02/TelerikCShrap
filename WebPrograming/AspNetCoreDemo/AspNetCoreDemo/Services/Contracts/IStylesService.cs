using BeerOverflow.Models;
using System.Collections.Generic;

namespace BeerOverflow.Services.Contracts
{
    public interface IStylesService
    {
        List<Style> GetAll();
        Style GetById(int id);
    }
}
