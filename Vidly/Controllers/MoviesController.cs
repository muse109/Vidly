using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        List<Movie> Movies = new List<Movie>
        {
            new Movie{Name = "The Fountain"},
            new Movie{Name = "Lord Of The Rings"}
        };



        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() {
                Name = "The Fountain"
            };


            var customers = new List<Customer> {

                new Customer { Id = 1, Name = "Santiago Valencia" },
                new Customer { Id = 2, Name = "Johanna Jimenez" }

            };


            var ViewModel = new RandomMovieViewModel
            {
                Movie= movie,
                Customers= customers
            };
          
            return View(ViewModel);
            //return Content("Hola!");
            //return HttpNotFound();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        public ActionResult Edit(int Id) {

            return Content("Id=" + Id);

        }

        //public ActionResult Index(int? pageIndex, string sortBy) {

        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";


        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}


        public ActionResult Index()
        {

            var peliculas = GetMovies();


            return View(peliculas);
        }


        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/"+ month);
        }


        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie{Name = "The Fountain"},
                new Movie{Name = "Lord Of The Rings"}
            };

        }


    }
}