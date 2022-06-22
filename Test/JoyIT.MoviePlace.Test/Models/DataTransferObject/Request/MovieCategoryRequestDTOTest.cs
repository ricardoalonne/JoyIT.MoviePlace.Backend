using JoyIT.MoviePlace.DataTransferObject.Request;
using JoyIT.MoviePlace.Test.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JoyIT.MoviePlace.Test.Models.DataTransferObject.Request
{
    [TestClass]
    public class MovieCategoryRequestDTOTest
    {
        [TestMethod]
        public void ConstructorByEntity()
        {
            // Data preparation
            var entity = new Entity.MovieCategory()
            {
                Id = 1,
                Name = "Terror",
                Description = "Terror",
                IsActive = true,
            };

            var result = new MovieCategoryRequestDTO()
            {
                Id = 1,
                Name = "Terror",
                Description = "Terror",
                IsActive = true,
            };

            //Testing
            var constructorByEntity = new MovieCategoryRequestDTO(entity);

            //Check
            Assert.IsTrue(ObjectComparerUtility.ObjectsAreEqual(result, constructorByEntity));
        }

        [TestMethod]
        public void ConvertToEntity()
        {
            // Data preparation
            var dto = new MovieCategoryRequestDTO()
            {
                Id = 1,
                Name = "Terror",
                Description = "Terror",
                IsActive = true,
            };

            var result = new Entity.MovieCategory()
            {
                Id = 1,
                Name = "Terror",
                Description = "Terror",
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
            var dto = new MovieCategoryRequestDTO()
            {
                Id = 1,
                Name = "Terror",
                Description = "Terror",
                IsActive = true,
            };

            var result = new MovieCategoryRequestDTO()
            {
                Id = 2,
                Name = "Terror",
                Description = "Terror",
                IsActive = true,
            };

            //Testing
            var clonation = dto.Clone(2);

            //Check
            Assert.IsTrue(ObjectComparerUtility.ObjectsAreEqual(result, clonation));
        }
    }
}
