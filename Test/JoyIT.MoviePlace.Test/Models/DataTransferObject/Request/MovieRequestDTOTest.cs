using JoyIT.MoviePlace.DataTransferObject.Request;
using JoyIT.MoviePlace.Test.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JoyIT.MoviePlace.Test.Models.DataTransferObject.Request
{
    [TestClass]
    public class MovieRequestDTOTest
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

            var result = new MovieRequestDTO()
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
            var constructorByEntity = new MovieRequestDTO(entity);

            //Check
            Assert.IsTrue(ObjectComparerUtility.ObjectsAreEqual(result, constructorByEntity));
        }

        [TestMethod]
        public void ConvertToEntity()
        {
            // Data preparation
            var dto = new MovieRequestDTO()
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

        [TestMethod]
        public void Clone()
        {
            // Data preparation
            var dto = new MovieRequestDTO()
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

            var result = new MovieRequestDTO()
            {
                Id = 2,
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
            var clonation = dto.Clone(2);

            //Check
            Assert.IsTrue(ObjectComparerUtility.ObjectsAreEqual(result, clonation));
        }
    }
}
