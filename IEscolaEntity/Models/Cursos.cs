using ServiceStack.DataAnnotations;
using System.Collections.Generic;

namespace IEscolaEntity.Models
{
    public class Cursos
    {
        [AutoIncrement]
        public int CursosID { get; set; }

        [Required]
        public string Descricao { get; set; }

        public string Sigla { get; set; }

        //   Turmas
        [Reference] public List<Turmas> Turmas { get; set; }
    }
}
