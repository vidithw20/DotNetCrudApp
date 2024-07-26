using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleCrudApplication.Data;
using SampleCrudApplication.Models;
using SampleCrudApplication.Models.Entities;
using System.Reflection;

namespace SampleCrudApplication.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public MoviesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Add(AddMoviesViewModel viewModel)
        {

            var movie = new Movies
            {
                Title = viewModel.Title,
                Genre = viewModel.Genre,
                Rating = viewModel.Rating,
                DirectorName = viewModel.DirectorName,
                ReleaseDate = viewModel.ReleaseDate



            };

            await dbContext.Movies.AddAsync(movie);

            await dbContext.SaveChangesAsync();

        return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var movies = await dbContext.Movies.ToListAsync();

            return View(movies);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var movie = await dbContext.Movies.FindAsync(id);

            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Movies viewModel)
        {
            var movie = await dbContext.Movies.FindAsync(viewModel.Id);

            if (movie is not null)
            {   
                movie.Title = viewModel.Title;
                movie.Genre = viewModel.Genre;
                movie.Rating = viewModel.Rating;
                movie.DirectorName = viewModel.DirectorName;
                movie.ReleaseDate = viewModel.ReleaseDate;

                await dbContext.SaveChangesAsync();

            }

            return RedirectToAction("List", "Movies");
            
            
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Movies viewModel)
        {
            var movie = await dbContext.Movies
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (movie is not null)
            {
                dbContext.Movies.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Movies");
        }

    }
}
