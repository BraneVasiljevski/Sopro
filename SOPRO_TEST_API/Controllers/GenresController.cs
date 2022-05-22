using Microsoft.AspNetCore.Mvc;
using SOPRO_TEST_API.Data;
using SOPRO_TEST_API.Models;
using Microsoft.EntityFrameworkCore;
using SOPRO_TEST_API.Models.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SOPRO_TEST_API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepo _repo;

        public GenresController(IGenreRepo repo)
        {
            _repo = repo;
        }
        // GET: api/<GenresController>
        [HttpGet]
        public IEnumerable<Genre> Get()
        {
            return _repo.GetAllGanres().ToList();
        }

        // GET api/<GenresController>/5
        [HttpGet("{id}")]
        public Genre Get(int id)
        {
            return _repo.GetGanre(id);
        }

        // POST api/<GenresController>
        [HttpPost]
        public void Post(GenreDTO genreDTO)
        {
            var genre = new Genre();
            genre.Id = 0;
            genre.Name = genreDTO.Name;
            _repo.CreateGanre(genre);
            _repo.SaveChanges();
        }

        // PUT api/<GenresController>/5
        [HttpPut("{id}")]
        public void Put(int id, GenreDTO genreDTO)
        {
            var genre = new Genre();
            genre.Id = id;
            genre.Name=genreDTO.Name;
            _repo.UpdateGanre(id,genre);
            try
            {
                _repo.SaveChanges();
            }
            catch (DbUpdateConcurrencyException a)
            {
                throw new Exception(a.Message);
            }

            
        }

        // DELETE api/<GenresController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.DeleteGenre(id);
            _repo.SaveChanges();
        }
    }
}
