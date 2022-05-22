using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOPRO_TEST_API.Data;
using SOPRO_TEST_API.Models;
using SOPRO_TEST_API.Models.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SOPRO_TEST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonRepo _repo;

        public PeopleController(IPersonRepo repo)
        {
            _repo = repo;
        }
        // GET: api/<PeopleController>
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _repo.GetAllPersons();
        }

        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return _repo.GetPersons(id);
        }

        // POST api/<PeopleController>
        [HttpPost]
        public void Post(PersonDTO personDTO)
        {
            var person = new Person();
            person.Id = 0;
            person.Name = personDTO.Name;
            person.Role = personDTO.Role;
            _repo.CreatePerson(person);
            _repo.SaveChanges();
        }

        // PUT api/<PeopleController>/5
        [HttpPut("{id}")]
        public void Put(int id, PersonDTO personDTO)
        {
            var person = new Person();
            person.Id = id;
            person.Name = personDTO.Name;
            person.Role = personDTO.Role;
            _repo.UpdatePersons(id, person);
            try
            {
                _repo.SaveChanges();
            }
            catch (DbUpdateConcurrencyException a)
            {
                throw new Exception(a.Message);
            }
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.DeletePeople(id);
            _repo.SaveChanges();
        }
    }
}
