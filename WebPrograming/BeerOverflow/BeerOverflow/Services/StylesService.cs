using BeerOverflow.Models;
using BeerOverflow.Repositories.Contracts;
using BeerOverflow.Services.Contracts;
using System.Collections.Generic;

namespace BeerOverflow.Services
{
    public class StylesService : IStylesService
    {
        private readonly IStylesRepository stylesRepository;
        public StylesService(IStylesRepository stylesRepository)
        {
            this.stylesRepository = stylesRepository;
        }
        public IList<Style> GetAll()
        {
            return (IList<Style>)stylesRepository.GetAll();
        }

        public Style GetById(int id)
        {
            return stylesRepository.GetById(id).Result;
        }
    }
}
