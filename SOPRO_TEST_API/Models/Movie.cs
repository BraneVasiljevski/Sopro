namespace SOPRO_TEST_API.Models
{
    public class Movie
    {
        public Movie()
        {
            genres = new List<Genre>();
            people = new List<Person>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual List<Genre> genres { get; set; }
        public virtual List<Person> people { get; set; }
    }
}
