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
    public class MovieCategoryController : ControllerBase
    {
        private readonly IMovieCategoryService _movieCategoryService;

        public MovieCategoryController(IMovieCategoryService movieCategoryService)
        {
            _movieCategoryService = movieCategoryService;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var movieCategories = await _movieCategoryService.GetAll();

                if (movieCategories == null) return NotFound(movieCategories);

                return Ok(movieCategories);
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
                var movieCategories = await _movieCategoryService.Get();

                if (movieCategories == null) return NotFound(movieCategories);

                return Ok(movieCategories);

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
                var movieCategories = await _movieCategoryService.Get(id);

                if (movieCategories == null) return NotFound(movieCategories);

                return Ok(movieCategories);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MovieCategoryRequestDTO movieCategory)
        {
            try
            {

                var response = await _movieCategoryService.Post(movieCategory);

                if (response) return new ObjectResult(movieCategory) { StatusCode = StatusCodes.Status201Created };
                else return BadRequest(response);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MovieCategoryRequestDTO movieCategory)
        {
            try
            {

                if (id <= 0 && movieCategory.Id <= 0) { return new ObjectResult(movieCategory) { StatusCode = StatusCodes.Status304NotModified }; }

                if (movieCategory.Id <= 0 && id > 0)
                {
                    movieCategory = movieCategory.Clone(id);
                }

                var response = await _movieCategoryService.Put(movieCategory);

                if (response) return new ObjectResult(movieCategory) { StatusCode = StatusCodes.Status201Created };
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
                var response = await _movieCategoryService.Delete(id);

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
