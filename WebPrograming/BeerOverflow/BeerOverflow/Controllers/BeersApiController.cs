using BeerOverflow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Controllers
{

    [Route("api/beers")]
    [ApiController]
    public class BeersApiController : ControllerBase
    {
        static List<Beer> beers = new List<Beer>
        {
            new Beer { Id = 1, Name = "Heisenberg", Abv = 10},
            new Beer{ Id = 2, Name = "Haineken", Abv=5}
        };

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var myBeer = beers.FirstOrDefault(b => b.Id == id);

            if (myBeer == null)
            {
                return NotFound();
            }


            return Ok(myBeer);
        }

        [HttpGet]
        public IActionResult Get() 
        {
            return Ok(beers);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Beer beer)
        {
            //Beer newBeer = new Beer {Id = beer.Id, Name = beer.Name, Abv = beer.Abv };



            beers.Add(beer);

            return Ok(beer);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody]Beer beer, int id)
        {
            var oldBeer = beers.FirstOrDefault(b => b.Id == id);

            if(oldBeer == null)
            {
                return NotFound();
            }

            oldBeer.Id = beer.Id;
            oldBeer.Name = beer.Name;
            oldBeer.Abv = beer.Abv;

            return Ok(oldBeer);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var beerForDeletion = beers.FirstOrDefault(b => b.Id == id);

            if(beerForDeletion == null)
            {
                return NotFound();
            }

            beers.Remove(beerForDeletion);

            return Ok(beerForDeletion);
        }


    }
}
