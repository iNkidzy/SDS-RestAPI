using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SDS.Core.AplicationService;
using SDS.Core.AplicationService.Services;
using SDS.Core.DomainService;
using SDS.Core.Entity;
using SDS.Infrastructure.data;
using SDS.Infrastructure.data.Repositories;

namespace WebAPI
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
            //var serviceCollection = new ServiceCollection();///////////new imp
            services.AddScoped<IAvatarRepository, AvatarRepo>();
            services.AddScoped<IAvatarService, AvatarService>();
            services.AddScoped<IAvatarTypeRepository, AvatarTypeRepo>();
            services.AddScoped<IAvatarTypeService, AvatarTypeService>();
            services.AddScoped<IOwnerRepository, OwnerRepo>();
            services.AddScoped<IOwnerService, OwnerService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
               
                app.UseDeveloperExceptionPage();

            }

            //This is new 

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IAvatarRepository>();
                var atrepo = scope.ServiceProvider.GetRequiredService<IAvatarTypeRepository>();
                var owrepo = scope.ServiceProvider.GetRequiredService<IOwnerRepository>();
                //repo.Create(new Avatar { Name = "Bunsy", Type ="Bunny", Color ="Blue"});
                //repo.Create(new Avatar { Name = "Chili", Type = "Magician", Color = "Pink" });

                IAvatarRepository avatarRepository = new AvatarRepo();
                IAvatarTypeRepository avatarTypeRepository = new AvatarTypeRepo();
                IOwnerRepository ownerRepository = new OwnerRepo();

                //new DBinitializer  = new DBinitializer();
                //d.InitData();

                DBinitializer.InitData();
                IAvatarService avatarService = new AvatarService(avatarRepository);
                IAvatarTypeService avatarTypeService = new AvatarTypeService(avatarTypeRepository);
                IOwnerService ownerService = new OwnerService(ownerRepository);





                //YOU DID GITHUB WIHT TERMINAL !!! 


               // app.UseWelcomePage();

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
}


