using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieCRUD.Service.DTOs;
using MovieCRUD.Service.Service;

namespace MovieCRUD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController()
        {
            _movieService = new MovieService();
        }

        [HttpPost("addMovie")]
        public Guid Add(MovieDto movieDto)
        {
            return _movieService.AddMovie(movieDto);
        }

        [HttpGet("getAllMovie")]
        public List<MovieDto> GetAll()
        {
            return _movieService.GetAll();
        }

        [HttpDelete("deleteMovie")]
        public void Delete(Guid id)
        {
            _movieService.DeleteMovie(id);
        }

        [HttpPut("updateMovie")]
        public void Put(MovieDto movieDto)
        {
            _movieService.UpdateMovie(movieDto);
        }

        [HttpGet("getAllMoviesByDirector")]
        public List<MovieDto> GetMovieDtosByAuthor(string director)
        {
            return _movieService.GetAllMoviesByDirector(director);
        }

        [HttpGet("getTopRatedMovie")]
        public MovieDto GetTopMovie()
        {
            return _movieService.GetTopRatedMovie();
        }

        [HttpGet("getMoviesReleasedAfterYear")]
        public List <MovieDto> GetMovieDtosAfterDate(DateTime time)
        {
            return _movieService.GetMoviesReleasedAfterYear(time);
        }

        [HttpGet("getHighestGrossingMovie")]
        public MovieDto GetHighestGrossingMovie()
        {
            return _movieService.GetHighestGrossingMovie();
        }

        [HttpGet("searchMoviesByTitle")]
        public List<MovieDto > GetMovieDtosByTitle(string title)
        {
            return _movieService.SearchMoviesByTitle(title);
        }

        [HttpGet("getMoviesWithinDurationRange")]
        public List<MovieDto> GetMovieDtosWithinDurationRange(int minMinutes, int maxMinutes)
        {
            return _movieService.GetMoviesWithinDurationRange(minMinutes, maxMinutes);
        }

        [HttpGet("getTotalBoxOfficeEarningsByDirector")]
        public long GetTotalBoxOfficeEarningsByDirector(string director)
        {
            return _movieService.GetTotalBoxOfficeEarningsByDirector(director);
        }

        [HttpGet("getMoviesSortedByRating")]
        public List<MovieDto> SortedDtos()
        {
            return _movieService.GetMoviesSortedByRating();
        }

        [HttpGet("getRecentMovies")]
        public List<MovieDto> GetMovieDtosByDate(DateTime time)
        {
            return _movieService.GetRecentMovies(time);
        }
    }
}
