
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Task2_restAPI.Models;
using AutoMapper;
using Task2_restAPI.ViewModels;
using Task2_restAPI.Profiles;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Task2_restAPI
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
            services.AddDbContext<ModelContext>(opt =>
            // for creating SQL database (not  UseInMemoryDatabase)
            opt.UseSqlServer(Configuration.GetConnectionString("SQLConnection")));
            services.AddControllers()
                // solution for JsonException:
                // A possible object cycle was detected which is not supported.
                // This can either be due to a cycle or if the object depth is larger than the maximum allowed depth of 32.
                // source -> https://stackoverflow.com/questions/60197270/jsonexception-a-possible-object-cycle-was-detected-which-is-not-supported-this
                .AddNewtonsoftJson(
          options => {
              options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
          })
            ;

            services.AddCors(); // for cors and front-end

            //configure autoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                // create IEnumerable list
                IEnumerable<Profile> profiles = new Profile[] { new HouseMappingProfile(), new FlatMappingProfile(), new TenantMappingProfile() };
                // add list to mapper configuration
                mc.AddProfiles(profiles); 
            });

            IMapper mapper = mappingConfig.CreateMapper(); // Creates mapper
            services.AddSingleton(mapper); // add mapper to pattenr ? 

            services.AddMvc(); // another pattern ??

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // This helped issue with DB not creating automatically:
            // https://entityframework.net/knowledge-base/42355481/auto-create-database-in-entity-framework-core
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ModelContext>();
                context.Database.Migrate();
            }

            app.UseCors(builder => builder // for cors and front-end
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
