using IEscolaEntity.Models.Helps;
using ServiceStack.DataAnnotations;
using System;

namespace IEscolaEntity.Models
{
    public class EntidadeConvenios
    {
        [AutoIncrement]
        public int EntidadeConveniosID { get; set; }
        public string Descricao { get; set; }

        public DateTime DataSolicitacao { get; set; }
        public EntidadeConvenioEstado EntidadeConvenioEstado { get; set; }


        [ForeignKey(typeof(Entidade))]
        public int EntidadeID { get; set; }
        [Reference] public Entidade  Entidade { get; set; }


        [ForeignKey(typeof(CursoClasseDisciplina))]
        public int CursosClasseDisciplinasID { get; set; }
        [Reference] public CursoClasseDisciplina CursoClasseDisciplina { get; set; }
    }
}
