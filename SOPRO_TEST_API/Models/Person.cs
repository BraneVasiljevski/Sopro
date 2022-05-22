namespace SOPRO_TEST_API.Models
{
    public class Person
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public string Role { get; set; }
        public virtual Movie Movie { get; set; }

    }
}
