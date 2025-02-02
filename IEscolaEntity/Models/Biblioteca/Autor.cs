using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace IEscolaEntity.Models.Biblioteca
{
    public class Autores
    {
        [AutoIncrement]
        public int AutoresID { get; set; }

        [Unique, Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Ignore] public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
        
        public DateTime DataNascimento { get; set; }
        public string ImagemURL { get; set; }


        [ForeignKey(typeof(Pais))]
        public int PaisID { get; set; }
        [Reference] public Pais Pais { get; set; }

        [Reference] public List<Livros> Livros { get; set; }
    }
}
