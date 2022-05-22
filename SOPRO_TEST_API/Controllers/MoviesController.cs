using Microsoft.AspNetCore.Mvc;
using SOPRO_TEST_API.Data;
using SOPRO_TEST_API.Models;
using SOPRO_TEST_API.Models.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SOPRO_TEST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepo _repo;
        private readonly IPersonRepo _personRepo;
        private readonly IGenreRepo _gerneRepo;

        public MoviesController(IMovieRepo repo,IPersonRepo personRepo,IGenreRepo genreRepo)
        {
            _repo = repo;
            _personRepo = personRepo;
            _gerneRepo = genreRepo;
        }
        // GET: api/<MoviesController>
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return _repo.GetAllMovies().ToList();
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MoviesController>
        [HttpPost]
        public void Post(MovieDTO movieDTO)
        {
            Movie movie = new Movie();
            movie.Id = 0;
            movie.Title = movieDTO.Title;
            
            foreach (var item in movieDTO.genres)
            {
                if (_gerneRepo.GenreExists(item))
                {
                    movie.genres.Add(_gerneRepo.GetGanre(item));
                }
                else
                {
                    throw new Exception("Genre does not exist!");
                }
            }
            foreach (var item in movieDTO.people) 
            {
                if (_personRepo.PersonExists(item))
                {
                    movie.people.Add(_personRepo.GetPersons(item));
                }
                else
                {
                    throw new Exception("Person does not exist!");
                }
                
            }
            _repo.CreateMovie(movie);
            _repo.SaveChanges();

        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
