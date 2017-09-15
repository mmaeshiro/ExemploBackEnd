using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using ExemploBackEndsRobustos.Infraestructure.Data;
using ExemploBackEndsRobustos.Domain.Contracts.Repositories;
using ExemploBackEndsRobustos.Domain.Contracts.Services;
using ExemploBackEndsRobustos.Infraestructure.Repositories;
using ExemploBackEndsRobustos.Business.Services;

namespace ExemploBackEndsRobustos.IoC
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();              

            //Chamada do componente de D.I
            UnityDependencyContainer.RegisterComponents(container);

            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            #region
            //container.RegisterType<AppDataContext, AppDataContext>();
            //container.RegisterType<IUserRepository, UserRepository>();
            //container.RegisterType<IUserService, UserService>();
            #endregion
        }
    }
}