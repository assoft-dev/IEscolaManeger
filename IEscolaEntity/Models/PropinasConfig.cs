using IEscolaEntity.Models.Helps;
using ServiceStack.DataAnnotations;
using System.Collections.Generic;

namespace IEscolaEntity.Models
{
    public class PropinasConfig
    {
        [AutoIncrement]
        public int PropinasConfigID { get; set; }

        public Meses Meses { get; set; }
        public int Inicia { get; set; }
        public int Termina { get; set; }
        public int Excedente { get; set; }
        public decimal Valor { get; set; }
        public Anos Ano { get; set; }

        [Reference] public List<PropinasPagamentos> PropinasPagamentos { get; set; }
    }
}
