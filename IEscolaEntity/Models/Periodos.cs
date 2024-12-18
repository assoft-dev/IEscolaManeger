using ServiceStack.DataAnnotations;
using System.Collections.Generic;

namespace IEscolaEntity.Models
{
    public class Periodos
    {

        [AutoIncrement]
        public int PeriodoID { get; set; }


        [Index(Unique = true)]
        public string Referencia { get; set; }

        // Turmas
        [Reference] public List<Turmas> Turmas { get; set; }
    }
}
