using BeerOverflow.Models.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Repositories.Contracts
{
    public interface IBeersRepository
    {
        public IEnumerable<IBeer> GetAll();
        public IBeer GetById(int id);
        public void Create(IBeer beer);
        //public IBeer Update(int id, IBeer beer);
        public void Delete(IBeer beer);
    }
}
