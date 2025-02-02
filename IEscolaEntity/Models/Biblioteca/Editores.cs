using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Models.Biblioteca
{
    public class Editores
    {
        [AutoIncrement]
        public int EditoresID { get; set; }

        [Unique]
        public string Descricao { get; set; }

        public string Comentarios { get; set; }

        [ForeignKey(typeof(Pais))]
        public int PaisID { get; set; }

        [Reference] public Pais Pais { get; set; }

        [Reference] public List<Livros> Livros { get; set; }
    }
}
