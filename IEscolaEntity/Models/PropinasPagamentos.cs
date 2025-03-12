using ServiceStack.DataAnnotations;
using System;

namespace IEscolaEntity.Models
{
    public class PropinasPagamentos
    {
        [AutoIncrement]
        public int PropinasPagamentosID { get; set; }
        public string Descricao { get; set; }

        [ForeignKey(typeof(PropinasConfig))]
         public int PropinasConfigID { get; set; }
        [Reference] public PropinasConfig PropinasConfig { get; set; }


        [ForeignKey(typeof(Estudantes))]
        public int EstudanteID { get; set; }
        [Reference]public Estudantes Estudantes { get; set; }

        public DateTime? Data { get; set; }
    }
}
