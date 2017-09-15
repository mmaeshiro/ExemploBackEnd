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
    class AutorMap : EntityTypeConfiguration<Autor>
    {
        public AutorMap()
        {
            ToTable("Autor");

            HasKey(a => a.Id);

            Property(a=>a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Nome).HasMaxLength(80).IsRequired();

            //Relacionamento Muitos para Muitos
            HasMany(l => l.Livros)
                .WithMany(a => a.Autores)
                .Map(la => la.ToTable("LivroAutor"));
        }
    }
}
