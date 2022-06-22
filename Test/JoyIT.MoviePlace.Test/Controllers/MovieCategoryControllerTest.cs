using JoyIT.MoviePlace.DataTransferObject.Request;
using JoyIT.MoviePlace.DataTransferObject.Response;
using JoyIT.MoviePlace.Service.Implementation;
using JoyIT.MoviePlace.Service.Interface;
using JoyIT.MoviePlace.Test.Controllers.Base;
using JoyIT.MoviePlace.UnitOfWork.Interface;
using JoyIT.MoviePlace.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JoyIT.MoviePlace.Test.Controllers
{
    [TestClass]
    public class MovieCategoryControllerTest : ControllerTestBase
    {
        public readonly string _connectionString;

        public MovieCategoryControllerTest()
        {
            _connectionString = Guid.NewGuid().ToString();
        }

        [TestMethod]
        public async Task GetAll()
        {
            //Data preparation
            var context = BuildContext(_connectionString);
            await context.MovieCategories.AddAsync(new Entity.MovieCategory() { Name = "Terror", Description = "Terror", IsActive = true });
            await context.MovieCategories.AddAsync(new Entity.MovieCategory() { Name = "Romance", Description = "Romance", IsActive = false });
            await context.SaveChangesAsync();

            //Testing
            var contextTesting = BuildContext(_connectionString);
            IUnitOfWork unitOfWork = new UnitOfWork.Implementation.UnitOfWork(contextTesting);
            IMovieCategoryService permissionTypeService = new MovieCategoryService(unitOfWork);
            var permissionTypeController = new MovieCategoryController(permissionTypeService);
            var response = await permissionTypeController.GetAll() as ObjectResult;

            //Check
            var permissions = response.Value as List<MovieCategoryResponseDTO>;
            Assert.AreEqual(2, permissions.Count);
        }

        [TestMethod]
        public async Task Get()
        {
            //Data preparation
            var context = BuildContext(_connectionString);
            await context.MovieCategories.AddAsync(new Entity.MovieCategory() { Name = "Terror", Description = "Terror", IsActive = true });
            await context.MovieCategories.AddAsync(new Entity.MovieCategory() { Name = "Romance", Description = "Romance", IsActive = false });
            await context.SaveChangesAsync();

            //Testing
            var contextTesting = BuildContext(_connectionString);
            IUnitOfWork unitOfWork = new UnitOfWork.Implementation.UnitOfWork(contextTesting);
            IMovieCategoryService permissionTypeService = new MovieCategoryService(unitOfWork);
            var permissionTypeController = new MovieCategoryController(permissionTypeService);
            var response = await permissionTypeController.Get() as ObjectResult;

            //Check
            var permissions = response.Value as List<MovieCategoryResponseDTO>;
            Assert.AreEqual(1, permissions.Count);
        }

        [TestMethod]
        public async Task GetById()
        {
            //Data preparation
            var context = BuildContext(_connectionString);
            await context.MovieCategories.AddAsync(new Entity.MovieCategory() { Name = "Terror", Description = "Terror", IsActive = true });
            await context.MovieCategories.AddAsync(new Entity.MovieCategory() { Name = "Romance", Description = "Romance", IsActive = false });
            await context.SaveChangesAsync();

            //Testing
            var contextTesting = BuildContext(_connectionString);
            IUnitOfWork unitOfWork = new UnitOfWork.Implementation.UnitOfWork(contextTesting);
            IMovieCategoryService permissionTypeService = new MovieCategoryService(unitOfWork);
            var permissionTypeController = new MovieCategoryController(permissionTypeService);
            var response = await permissionTypeController.Get(1) as ObjectResult;

            //Check
            var result = response.StatusCode;
            //Assert.AreEqual(404, result);
            Assert.AreEqual(200, result);
        }


        [TestMethod]
        public async Task Post()
        {
            //Data preparation
            var context = BuildContext(_connectionString);
            var newMovieCategory = new Entity.MovieCategory() { Name = "Terror", Description = "Terror", IsActive = true };
            IUnitOfWork unitOfWork = new UnitOfWork.Implementation.UnitOfWork(context);
            IMovieCategoryService permissionTypeService = new MovieCategoryService(unitOfWork);
            var permissionTypeController = new MovieCategoryController(permissionTypeService);
            var response = await permissionTypeController.Post(new MovieCategoryRequestDTO(newMovieCategory));
            var result = response as ObjectResult;
            Assert.IsNotNull(result.Value);

            //Testing
            var contextTesting = BuildContext(_connectionString);
            var count = await contextTesting.MovieCategories.CountAsync();
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public async Task Put()
        {
            //Data preparation
            var context = BuildContext(_connectionString);
            var permissionTypeTest = new Entity.MovieCategory() { Name = "Terror", Description = "Terror", IsActive = true };
            await context.MovieCategories.AddAsync(permissionTypeTest);
            await context.SaveChangesAsync();

            //Testing
            var contextTesting = BuildContext(_connectionString);
            IUnitOfWork unitOfWork = new UnitOfWork.Implementation.UnitOfWork(contextTesting);
            IMovieCategoryService permissionTypeService = new MovieCategoryService(unitOfWork);
            var permissionTypeController = new MovieCategoryController(permissionTypeService);
            permissionTypeTest.Description = "Type 1.2";
            var response = await permissionTypeController.Put(1, new MovieCategoryRequestDTO(permissionTypeTest)) as ObjectResult;
            Assert.AreEqual(201, response.StatusCode);

            //Testing
            var contextTestingDb = BuildContext(_connectionString);
            var exist = await contextTestingDb.MovieCategories.AnyAsync(type => type.Description == permissionTypeTest.Description);
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public async Task Delete()
        {
            //Data preparation
            var context = BuildContext(_connectionString);
            var permissionTypeTest = new Entity.MovieCategory() { Name = "Terror", Description = "Terror", IsActive = true };
            await context.MovieCategories.AddAsync(permissionTypeTest);
            await context.SaveChangesAsync();

            //Testing
            var contextTesting = BuildContext(_connectionString);
            IUnitOfWork unitOfWork = new UnitOfWork.Implementation.UnitOfWork(contextTesting);
            IMovieCategoryService permissionTypeService = new MovieCategoryService(unitOfWork);
            var permissionTypeController = new MovieCategoryController(permissionTypeService);
            var response = await permissionTypeController.Delete(1) as ObjectResult;
            Assert.AreEqual(200, response.StatusCode);

            var contextTestingDb = BuildContext(_connectionString);
            var permissionTypeInDb = await contextTestingDb.MovieCategories.SingleOrDefaultAsync(type => type.Id == 1);
            Assert.IsFalse(permissionTypeInDb.IsActive);
        }
    }
}
