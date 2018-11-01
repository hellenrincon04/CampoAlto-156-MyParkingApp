using Application.Main.Definition;
using Application.Main.Implementation;
using Core.Entities.Common;
using Core.GlobalRepository;
using Data.Common.Definition;
using DataAccess.MsSql;
using DataAccess.MySql;
using DataAccess.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Crosscutting.DependencyInjectionFactory
{
    public static class NetCoreDependency
    {
        public static void InitializeContainer(this IServiceCollection services, IConfiguration configuration)
        {

            string connectionString = configuration.GetConnectionString("MyParkingAppMySql");


            var settingsSection = configuration.GetSection("AppSettings");
            var settings = settingsSection.Get<AppSettings>();

            var sgBd = settings.SgBd;

            string assemblyNamespace = "";
            switch (sgBd)
            {
                case "MySql":
                    assemblyNamespace = typeof(MyParkingAppContextMySql).Namespace;

                    services.AddDbContext<MyParkingAppContextMySql>(options =>
                        options.UseMySQL(connectionString, optionsBuilder =>
                            optionsBuilder.MigrationsAssembly(assemblyNamespace)
                        )
                    );

                    services.AddScoped<IUnitOfWork, MyParkingAppContextMySql>();
                    break;
                case "MsSql":
                    assemblyNamespace = typeof(MyParkingAppContextMySql).Namespace;
                    services.AddDbContext<MyParkingAppContextMsSql>(options =>
                        options.UseSqlServer(connectionString, optionsBuilder =>
                            optionsBuilder.MigrationsAssembly(assemblyNamespace)
                        )
                    );
                    services.AddScoped<IUnitOfWork, MyParkingAppContextMsSql>();
                    break;
                default:
                    services.AddDbContext<MyParkingAppContextMySql>();
                    break;
            }

            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();

            //services
            services.AddScoped<IUserAppService, UserAppService>();
        }
    }
}
