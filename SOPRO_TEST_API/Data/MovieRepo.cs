using Microsoft.EntityFrameworkCore;
using SOPRO_TEST_API.Models;
using SOPRO_TEST_API.Models.Context;

namespace SOPRO_TEST_API.Data
{
    public class MovieRepo : IMovieRepo
    {
        private readonly ApiContext _context;

        public MovieRepo(ApiContext context)
        {
            _context = context;
        }
        public void CreateMovie(Movie movie)
        {
            if (movie == null) 
            {
                throw new ArgumentNullException();
            }
            _context.Movies.Add(movie);
            
        }

        public bool DeleteMovie(int id)
        {
            if (!MovieExists(id))
            {
                return false;
            }
            _context.Movies.Remove(_context.Movies.Find(id));
            return true;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        public Movie GetMovie(int id)
        {
            return _context.Movies.Find(id);
        }

        public bool SaveChanges()
        {
            var ret = _context.SaveChanges();
            if (ret > 0)
            {
                return true;
            }
            else { return false; }
        }

        public void UpdateMovie(int id, Movie movie)
        {
            if (!MovieExists(id))
            {
                throw new Exception("Not Found");
            }
            _context.Entry(movie).State = EntityState.Modified;
        }

        public bool MovieExists(int id)
        {
            return (_context.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
