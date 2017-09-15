using System.Collections.Generic;

namespace ExemploBackEndsRobustos.Domain.Models
{
    public class Autor
    {
        public Autor()
        {
            this.Livros = new List<Livro>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Livro> Livros { get; set; }
    }
}
