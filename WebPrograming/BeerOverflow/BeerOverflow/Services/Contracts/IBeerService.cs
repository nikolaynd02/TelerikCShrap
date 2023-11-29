using BeerOverflow.Models.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Services.Contracts
{
    public interface IBeerService
    {
        public IEnumerable<IBeer> GetAll();
        public IBeer Get(int id);
        public IBeer Create(IBeer beer);
        public IBeer Update(int id, IBeer beer);
        public void Delete(int id);
    }
}
