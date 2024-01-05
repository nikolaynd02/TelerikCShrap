using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspNetCoreDemo.Controllers
{
    public class BeersController : Controller
    {
        private readonly IBeersService beersService;

        public BeersController(IBeersService beersService)
        {
            this.beersService = beersService;
        }

        public IActionResult Index()
        {
            List<Beer> beers = beersService.GetAll();

            return View(beers);
        }

        public IActionResult Details(int id)
        {
            try
            {
                Beer beer = beersService.GetById(id);

                return View(beer);
            }
            catch (EntityNotFoundException ex)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                ViewData["ErrorMessage"] = ex.Message;

                return View("Error");
            }
            
        }
    }
}
