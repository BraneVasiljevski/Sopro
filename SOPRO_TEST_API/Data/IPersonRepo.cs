using SOPRO_TEST_API.Models;

namespace SOPRO_TEST_API.Data
{
    public interface IPersonRepo
    {
        bool SaveChanges();
        void CreatePerson(Person person);

        IEnumerable<Person> GetAllPersons();
        Person GetPersons(int id);

        bool DeletePeople(int id);

        void UpdatePersons(int id, Person person);

        public bool PersonExists(int id);
    }
}
