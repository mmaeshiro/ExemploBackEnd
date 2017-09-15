using ExemploBackEndsRobustos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploBackEndsRobustos.Infraestructure.Data.Map
{
    class CategoriaMap : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMap()
        {
            ToTable("Categoria");

            Property(c => c.Titulo).HasMaxLength(30).IsRequired();

            //Relacionamento 1 para N
            HasMany(l => l.Livros);
        }
    }
}
