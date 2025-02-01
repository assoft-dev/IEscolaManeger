using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Models.Biblioteca
{
    public class Pais
    {
        [AutoIncrement]
        public int PaisID { get; set; }

        [Unique]
        public string Descricao { get; set; }

        [Reference] public List<Editores> Editores { get; set; }   
    }
}
