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

    }
}
