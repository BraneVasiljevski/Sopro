using Microsoft.EntityFrameworkCore;

namespace SOPRO_TEST_API.Models.Context
{
    public class ApiContext:DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options):base(options)
        {

        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Person> People { get; set; }  
        public DbSet<Movie> Movies { get; set; }
    }
}
