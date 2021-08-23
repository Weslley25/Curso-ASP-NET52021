using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RecursosCebraspe.Business;
using RecursosCebraspe.Business.implementation;

using RecursosCebraspe.Models.Context;
using RecursosCebraspe.Repository;
using RecursosCebraspe.Repository.implementation;
using Serilog;

namespace RecursosCebraspe
{
    public class Startup

    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }

    

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["ConnectionStrings:SQLConnectionStrings"];
            services.AddDbContext<SQLContext>(options => options.UseSqlServer(connection));
            services.AddControllers();
            if (Environment.IsDevelopment())
                MirgrateDatabase(connection);
            {

            }
            services.AddApiVersioning();
            services.AddScoped<IPessoaBusiness, PessoaBusinessImplementation>();
            services.AddScoped<IPessoaRespository, PessoaRepositoryImplementation>();
            services.AddScoped<ILivroBussines, LivroBusinessImplementation>();
            services.AddScoped<ILivroRespository, LivroRepositoryImplementation>();
            

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
        private void MirgrateDatabase(string connection)
        {
            try
            {
                var envolveConeection = new Microsoft.Data.SqlClient.SqlConnection(connection);
                var evolve = new Evolve.Evolve(envolveConeection, msg => Log.Information(msg))
                {
                    Locations = new List<string> {"db/Migrations","db/Dataset"},
                    IsEraseDisabled = true
                };
                evolve.Migrate();
                
            }
            catch (Exception ex)
            {
                Log.Error("Database migrate failed ", ex);
                throw;
            }
        }
    }
}
