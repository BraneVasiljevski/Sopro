using System.ComponentModel.DataAnnotations;

namespace SOPRO_TEST_API.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Movie Movie { get; set; }


    }
}
