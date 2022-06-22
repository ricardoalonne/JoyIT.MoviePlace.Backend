using JoyIT.MoviePlace.Common.Service;
using JoyIT.MoviePlace.DataTransferObject.Request;
using JoyIT.MoviePlace.DataTransferObject.Response;

namespace JoyIT.MoviePlace.Service.Interface
{
    public interface IMovieService : IService<MovieResponseDTO, MovieRequestDTO>
    {
    }
}
