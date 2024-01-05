using System.Collections.Generic;

using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Services;

using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemo.Controllers.Api
{
    [ApiController]
    [Route("api/styles")]
    public class StylesApiController : ControllerBase
    {
        private readonly IStylesService stylesService;

        public StylesApiController(IStylesService stylesService)
        {
            this.stylesService = stylesService;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            List<Style> styles = stylesService.GetAll();

            return Ok(styles);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Style style = stylesService.GetById(id);

                return Ok(style);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}