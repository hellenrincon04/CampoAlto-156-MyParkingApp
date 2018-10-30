using System;
using System.Configuration;
using Application.Main.Definition;
using Application.Main.Implementation;
using Core.GlobalRepository;
using Data.Common.Definition;
using DataAccess.MsSql;
using DataAccess.MySql;
using DataAccess.Repository.Repository;
using Unity;
using Unity.Lifetime;

namespace Crosscutting.DependencyInjectionFactory
{
    public static class ContainerInitializer
    {
        public static void InitializeContainer(this IUnityContainer container)
        {

            var sgbd = ConfigurationManager.AppSettings.Get("SGBD");
            switch (sgbd)
            {
                case "Mysql":
                    container.RegisterType<IUnitOfWork, MyParkingAppContextMySql>(new PerResolveLifetimeManager());
                    break;
                case "MSsql":
                    container.RegisterType<IUnitOfWork, MyParkingAppContextMsSql>(new PerResolveLifetimeManager());
                    break;
                default:
                    container.RegisterType<IUnitOfWork, MyParkingAppContextMySql>(new PerResolveLifetimeManager());
                    break;
            }
            //Repositories
            container.RegisterType<IUserRepository, UserRepository>();

            container.RegisterType<IUserAppService, UserAppService>();
            //AppServices
            //container.RegisterType<IProjectAppService, ProjectAppService>();

        }
    }
}
