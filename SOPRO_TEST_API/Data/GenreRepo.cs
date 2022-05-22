using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOPRO_TEST_API.Models;
using SOPRO_TEST_API.Models.Context;

namespace SOPRO_TEST_API.Data
{
    public class GenreRepo : IGenreRepo
    {
        private readonly ApiContext _context;

        public GenreRepo(ApiContext context)
        {
            _context = context;
        }
        public void CreateGanre(Genre genre)
        {
            if (genre == null) 
            {
                throw new ArgumentNullException();
            }
            _context.Genres.Add(genre);
        
        }


        public bool DeleteGenre(int id)
        {
            if (_context.Genres.Find(id)!=null)
            {
                _context.Genres.Remove(_context.Genres.Find(id));
                return true;
            }
            return false;
        }

        public IEnumerable<Genre> GetAllGanres()
        {
            /*if (!_context.Genres.Any())
            {
                
            }*/
            return _context.Genres.ToList();

        }

        public Genre GetGanre(int id)
        {
            return _context.Genres.FirstOrDefault(gen => gen.Id == id);
            
        }

        public bool SaveChanges()
        {
            var ret=_context.SaveChanges();
            if (ret>0)
            {
                return true;
            }
            else {  return false;  }
        }

        public void UpdateGanre(int id ,Genre genre)
        {
            _context.Entry(genre).State = EntityState.Modified;

            
        }
        public bool GenreExists(int id)
        {
            return (_context.Genres?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
