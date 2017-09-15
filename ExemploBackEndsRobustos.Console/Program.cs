using ExemploBackEndsRobustos.Domain.Contracts.Repositories;
using ExemploBackEndsRobustos.Domain.Contracts.Services;
using ExemploBackEndsRobustos.Domain.Models;
using ExemploBackEndsRobustos.Infraestructure.Repositories;
using ExemploBackEndsRobustos.StartUp;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExemploBackEndsRobustos.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            #region antigo
            //var user = new User("Michael", "michael@gmail.com");

            //user.SetPassword("123456", "123456");

            //user.Validate();

            //using (IUserRepository userRep = new UserRepository())
            //{
            //    userRep.Create(user);
            //}

            //using (IUserRepository userRep = new UserRepository())
            //{
            //    var NewUser = userRep.Get("michael@gmail.com");
            //    Console.WriteLine(NewUser.Email);

            //}
            #endregion

            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            var container = new UnityContainer();
            DependencyResolver.Resolve(container);

            var service = container.Resolve<IUserService>();
           
            try
            {
                service.Register("koringa", "koringa@gmail.com", "123456", "123456");
                Console.WriteLine("Usuário vadastrado com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
