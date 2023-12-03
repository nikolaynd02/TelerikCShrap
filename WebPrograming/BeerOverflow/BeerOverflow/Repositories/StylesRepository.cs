using BeerOverflow.Exceptions;
using BeerOverflow.Models;
using BeerOverflow.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BeerOverflow.Repositories
{
    public class StylesRepository : IStylesRepository
    {
        private readonly List<Style> styles;

        public StylesRepository()
        {
            styles = new List<Style>()
            {
                new Style { Id = 1, Name = "Special Ale" },
                new Style { Id = 2, Name = "English Porter" },
                new Style { Id = 3, Name = "Indian Pale Ale" }
            };
        }
        public List<Style> GetAll()
        {
            return styles;
        }

        public Style GetById(int id)
        {
            Style style = styles.FirstOrDefault(s => s.Id == id)
                ?? throw new EntityNotFoundException($"Style with id {id} does not exist.");
            return style;

        }
    }
}
