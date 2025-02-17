﻿using ServiceStack.DataAnnotations;

namespace IEscolaEntity.Models.Biblioteca
{
    public class PedidosOrdems
    {
        [AutoIncrement]
        public int PedidosOrdemID { get; set; }

        public int Quantidade { get; set; }
        public decimal Precounitario { get; set; }
        public decimal Total { get; set; }
        public string DocNumero { get; set; }


        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public string FirstName { get; set; }


        [ForeignKey(typeof(Pedidos))]
        public int PedidoID { get; set; }
        [Reference] public Pedidos Pedidos { get; set; }

       
        [ForeignKey(typeof(Livros))]
        public int LivrosID { get; set; }
        [Reference] public Livros Livros { get; set; }
    }
}
