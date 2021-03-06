﻿using System.Collections.Generic;

namespace ExemploBackEndsRobustos.Domain.Models
{
    public class Categoria
    {
        public Categoria()
        {
            this.Livros = new List<Livro>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}
