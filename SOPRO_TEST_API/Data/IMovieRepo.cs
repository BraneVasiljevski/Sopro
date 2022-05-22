using SOPRO_TEST_API.Models;

namespace SOPRO_TEST_API.Data
{
    public interface IMovieRepo
    {
        bool SaveChanges();
        void CreateMovie(Movie movie);

        IEnumerable<Movie> GetAllMovies();
        Movie GetMovie(int id);

        bool DeleteMovie(int id);

        void UpdateMovie(int id, Movie movie);

        public bool MovieExists(int id);
    }
}
