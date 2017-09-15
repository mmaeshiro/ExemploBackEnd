using ExemploBackEndsRobustos.Domain.Models;
using ExemploBackEndsRobustos.Infraestructure.Data.Map;
using System.Data.Entity;

namespace ExemploBackEndsRobustos.Infraestructure.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext()
            :base("AppConnectionString")
        {
            //INICIALIZA UM CONTEXTO
            //Database.SetInitializer<AppDataContext>(new AppDataContextInitializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new AutorMap());
            modelBuilder.Configurations.Add(new CategoriaMap());
            modelBuilder.Configurations.Add(new LivroMap());
        }

        ////DROP E CRIA TODO VEZ A BASE
        //public class AppDataContextInitializer : DropCreateDatabaseAlways<AppDataContext>
        //{
        //}
    }
}
