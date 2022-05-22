using Microsoft.EntityFrameworkCore;
using SOPRO_TEST_API.Models;
using SOPRO_TEST_API.Models.Context;

namespace SOPRO_TEST_API.Data
{
    public class PersonRepo : IPersonRepo
    {
        private readonly ApiContext _context;

        public PersonRepo(ApiContext context)
        {
            _context = context;
        }

        public void CreatePerson(Person person)
        {
            if (person==null)
            {
                throw new ArgumentNullException();
            }
            _context.People.Add(person);

        }

        public bool DeletePeople(int id)
        {
            if (!PersonExists(id))
            {
                return false;
            }
             _context.People.Remove(_context.People.Find(id));
            return true;
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _context.People.ToList();
        }

        public Person GetPersons(int id)
        {
            return _context.People.Find(id);
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

        public void UpdatePersons(int id, Person person)
        {
            if (!PersonExists(id))
            {
                throw new Exception("Not Found");
            }
            _context.Entry(person).State = EntityState.Modified;
        }

        public bool PersonExists(int id)
        {
            return (_context.People?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }

}
