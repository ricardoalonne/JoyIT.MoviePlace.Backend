using JoyIT.MoviePlace.DataTransferObject.Response;
using JoyIT.MoviePlace.Test.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JoyIT.MoviePlace.Test.Models.DataTransferObject.Response
{
    [TestClass]
    public class MovieResponseDTOTest
    {
        private readonly DateTime _dateTimeNow = DateTime.UtcNow;

        [TestMethod]
        public void ConstructorByEntity()
        {
            // Data preparation
            var entity = new Entity.Movie()
            {
                Id = 1,
                Title = "Avengers: Infinity War",
                Synopsis = "Esta película es la finalización de la fase 3 del MCU.",
                Duration = "02:30:00",
                PosterUrl = "img/avengers-infity-war",
                TrailerUrl = "video/avengers-infity-war",
                MovieCategoryId = 1,
                ReleaseDate = _dateTimeNow,
                IsActive = true,
            };

            var result = new MovieResponseDTO()
            {
                Id = 1,
                Title = "Avengers: Infinity War",
                Synopsis = "Esta película es la finalización de la fase 3 del MCU.",
                Duration = "02:30:00",
                PosterUrl = "img/avengers-infity-war",
                TrailerUrl = "video/avengers-infity-war",
                MovieCategory = new MovieCategoryResponseDTO() { Id = 1, },
                ReleaseDate = _dateTimeNow,
                IsActive = true,
            };

            //Testing
            var constructorByEntity = new MovieResponseDTO(entity);

            //Check
            Assert.IsTrue(ObjectComparerUtility.ObjectsAreEqual(result, constructorByEntity));
        }

        [TestMethod]
        public void ConvertToEntity()
        {
            // Data preparation
            var dto = new MovieResponseDTO()
            {
                Id = 1,
                Title = "Avengers: Infinity War",
                Synopsis = "Esta película es la finalización de la fase 3 del MCU.",
                Duration = "02:30:00",
                PosterUrl = "img/avengers-infity-war",
                TrailerUrl = "video/avengers-infity-war",
                MovieCategory = new MovieCategoryResponseDTO() { Id = 1, Name = "Terror", Description = "Terror", IsActive = true },
                ReleaseDate = _dateTimeNow,
                IsActive = true,
            };

            var result = new Entity.Movie()
            {
                Id = 1,
                Title = "Avengers: Infinity War",
                Synopsis = "Esta película es la finalización de la fase 3 del MCU.",
                Duration = "02:30:00",
                PosterUrl = "img/avengers-infity-war",
                TrailerUrl = "video/avengers-infity-war",
                MovieCategoryId = 1,
                ReleaseDate = _dateTimeNow,
                IsActive = true,
            };

            //Testing
            var convertionToEntity = dto.ToEntity();

            //Check
            Assert.IsTrue(ObjectComparerUtility.ObjectsAreEqual(result, convertionToEntity));
        }
    }
}
