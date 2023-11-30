using BeerOverflow.Models;
using BeerOverflow.Services;
using BeerOverflow.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Controllers
{

    [Route("api/beers")]
    [ApiController]
    public class BeersApiController : ControllerBase
    {
        private readonly IBeerService beerService;
        public BeersApiController(IBeerService beerService)
        {
            this.beerService = beerService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(beerService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(beerService.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody]Beer beer)
        {
            //Beer newBeer = new Beer {Id = beer.Id, Name = beer.Name, Abv = beer.Abv };

            try
            {
                beerService.Create(beer);

                return Ok(beer);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Beer beer, int id)
        {
            try
            {
                return Ok(beerService.Update(id, beer));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                beerService.Delete(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
