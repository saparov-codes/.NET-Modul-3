using MovieCRUD.DataAccess.Entities;
using MovieCRUD.Repository.Services;
using MovieCRUD.Service.DTOs;

namespace MovieCRUD.Service.Service;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;
    public MovieService()
    {
        _movieRepository = new MovieRepository();
    }

    public Guid AddMovie(MovieDto movieDto)
    {
        return _movieRepository.Add(ConvertToMovie(movieDto));
    }

    public void DeleteMovie(Guid id)
    {
        _movieRepository.Delete(id);
    }

    public List<MovieDto> GetAll()
    {
        var _movie = new List<MovieDto>();
        foreach (var movie in _movieRepository.GetAll())
        {
            _movie.Add(ConvertToMovieDto(movie));
        }

        return _movie;
    }

    public List<MovieDto> GetAllMoviesByDirector(string director)
    {
        return _movieRepository
                    .GetAll()
                    .Where(x => x.Director == director)
                    .Select(ConvertToMovieDto)
                    .ToList();
    }

    public MovieDto GetHighestGrossingMovie()
    {
        return _movieRepository
                    .GetAll()
                    .OrderByDescending(x => x.BoxOfficeEarnings)
                    .Select(ConvertToMovieDto)
                    .FirstOrDefault() ?? throw new Exception("There is no movie!");
    }

    public MovieDto GetMovieById(Guid id)
    {
        return ConvertToMovieDto(_movieRepository.GetById(id));
    }

    public List<MovieDto> GetMoviesReleasedAfterYear(DateTime year)
    {
        return _movieRepository 
                    .GetAll()
                    .Where(x => x.ReleaseDate < year)
                    .Select(ConvertToMovieDto)
                    .ToList();
    }

    public List<MovieDto> GetMoviesSortedByRating()
    {
        return _movieRepository
                    .GetAll()
                    .OrderByDescending (x => x.Rating)
                    .Select(ConvertToMovieDto)
                    .ToList();
    }

    public List<MovieDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes)
    {
        return _movieRepository
                    .GetAll()
                    .Where(x => x.DurationMinutes > minMinutes && x.DurationMinutes < maxMinutes)
                    .Select(ConvertToMovieDto)
                    .ToList();
    }

    public List<MovieDto> GetRecentMovies(DateTime years)
    {
        return _movieRepository
                    .GetAll()
                    .Where(x => x.ReleaseDate < years)
                    .Select(ConvertToMovieDto)
                    .ToList();
    }

    public MovieDto GetTopRatedMovie()
    {
        var res = _movieRepository.GetAll().OrderByDescending (x => x.Rating).First();
        return ConvertToMovieDto(res);
    }

    public long GetTotalBoxOfficeEarningsByDirector(string director)
    {
        return _movieRepository
                    .GetAll()
                    .Where (x => x.Director == director)
                    .Sum (x => x.BoxOfficeEarnings);
    }

    public List<MovieDto> SearchMoviesByTitle(string keyword)
    {
        return _movieRepository
                    .GetAll()
                    .Where(x=> x.Title.Contains(keyword))
                    .Select(ConvertToMovieDto)
                    .ToList();
    }

    public void UpdateMovie(MovieDto movieDto)
    {
        var movie = _movieRepository.GetAll().FirstOrDefault(x => x.Id == movieDto.Id);
        if (movie != null)
        {
            _movieRepository.Update(ConvertToMovie(movieDto));
        }
        throw new Exception("Id isn't found!");
    }

    private Movie ConvertToMovie(MovieDto movieDto)
    {
        return new Movie()
        {
            Id = movieDto.Id,
            Title = movieDto.Title,
            Director = movieDto.Director,
            DurationMinutes = movieDto.DurationMinutes,
            Rating = movieDto.Rating,
            BoxOfficeEarnings = movieDto.BoxOfficeEarnings,
            ReleaseDate = movieDto.ReleaseDate
        };
    }

    private MovieDto ConvertToMovieDto(Movie movie)
    {
        return new MovieDto()
        {
            Id = movie.Id,
            Title = movie.Title,
            Director = movie.Director,
            DurationMinutes = movie.DurationMinutes,
            Rating = movie.Rating,
            BoxOfficeEarnings = movie.BoxOfficeEarnings,
            ReleaseDate = movie.ReleaseDate
        };
    }
}
