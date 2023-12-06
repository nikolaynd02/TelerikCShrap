using BeerOverflow.Models;
using System.Collections.Generic;

namespace BeerOverflow.Services.Contracts
{
    public interface IStylesService
    {
        public IList<Style> GetAll();
        public Style GetById(int id);
    }
}
