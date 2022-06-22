using JoyIT.MoviePlace.DataTransferObject.Request;
using JoyIT.MoviePlace.DataTransferObject.Response;
using JoyIT.MoviePlace.Service.Interface;
using JoyIT.MoviePlace.UnitOfWork.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoyIT.MoviePlace.Service.Implementation
{
    public class MovieService : IMovieService
    {
        private IUnitOfWork _unitOfWork;

        public MovieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<MovieResponseDTO>> GetAll()
        {
            using (var connection = _unitOfWork.Create())
            {
                var moviesEntity = await connection.Repository.IMovieRepository.GetAll();
                var types = await connection.Repository.IMovieCategoryRepository.GetAll();
                var movies = moviesEntity.Select(movie => new MovieResponseDTO(movie)
                {
                    MovieCategory = new MovieCategoryResponseDTO(types.FirstOrDefault(type => type.Id == movie.MovieCategoryId))
                }).ToList();
                return movies;
            }
        }

        public async Task<List<MovieResponseDTO>> Get()
        {
            using (var connection = _unitOfWork.Create())
            {
                var moviesEntity = await connection.Repository.IMovieRepository.Get();
                var types = await connection.Repository.IMovieCategoryRepository.GetAll();
                var movies = moviesEntity.Select(movie => new MovieResponseDTO(movie)
                {
                    MovieCategory = new MovieCategoryResponseDTO(types.FirstOrDefault(type => type.Id == movie.MovieCategoryId))
                }).ToList();
                return movies;
            }
        }

        public async Task<MovieResponseDTO> Get(int id)
        {
            using (var connection = _unitOfWork.Create())
            {
                var movieEntity = await connection.Repository.IMovieRepository.Get(id);
                return new MovieResponseDTO(movieEntity)
                {
                    MovieCategory = new MovieCategoryResponseDTO(await connection.Repository.IMovieCategoryRepository.Get(movieEntity.MovieCategoryId))
                };
            }
        }

        public async Task<bool> Post(MovieRequestDTO requestModel)
        {
            using (var connection = _unitOfWork.Create())
            {
                await connection.Repository.IMovieRepository.Create(requestModel.ToEntity());
                var result = await connection.SaveChanges();
                return result > 0;
            }
        }

        public async Task<bool> Put(MovieRequestDTO requestModel)
        {
            using (var connection = _unitOfWork.Create())
            {
                await connection.Repository.IMovieRepository.Update(requestModel.ToEntity());
                var result = await connection.SaveChanges();
                return result > 0;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var connection = _unitOfWork.Create())
            {
                await connection.Repository.IMovieRepository.Remove(id);
                var result = await connection.SaveChanges();
                return result > 0;
            }
        }

    }
}
