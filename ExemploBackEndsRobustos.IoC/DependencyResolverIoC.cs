using ExemploBackEndsRobustos.Business.Services;
using ExemploBackEndsRobustos.Domain.Contracts.Repositories;
using ExemploBackEndsRobustos.Domain.Contracts.Services;
using ExemploBackEndsRobustos.Infraestructure.Data;
using ExemploBackEndsRobustos.Infraestructure.Repositories;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ExemploBackEndsRobustos.IoC
{
    /* MVC
    /*ADD PACKAGE Install-Package Unity.Mvc4*/

    public class UnityDependencyContainer
    {
        public static void RegisterComponents(UnityContainer container)
        {
            container.RegisterType<AppDataContext, AppDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());            
        }
    }
}
