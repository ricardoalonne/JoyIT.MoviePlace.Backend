using JoyIT.MoviePlace.Context;
using JoyIT.MoviePlace.Service.Implementation;
using JoyIT.MoviePlace.Service.Interface;
using JoyIT.MoviePlace.UnitOfWork.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace JoyIT.MoviePlace.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo { Title = "JoyIT.MoviePlace.WebApi", Version = "v1.0" });
            });


            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                    )
                );
            services.AddTransient<IUnitOfWork, UnitOfWork.Implementation.UnitOfWork>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IMovieCategoryService, MovieCategoryService>();

            services.AddCors(options =>
            {
                var webAppReactUrl = Configuration.GetValue<string>("ExternalUrl:WebAppReactUrl");
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(webAppReactUrl).AllowAnyMethod().AllowAnyHeader();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "JoyIT MoviePlace Api v1.0"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
