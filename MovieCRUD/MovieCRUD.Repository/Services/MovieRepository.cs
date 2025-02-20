using System.Text.Json;
using MovieCRUD.DataAccess.Entities;

namespace MovieCRUD.Repository.Services;

public class MovieRepository : IMovieRepository
{
    private readonly string _path;
    private List<Movie> _movies;

    public MovieRepository()
    {
        _path = Path.Combine(Directory.GetCurrentDirectory(), "Movie.json");

        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]"); 
        }

        _movies = GetAll();
    }

    public Guid Add(Movie movie)
    {
        movie.Id = Guid.NewGuid();
        _movies.Add(movie);
        SaveData();
        return movie.Id;
    }

    public void Delete(Guid id)
    {
        var res = _movies.FirstOrDefault(x => x.Id == id);
        if (res != null)
        {
            _movies.Remove(res);
            SaveData();
        }
        throw new Exception("Id isn't found");
    }

    public List<Movie> GetAll()
    {
        var jsonMovie = File.ReadAllText(_path);
        var movieList = JsonSerializer.Deserialize<List<Movie>>(jsonMovie) ?? new List<Movie>();
        return movieList;
    }

    public Movie GetById(Guid id)
    {
        var res  = _movies.FirstOrDefault(x => x.Id == id) ?? throw new Exception("ID no found");
        return res;
    }

    public void Update(Movie movie)
    {
        var res = _movies.FirstOrDefault(x => x.Id == movie.Id);
        if (res != null)
        {
            _movies.Remove(res);
            _movies.Add(movie);
        }
        SaveData();
    }

    private void SaveData()
    {
        var jsonData = JsonSerializer.Serialize(_movies);
        File.WriteAllText(_path, jsonData);
    }
}
