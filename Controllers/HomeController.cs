using Assignment_9_Sage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_9_Sage.Controllers
{
    public class HomeController : Controller
    {
        private MovieListDBContext context { get; set; }
        private readonly ILogger<HomeController> _logger;

        //constructor
        public HomeController (ILogger<HomeController> logger, MovieListDBContext con)
        {
            _logger = logger;
            context = con;
        }
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterMovie()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult EnterMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                context.Movies.Add(movie);
                context.SaveChanges();
            }
            return View("Index");
        }

        public IActionResult ViewMovieList()
        {
            return View(context.Movies);
        }

        [HttpPost]
        public IActionResult DeleteMovie(int movieId)
        {
            //filter so we only return the selected movie
            Movie movie = context.Movies.Where(m => m.MovieId == movieId).FirstOrDefault();

            //remove movie
            context.Movies.Remove(movie);
            context.SaveChanges();

            return View("Index");
            //context.Movies
            //    .Where(m => m.MovieId == MovieId);
        }

        [HttpGet]
        public IActionResult EditMovie(int movieId)
        {
            //filter so we only return the selected movie
            Movie movie = context.Movies.Where(m => m.MovieId == movieId).FirstOrDefault();

            return View(movie);
        }

        [HttpPost]
        public IActionResult EditMovie(Movie movie, int movieId)
        {
            var selectedId = movie.MovieId;

            //update the DB
            context.Movies.Where(m => m.MovieId == selectedId).FirstOrDefault().Title = movie.Title;
            context.Movies.Where(m => m.MovieId == selectedId).FirstOrDefault().Category = movie.Category;
            context.Movies.Where(m => m.MovieId == selectedId).FirstOrDefault().Year = movie.Year;
            context.Movies.Where(m => m.MovieId == selectedId).FirstOrDefault().Director = movie.Director;
            context.Movies.Where(m => m.MovieId == selectedId).FirstOrDefault().Rating = movie.Rating;
            context.Movies.Where(m => m.MovieId == selectedId).FirstOrDefault().Edited = movie.Edited;
            context.Movies.Where(m => m.MovieId == selectedId).FirstOrDefault().Lent = movie.Lent;
            context.Movies.Where(m => m.MovieId == selectedId).FirstOrDefault().Notes = movie.Notes;

            context.SaveChanges();


            return View("Index");
        }












        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
