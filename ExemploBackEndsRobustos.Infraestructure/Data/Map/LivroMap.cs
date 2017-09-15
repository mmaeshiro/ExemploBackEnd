using ExemploBackEndsRobustos.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploBackEndsRobustos.Infraestructure.Data.Map
{
    class LivroMap : EntityTypeConfiguration<Livro>
    {
        public LivroMap()
        {
            ToTable("Livro");

            HasKey(l => l.Id);

            Property(l => l.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(l => l.Titulo).HasMaxLength(80).IsRequired();

            //Relacionamento Muitos para Muitos
            //Não precisa configurar tudo denovo
            //por que ja foi feito no AutorMap
            HasMany(a => a.Autores);

            //Relacionamento 1 para N
            HasRequired(c => c.Categoria);
        }
    }
}
