using IEscolaEntity.Models.Helps;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace IEscolaEntity.Models.Biblioteca
{
    public class Pedidos
    {
        [AutoIncrement]
        public int PedidosID { get; set; }

        public string Descricao { get; set; }
        public string DocNumero { get; set; }
        public DateTime DataReserva { get; set; }
        public DateTime DataEntrega { get; set; }

        public bool IsValid { get; set; }
        public decimal TotalGeral { get; set; }

        public PedidosEstado PedidosEstado { get; set; }
        public PedidosDocuments PedidosDocuments { get; set; }

        [ForeignKey(typeof(Estudantes))]
        public int EstudantesID { get; set; }
        [Reference] public Estudantes Estudantes { get; set; }

        [Reference] public List<PedidosOrdems> PedidosOrdems { get; set; }
    }
}
