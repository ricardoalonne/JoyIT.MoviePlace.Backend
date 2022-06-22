using JoyIT.MoviePlace.DataTransferObject.Request;
using JoyIT.MoviePlace.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace JoyIT.MoviePlace.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var movies = await _movieService.GetAll();

                if (movies == null) return NotFound(movies);

                return Ok(movies);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var movies = await _movieService.Get();

                if (movies == null) return NotFound(movies);

                return Ok(movies);

            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var movies = await _movieService.Get(id);

                if (movies == null) return NotFound(movies);

                return Ok(movies);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MovieRequestDTO movie)
        {
            try
            {

                var response = await _movieService.Post(movie);

                if (response) return new ObjectResult(movie) { StatusCode = StatusCodes.Status201Created };
                else return BadRequest(response);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MovieRequestDTO movie)
        {
            try
            {

                if (id <= 0 && movie.Id <= 0) { return new ObjectResult(movie) { StatusCode = StatusCodes.Status304NotModified }; }

                if (movie.Id <= 0 && id > 0)
                {
                    movie = movie.Clone(id);
                }

                var response = await _movieService.Put(movie);

                if (response) return new ObjectResult(movie) { StatusCode = StatusCodes.Status201Created };
                else return BadRequest(response);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _movieService.Delete(id);

                if (response) return Ok(response);
                else return BadRequest(response);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
