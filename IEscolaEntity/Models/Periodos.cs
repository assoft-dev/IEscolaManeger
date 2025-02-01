using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace IEscolaEntity.Models
{
    public class Periodos
    {
        [AutoIncrement]
        public int PeriodosID { get; set; }

        [Index(Unique = true), Required]
        public string Descricao { get; set; }

        public TimeSpan Hora1 { get; set; }
        public TimeSpan Hora2 { get; set; }

        // Turmas
        [Reference] public List<Turmas> Turmas { get; set; }
    }
}
