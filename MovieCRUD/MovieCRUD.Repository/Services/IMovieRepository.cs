using MovieCRUD.DataAccess.Entities;

namespace MovieCRUD.Repository.Services;

public interface IMovieRepository
{
    Guid Add(Movie movie);
    void Update(Movie movie);
    void Delete(Guid id);
    Movie GetById(Guid id);
    List<Movie> GetAll();
}