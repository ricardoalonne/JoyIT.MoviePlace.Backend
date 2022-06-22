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
    public class MovieControllerTest : ControllerTestBase
    {
        public readonly string _connectionString;
        private readonly DateTime _dateTimeNow = DateTime.UtcNow;

        public MovieControllerTest()
        {
            _connectionString = Guid.NewGuid().ToString();
        }

        [TestMethod]
        public async Task GetAll()
        {
            //Data preparation
            var context = BuildContext(_connectionString);
            await context.Movies.AddAsync(new Entity.Movie()
            {
                Title = "Avengers: Infinity War",
                Synopsis = "Esta película es la finalización de la fase 3 del MCU.",
                Duration = "02:30:00",
                PosterUrl = "img/avengers-infity-war",
                TrailerUrl = "video/avengers-infity-war",
                MovieCategory = new Entity.MovieCategory() { Name = "Acción", Description = "Acción", IsActive = true },
                ReleaseDate = _dateTimeNow,
                IsActive = true,
            });
            await context.Movies.AddAsync(new Entity.Movie()
            {
                Title = "Avengers: Civil War",
                Synopsis = "Esta película representa la separación en bandos de los Advengers.",
                Duration = "02:20:00",
                PosterUrl = "img/avengers-civil-war",
                TrailerUrl = "video/avengers-civil-war",
                MovieCategory = new Entity.MovieCategory() { Name = "Super Héroes", Description = "Super Héroes", IsActive = true },
                ReleaseDate = _dateTimeNow,
                IsActive = true,
            });
            await context.SaveChangesAsync();

            //Testing
            var contextTesting = BuildContext(_connectionString);
            var unitOfWork = new UnitOfWork.Implementation.UnitOfWork(contextTesting);
            var movieService = new MovieService(unitOfWork);
            var movieController = new MovieController(movieService);
            var response = await movieController.GetAll() as ObjectResult;

            //Check
            var movies = response.Value as List<MovieResponseDTO>;
            Assert.AreEqual(2, movies.Count);
        }

        [TestMethod]
        public async Task Get()
        {
            //Data preparation
            var context = BuildContext(_connectionString);

            await context.Movies.AddAsync(new Entity.Movie()
            {
                Title = "Avengers: Infinity War",
                Synopsis = "Esta película es la finalización de la fase 3 del MCU.",
                Duration = "02:30:00",
                PosterUrl = "img/avengers-infity-war",
                TrailerUrl = "video/avengers-infity-war",
                MovieCategory = new Entity.MovieCategory() { Name = "Acción", Description = "Acción", IsActive = true },
                ReleaseDate = _dateTimeNow,
                IsActive = true,
            });
            await context.Movies.AddAsync(new Entity.Movie()
            {
                Title = "Avengers: Civil War",
                Synopsis = "Esta película representa la separación en bandos de los Advengers.",
                Duration = "02:20:00",
                PosterUrl = "img/avengers-civil-war",
                TrailerUrl = "video/avengers-civil-war",
                MovieCategory = new Entity.MovieCategory() { Name = "Super Héroes", Description = "Super Héroes", IsActive = true },
                ReleaseDate = _dateTimeNow,
                IsActive = false,
            });
            await context.SaveChangesAsync();

            //Testing
            var contextTesting = BuildContext(_connectionString);
            var unitOfWork = new UnitOfWork.Implementation.UnitOfWork(contextTesting);
            var movieService = new MovieService(unitOfWork);
            var movieController = new MovieController(movieService);
            var response = await movieController.Get() as ObjectResult;

            //Check
            var movies = response.Value as List<MovieResponseDTO>;
            Assert.AreEqual(1, movies.Count);
        }

        [TestMethod]
        public async Task GetById()
        {
            //Data preparation
            var context = BuildContext(_connectionString);

            await context.Movies.AddAsync(new Entity.Movie()
            {
                Title = "Avengers: Infinity War",
                Synopsis = "Esta película es la finalización de la fase 3 del MCU.",
                Duration = "02:30:00",
                PosterUrl = "img/avengers-infity-war",
                TrailerUrl = "video/avengers-infity-war",
                MovieCategory = new Entity.MovieCategory() { Name = "Acción", Description = "Acción", IsActive = true },
                ReleaseDate = _dateTimeNow,
                IsActive = true,
            });
            await context.Movies.AddAsync(new Entity.Movie()
            {
                Title = "Avengers: Civil War",
                Synopsis = "Esta película representa la separación en bandos de los Advengers.",
                Duration = "02:20:00",
                PosterUrl = "img/avengers-civil-war",
                TrailerUrl = "video/avengers-civil-war",
                MovieCategory = new Entity.MovieCategory() { Name = "Super Héroes", Description = "Super Héroes", IsActive = true },
                ReleaseDate = _dateTimeNow,
                IsActive = false,
            });
            await context.SaveChangesAsync();

            //Testing
            var contextTesting = BuildContext(_connectionString);
            var unitOfWork = new UnitOfWork.Implementation.UnitOfWork(contextTesting);
            var movieService = new MovieService(unitOfWork);
            var movieController = new MovieController(movieService);
            var response = await movieController.Get(1) as ObjectResult;

            //Check
            var result = response.StatusCode;
            Assert.AreEqual(200, result);
        }

        [TestMethod]
        public async Task Post()
        {
            //Data preparation
            var context = BuildContext(_connectionString);
            var newMovie = new Entity.Movie()
            {
                Title = "Avengers: Infinity War",
                Synopsis = "Esta película es la finalización de la fase 3 del MCU.",
                Duration = "02:30:00",
                PosterUrl = "img/avengers-infity-war",
                TrailerUrl = "video/avengers-infity-war",
                MovieCategory = new Entity.MovieCategory() { Name = "Acción", Description = "Acción", IsActive = true },
                ReleaseDate = _dateTimeNow,
                IsActive = true,
            };
            IUnitOfWork unitOfWork = new UnitOfWork.Implementation.UnitOfWork(context);
            IMovieService movieService = new MovieService(unitOfWork);
            var movieController = new MovieController(movieService);
            var response = await movieController.Post(new MovieRequestDTO(newMovie));
            var result = response as ObjectResult;
            Assert.IsNotNull(result.Value);

            //Testing
            var contextTesting = BuildContext(_connectionString);
            var count = await contextTesting.Movies.CountAsync();
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public async Task Put()
        {
            //Data preparation
            var context = BuildContext(_connectionString);
            var movieTest = new Entity.Movie()
            {
                Title = "Avengers: Infinity War",
                Synopsis = "Esta película es la finalización de la fase 3 del MCU.",
                Duration = "02:30:00",
                PosterUrl = "img/avengers-infity-war",
                TrailerUrl = "video/avengers-infity-war",
                MovieCategory = new Entity.MovieCategory() { Name = "Acción", Description = "Acción", IsActive = true },
                ReleaseDate = _dateTimeNow,
                IsActive = true,
            };
            await context.Movies.AddAsync(movieTest);
            await context.SaveChangesAsync();

            //Testing
            var contextTesting = BuildContext(_connectionString);
            IUnitOfWork unitOfWork = new UnitOfWork.Implementation.UnitOfWork(contextTesting);
            IMovieService movieService = new MovieService(unitOfWork);
            var movieController = new MovieController(movieService);
            movieTest.Synopsis = "Esta película representa la separación en bandos de los Advengers";
            movieTest.PosterUrl = "img/avengers-infity-war-2022";
            var response = await movieController.Put(1, new MovieRequestDTO(movieTest)) as ObjectResult;
            Assert.AreEqual(201, response.StatusCode);

            //Testing
            var contextTestingDb = BuildContext(_connectionString);
            var exist = await contextTestingDb.Movies.AnyAsync(movie => movie.Synopsis == movieTest.Synopsis && movie.PosterUrl == movieTest.PosterUrl);
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public async Task Delete()
        {
            //Data preparation
            var context = BuildContext(_connectionString);
            var movieTest = new Entity.Movie()
            {
                Title = "Avengers: Infinity War",
                Synopsis = "Esta película es la finalización de la fase 3 del MCU.",
                Duration = "02:30:00",
                PosterUrl = "img/avengers-infity-war",
                TrailerUrl = "video/avengers-infity-war",
                MovieCategory = new Entity.MovieCategory() { Name = "Acción", Description = "Acción", IsActive = true },
                ReleaseDate = _dateTimeNow,
                IsActive = true,
            };
            await context.Movies.AddAsync(movieTest);
            await context.SaveChangesAsync();

            //Testing
            var contextTesting = BuildContext(_connectionString);
            IUnitOfWork unitOfWork = new UnitOfWork.Implementation.UnitOfWork(contextTesting);
            IMovieService movieService = new MovieService(unitOfWork);
            var movieController = new MovieController(movieService);
            var response = await movieController.Delete(1) as ObjectResult;
            Assert.AreEqual(200, response.StatusCode);

            var contextTestingDb = BuildContext(_connectionString);
            var movieInDb = await contextTestingDb.Movies.SingleOrDefaultAsync(type => type.Id == 1);
            Assert.IsFalse(movieInDb.IsActive);
        }
    }
}
