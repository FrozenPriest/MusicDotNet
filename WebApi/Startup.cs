using System;
using BLL.Contracts;
using BLL.Implementation;
using DataAccess.Context;
using DataAccess.Contracts;
using DataAccess.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace WebApi
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
            services.AddAutoMapper(typeof(Startup));

            //BLL
            //song
            services.Add(new ServiceDescriptor(typeof(ISongCreateService), typeof(SongCreateService),
                ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ISongGetService), typeof(SongGetService),
                ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ISongUpdateService), typeof(SongUpdateService),
                ServiceLifetime.Scoped));
            //album
            services.Add(new ServiceDescriptor(typeof(IAlbumCreateService), typeof(AlbumCreateService),
                ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IAlbumGetService), typeof(AlbumGetService),
                ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IAlbumUpdateService), typeof(AlbumUpdateService),
                ServiceLifetime.Scoped));
            
            
            //artist
            services.Add(new ServiceDescriptor(typeof(IArtistGetService), typeof(ArtistGetService),
                ServiceLifetime.Scoped));
            //todo more

            //DataAccess
            services.Add(new ServiceDescriptor(typeof(ISongDataAccess), typeof(SongDataAccess),
                ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IAlbumDataAccess), typeof(AlbumDataAccess),
                ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IArtistDataAccess), typeof(ArtistDataAccess),
                ServiceLifetime.Transient));

            // DB Contexts
            services.AddDbContext<SongDirectoryContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("SongDirectory"),
                    b => b.MigrationsAssembly("WebApi")));

            //swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Music API",
                    Description = "Music Api with .Net Core 3",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Alexey Borisenko",
                        Email = string.Empty,
                        Url = new Uri("https://vk.com/frozenpriest"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
        }
    }
}