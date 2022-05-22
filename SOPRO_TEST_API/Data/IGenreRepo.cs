using SOPRO_TEST_API.Models;

namespace SOPRO_TEST_API.Data
{
    public interface IGenreRepo
    {
        bool SaveChanges();
        void CreateGanre(Genre genre);

        IEnumerable<Genre> GetAllGanres();
        Genre GetGanre(int id);

        bool DeleteGenre(int id);

        void UpdateGanre(int id, Genre genre);

        public bool GenreExists(int id);
    }
}
