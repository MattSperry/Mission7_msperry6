using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission6_msperry6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6_msperry6.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _movieContext { get; set; }

        public HomeController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult MovieForm(Movie m)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Add(m);
                _movieContext.SaveChanges();
                return View("Confirmation", m);
            }
            else //If Invalid
            {
                ViewBag.Categories = _movieContext.Categories.ToList();

                return View(m);
            }
            
        }

        [HttpGet]
        public IActionResult MovieTable()
        {
            var table = _movieContext.Movies
                .Include(x => x.Category)
                .ToList();

            return View(table);
        }
        [HttpGet]
        public IActionResult Edit (int Id)
        {
            ViewBag.Categories = _movieContext.Categories.ToList();

            var movie = _movieContext.Movies.Single(x => x.Id == Id);

            return View("MovieForm", movie);
        }
        [HttpPost]
        public IActionResult Edit (Movie m)
        {
            _movieContext.Update(m);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieTable");
        }
        [HttpGet]
        public IActionResult Delete (int Id)
        {
            var movie = _movieContext.Movies.Single(x => x.Id == Id);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete (Movie m)
        {
            _movieContext.Movies.Remove(m);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieTable");
        }
    }
}
