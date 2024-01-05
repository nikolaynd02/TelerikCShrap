using System.Collections.Generic;
using System.Linq;
using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Helpers;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Models.DTO;
using AspNetCoreDemo.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemo.Controllers.Api
{
    [ApiController]
    [Route("api/beers")]
    public class BeersApiController : ControllerBase
    {
        private readonly IBeersService beersService;
        private readonly IModelMapper modelMapper;
        private readonly AuthManager authManager;

        public BeersApiController(IBeersService beersService, IModelMapper modelMapper, AuthManager authManager)
        {
            this.beersService = beersService;
            this.modelMapper = modelMapper;
            this.authManager = authManager;
        }

        [HttpGet("")]
        public IActionResult GetBeers([FromQuery] BeerQueryParameters filterParameters)
        {
            List<BeerResponseDto> beers = beersService
                .FilterBy(filterParameters)
                .Select(beer => modelMapper.Map(beer))
                .ToList();

            return Ok(beers);
        }

        [HttpGet("{id}")]
        public IActionResult GetBeerById(int id)
        {
            try
            {
                Beer beer = beersService.GetById(id);
                BeerResponseDto beerResponseDto = modelMapper.Map(beer);

                return Ok(beerResponseDto);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("")]
        public IActionResult CreateBeer([FromHeader] string username, [FromBody] BeerDto dto)
        {
            try
            {
                User user = authManager.TryGetUser(username);
                Beer beer = modelMapper.Map(dto);

                Beer createdBeer = beersService.Create(beer, user);
                BeerResponseDto createdBeerDto = modelMapper.Map(createdBeer);

                return StatusCode(StatusCodes.Status201Created, createdBeerDto);
            }
            catch (UnauthorizedOperationException e)
            {
                return Unauthorized(e.Message);
            }
            catch (DuplicateEntityException e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBeer(int id, [FromHeader] string username, [FromBody] BeerDto dto)
        {
            try
            {
                User user = authManager.TryGetUser(username);
                Beer beer = modelMapper.Map(dto);

                Beer updatedBeer = beersService.Update(id, beer, user);
                BeerResponseDto beerResponseDto = modelMapper.Map(updatedBeer);

                return Ok(beerResponseDto);
            }
            catch (UnauthorizedOperationException e)
            {
                return Unauthorized(e.Message);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBeer(int id, [FromHeader] string username)
        {
            try
            {
                User user = authManager.TryGetUser(username);
                bool beerDeleted = beersService.Delete(id, user);

                return Ok(beerDeleted);
            }
            catch (UnauthorizedOperationException e)
            {
                return Unauthorized(e.Message);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
