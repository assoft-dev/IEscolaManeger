using IEscolaEntity.Models.Helps;
using ServiceStack.DataAnnotations;
using System;

namespace IEscolaEntity.Models
{
    public class Notificacoes
    {
        [AutoIncrement]
        public int NotificacoesID { get; set; }

        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public NotificacoesCatater Catater { get; set; }

        public int Duracao { get; set; }
        public bool Visualizado { get; set; }

        [ForeignKey(typeof(Professores))]
        public int ProfessoresID { get; set; }
        [Reference] public Professores Professores  { get; set; }
    }
}
