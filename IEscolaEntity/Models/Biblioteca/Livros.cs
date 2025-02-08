using IEscolaEntity.Models.Helps;
using ServiceStack.DataAnnotations;
using System.Collections.Generic;

namespace IEscolaEntity.Models.Biblioteca
{
    public class Livros
    {
        [AutoIncrement]
        public int LivrosID { get; set; }

        [Unique]
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }

        public string ISBN { get; set; }
        public string Edicao { get; set; }

        public string Descricao { get; set; }
        public string Comentarios { get; set; }

        public string Lancamento { get; set; }
        public string LocalLancamento { get; set; }

        public string CodBar { get; set; }
        public bool IsValidade { get; set; }

        public string Pratileira { get; set; }
        public string PratileiraPosicao { get; set; }

        public int Rating { get; set; }
        public bool Favoritar { get; set; }

        public int Ano { get; set; }

        public decimal? Quantidade { get; set; }
        public decimal? PrecoUnitario { get; set; }

        [Ignore] public decimal TotalGeral { get { return Quantidade.Value * PrecoUnitario.Value; } }


        [ForeignKey(typeof(Editores))]
        public int EditorasID { get; set; }
        [Reference] public Editores Editores { get; set; }


        [ForeignKey(typeof(Autores))]
        public int AutoresID { get; set; }
        [Reference] public Autores Autores { get; set; }


        [ForeignKey(typeof(Categorias))]
        public int CategoriasID { get; set; }
        [Reference] public Categorias Categorias { get; set; }

        public string ImagemFrente { get; set; }
        public string ImagemVerso { get; set; }

        [Default(0)]
        public Disponibilidade Disponibilidade { get; set; }


        [Reference] public List<PedidosOrdems> PedidosOrdems { get; set; }
    }
}
