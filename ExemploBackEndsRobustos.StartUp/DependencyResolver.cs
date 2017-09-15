using ExemploBackEndsRobustos.Business.Services;
using ExemploBackEndsRobustos.Domain.Contracts.Repositories;
using ExemploBackEndsRobustos.Domain.Contracts.Services;
using ExemploBackEndsRobustos.Infraestructure.Data;
using ExemploBackEndsRobustos.Infraestructure.Repositories;
using Microsoft.Practices.Unity;

namespace ExemploBackEndsRobustos.StartUp
{
    //---------------------------------------
    //ConsoleApplication
    //ADD ESSE PACKAGE Install-Package Unity  
    //---------------------------------------

    public class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<AppDataContext, AppDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());
        }
    }
}
