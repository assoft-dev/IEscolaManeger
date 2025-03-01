namespace IEscolaEntity.Models
{

    using ServiceStack.DataAnnotations;

    public class PropinasRecibos
    {
        [AutoIncrement]
        public int PropinasRecibosID { get; set; }
        public decimal ValorPago { get; set; }
        public decimal ValorFalta { get; set; }


        [ForeignKey(typeof(PropinasPagamentos))]
        public int PropinasPagamentoID { get; set; }
        [Reference] public PropinasPagamentos  PropinasPagamentos { get; set; }
    }
}
