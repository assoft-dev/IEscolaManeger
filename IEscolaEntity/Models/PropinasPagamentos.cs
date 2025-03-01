using ServiceStack.DataAnnotations;

namespace IEscolaEntity.Models
{
    public class PropinasPagamentos
    {
        [AutoIncrement]
        public int PropinasPagamentosID { get; set; }
        public string Descricao { get; set; }

        [ForeignKey(typeof(PropinasConfig))]
        [Reference] public int PropinasConfigID { get; set; }


        [ForeignKey(typeof(Estudantes))]
        [Reference] public int EstudanteID { get; set; }
    }
}
