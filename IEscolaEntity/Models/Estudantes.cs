using IEscolaEntity.Models.Biblioteca;
using IEscolaEntity.Models.Helps;
using ServiceStack.DataAnnotations;
using System.Collections.Generic;

namespace IEscolaEntity.Models
{
    public class Estudantes
    {
        // Dados Internos
        [AutoIncrement]
        public int EstudantesID { get; set; }

        // Dados dos Encarregados
        public string Entidade { get; set; }
        public EstadoEstudantes EstadoEstudantes { get; set; }

        [ForeignKey(typeof(Turmas))]
        public int TurmaID { get; set; }
        [Reference] public Turmas Turmas { get; set; }

        // Relacionamentos
        [ForeignKey(typeof(EstudantesInscricoes)), Unique]
        public int InscricoesID { get; set; }
        [Reference] public EstudantesInscricoes Inscricoes { get; set; }

        [Reference] public List<Pedidos> Pedidos { get; set; }

        [Reference] public List<PropinasPagamentos> PropinasPagamentos { get; set; }
    }
}
