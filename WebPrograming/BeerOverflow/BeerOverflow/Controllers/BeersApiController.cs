using BeerOverflow.Exceptions;
using BeerOverflow.Helpers;
using BeerOverflow.Models;
using BeerOverflow.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Controllers
{
    [ApiController]
    [Route("api/beers")]
    public class BeersApiController : ControllerBase
    {
        private readonly IBeersService beersService;
        private readonly IStylesService stylesService;
        private readonly ModelMapper mapper;
        private readonly AuthManager authManager;
        public BeersApiController(IBeersService beersService, IStylesService stylesService, ModelMapper mapper, AuthManager authManager)
        {
            this.stylesService = stylesService;
            this.beersService = beersService;
            this.mapper = mapper;
            this.authManager = authManager;
        }


        // This method handles GET requests sent to http://localhost:5000/api/beers
        [HttpGet("")]
        public IActionResult GetBeers([FromQuery] BeerQueryParameters beerQueryParameters)
        {
            var beers = beersService.FilterBy(beerQueryParameters);
            return Ok(beers);
        }

        // This method handles GET requests sent to http://localhost:5000/api/beers/:id 
        // 
        // Examples:
        // Send GET request to http://localhost:5000/api/beers/1
        // Send GET request to http://localhost:5000/api/beers/2
        [HttpGet("{id}")]
        public IActionResult GetBeerById(int id)
        {
            try
            {
                var beer = beersService.GetById(id);
                return Ok(beer);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // This method handles POST requests sent to http://localhost:5000/api/beers
        // The parameter beer is an instance of class Beer and is created from the body of the request
        // 
        // Example:
        // Send POST request to http://localhost:5000/api/beers with body { "name": "Pirinsko",	"abv": 5.0 }
        [HttpPost("")]
        public IActionResult CreateBeer([FromBody] BeerDTO beerDto, [FromHeader] string credentials)
        {
            try
            {
                var user = authManager.TryGerUser(credentials);

                var createdBeer = beersService.Create(user, mapper.Map(beerDto));
                return StatusCode(StatusCodes.Status201Created, createdBeer);
            }
            catch (DuplicateEntityException ex)
            {
                return Conflict(ex.Message);
            }
            catch(AuthorizationException ex)
            {
                return Unauthorized(ex.Message);
            }

        }

        // This method handles PUT requests sent to http://localhost:5000/api/beers/:id
        // The parameter beer is an instance of class Beer and is created from the body of the request
        //
        // Example:
        // Send PUT request to http://localhost:5000/api/beers/1 with body { "name": "Glarus English Ale", "abv": 6.6 }
        [HttpPut("{id}")]
        public IActionResult UpdateBeer(int id, [FromBody] BeerDTO beerDto, [FromHeader] string credentials)
        {
            try
            {
                var user = authManager.TryGerUser(credentials);
                var beerToUpdate = beersService.Update(user, id, mapper.Map(beerDto));
                return Ok(beerToUpdate);
            }
            catch (DuplicateEntityException ex)
            {
                return Conflict(ex.Message);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (AuthorizationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        // This method handles DELETE requests sent to http://localhost:5000/api/beers/:id 
        // 
        // Examples:
        // Send DELETE request to http://localhost:5000/api/beers/1
        // Send DELETE request to http://localhost:5000/api/beers/2
        [HttpDelete("{id}")]
        public IActionResult DeleteBeer(int id, [FromHeader] string credentials)
        {
            try
            {
                var user = authManager.TryGerUser(credentials);
                beersService.Delete(user, id);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (AuthorizationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
