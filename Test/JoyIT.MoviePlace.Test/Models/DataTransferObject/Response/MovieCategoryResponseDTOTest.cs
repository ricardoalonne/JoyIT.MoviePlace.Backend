using JoyIT.MoviePlace.DataTransferObject.Response;
using JoyIT.MoviePlace.Test.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JoyIT.MoviePlace.Test.Models.DataTransferObject.Response
{
    [TestClass]
    public class MovieCategoryResponseDTOTest
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

            var result = new MovieCategoryResponseDTO()
            {
                Id = 1,
                Name = "Terror",
                Description = "Terror",
                IsActive = true,
            };

            //Testing
            var constructorByEntity = new MovieCategoryResponseDTO(entity);

            //Check
            Assert.IsTrue(ObjectComparerUtility.ObjectsAreEqual(result, constructorByEntity));
        }

        [TestMethod]
        public void ConvertToEntity()
        {
            // Data preparation
            var dto = new MovieCategoryResponseDTO()
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
    }
}
