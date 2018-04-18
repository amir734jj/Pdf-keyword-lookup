using System;
using System.Data.Common;
using AutoMapper;
using DataAccessLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using Swashbuckle.AspNetCore.Swagger;

namespace Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            services.AddAutoMapper();
            
            //StructureMap Container
            var container = new Container();

            // Add swagger json generation
            services.AddSwaggerGen(c =>
            {
                //Metadata and configuration for the swagger client
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Title",
                    Description = "Description",
                    TermsOfService = "TermsOfService",
                    Contact = new Contact
                    {
                        Name = "Name",
                        Email = "Email",
                        Url = "Url"
                    },
                    Version = "v1"
                });

               // var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "APIDocumentation.xml");
                //c.IncludeXmlComments(filePath);
                
                c.DescribeAllEnumsAsStrings();
            });

            
            container.Configure(config =>
            {
                config.Scan(_ =>
                {
                    // Registering to allow for Interfaces to be dynamically mapped
                    _.AssemblyContainingType(typeof(Startup));
                    _.Assembly("DomainLogic");
                    _.Assembly("DataAccessLayer");
                    _.Assembly("Models");
                    _.WithDefaultConventions();
                });
                
                config.Populate(services);

                // Sqlite connection string
                var connectionString = new SqliteConnectionStringBuilder()
                {
                    DataSource = "db.sqlite",
                    Mode = SqliteOpenMode.ReadWriteCreate,
                    Cache = SqliteCacheMode.Private
                };

                var connection = new DbContextOptionsBuilder();
                connection.UseSqlite(connectionString.ToString());
                
                var entityDbContext = new EntityDbContext(connection, connectionString);   
                config.For<EntityDbContext>().Use(entityDbContext);
            });
                        
            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseCors(x => { x.AllowAnyOrigin(); });
            
            app.UseMvc(routes => { routes.MapRoute("default", "{controller=Home}/{action=Index}"); });
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}