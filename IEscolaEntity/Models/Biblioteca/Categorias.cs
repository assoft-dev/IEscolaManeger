using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Models.Biblioteca
{
    public class Categorias
    {
        [AutoIncrement]
        public int CategoriasID { get; set; }

        [Unique]
        public string Descricao { get; set; }
        public string Comentarios { get; set; }


        [Reference] public List<Livros> Livros { get; set; }

    }
}
