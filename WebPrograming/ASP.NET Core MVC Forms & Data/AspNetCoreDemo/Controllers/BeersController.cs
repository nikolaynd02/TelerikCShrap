using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Helpers;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace AspNetCoreDemo.Controllers
{
    public class BeersController : Controller
    {
        private readonly IBeersService beersService;
        private readonly IStylesService stylesService;
        private readonly AuthManager authManager;
        private readonly IModelMapper modelMapper;

        public BeersController(IBeersService beersService, IStylesService stylesService, AuthManager authManager, IModelMapper modelMapper)
        {
            this.beersService = beersService;
            this.stylesService = stylesService;
            this.authManager = authManager;
            this.modelMapper = modelMapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Beer> beers = beersService.GetAll();

            return View(beers);
        }

        [HttpGet]
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

        [HttpGet]
        public IActionResult Create()
        {
            BeerViewModel beer = new BeerViewModel();

            var styles = stylesService.GetAll();

            beer.Styles = new SelectList(styles,"Id","Name");
            return View(beer);
        }

        [HttpPost]
        public IActionResult Create(BeerViewModel beer)
        {
            beer.Styles = new SelectList(stylesService.GetAll(), "Id", "Name");

            if (!ModelState.IsValid)
            {
                return View(beer);
            }
            try
            {
                var newBeer = modelMapper.Map(beer);

                var user = authManager.TryGetUser("admin");


                beersService.Create(newBeer, user);

                return RedirectToAction("Details","Beers",new { Id = newBeer.Id });
            }
            catch (Exception ex)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                //ViewData["ErrorMessage"] = ex.Message;
                ModelState.AddModelError("Name", ex.Message);
                return View(beer);
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            try
            {
                Beer beer = beersService.GetById(id);

                var beerViewModel = modelMapper.MapViewModel(beer);
                beerViewModel.Styles = new SelectList(stylesService.GetAll(), "Id", "Name");

                return View(beerViewModel);
            }
            catch (EntityNotFoundException ex)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                ViewData["ErrorMessage"] = ex.Message;

                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult Update([FromRoute]int id ,BeerViewModel beer)
        {
            beer.Styles = new SelectList(stylesService.GetAll(), "Id", "Name");

            if (!ModelState.IsValid)
            {
                return View(beer);
            }
            try
            {
                var newBeer = modelMapper.Map(beer);

                var user = authManager.TryGetUser("admin");


                beersService.Update(id,newBeer, user);

                return RedirectToAction("Details", "Beers", new { Id = id });
            }
            catch (Exception ex)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                //ViewData["ErrorMessage"] = ex.Message;
                ModelState.AddModelError("Name", ex.Message);
                return View(beer);
            }
        }

        [HttpGet]
        public IActionResult Delete([FromRoute]int id)
        {
            try
            {
                var user = authManager.TryGetUser("admin");
                beersService.Delete(id, user);

                return RedirectToAction("Index", "Beers");
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
