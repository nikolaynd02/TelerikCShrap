using BeerOverflow.Models;
using System.Collections.Generic;

namespace BeerOverflow.Repositories.Contracts
{
    public interface IStylesRepository
    {
        List<Style> GetAll();
        Style GetById(int id);
    }
}
