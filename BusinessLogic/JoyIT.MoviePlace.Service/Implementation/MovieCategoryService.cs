using JoyIT.MoviePlace.DataTransferObject.Request;
using JoyIT.MoviePlace.DataTransferObject.Response;
using JoyIT.MoviePlace.Service.Interface;
using JoyIT.MoviePlace.UnitOfWork.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoyIT.MoviePlace.Service.Implementation
{
    public class MovieCategoryService : IMovieCategoryService
    {
        private IUnitOfWork _unitOfWork;

        public MovieCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<MovieCategoryResponseDTO>> GetAll()
        {
            using (var connection = _unitOfWork.Create())
            {
                var movieCategoriesEntity = await connection.Repository.IMovieCategoryRepository.GetAll();
                var movieCategories = movieCategoriesEntity.Select(movieCategory => new MovieCategoryResponseDTO(movieCategory)).ToList();
                return movieCategories;
            }
        }

        public async Task<List<MovieCategoryResponseDTO>> Get()
        {
            using (var connection = _unitOfWork.Create())
            {
                var movieCategoriesEntity = await connection.Repository.IMovieCategoryRepository.Get();
                var movieCategories = movieCategoriesEntity.Select(movieCategory => new MovieCategoryResponseDTO(movieCategory)).ToList();
                return movieCategories;
            }
        }

        public async Task<MovieCategoryResponseDTO> Get(int id)
        {
            using (var connection = _unitOfWork.Create())
            {
                var movieCategoryEntity = await connection.Repository.IMovieCategoryRepository.Get(id);
                return new MovieCategoryResponseDTO(movieCategoryEntity);
            }
        }

        public async Task<bool> Post(MovieCategoryRequestDTO requestModel)
        {
            using (var connection = _unitOfWork.Create())
            {
                await connection.Repository.IMovieCategoryRepository.Create(requestModel.ToEntity());
                var result = await connection.SaveChanges();
                return result > 0;
            }
        }

        public async Task<bool> Put(MovieCategoryRequestDTO requestModel)
        {
            using (var connection = _unitOfWork.Create())
            {
                await connection.Repository.IMovieCategoryRepository.Update(requestModel.ToEntity());
                var result = await connection.SaveChanges();
                return result > 0;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var connection = _unitOfWork.Create())
            {
                await connection.Repository.IMovieCategoryRepository.Remove(id);
                var result = await connection.SaveChanges();
                return result > 0;
            }
        }

    }
}
