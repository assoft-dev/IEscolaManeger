using ServiceStack.DataAnnotations;
using System;

namespace IEscolaEntity.Models
{
    public class DisciplinasProgramas
    {
        [AutoIncrement]
        public int DisciplinasProgramasID { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Comentario { get; set; }
        public DateTime Data { get; set; }
        public string Lei { get; set; }

        [References(typeof(CursoClasseDisciplina))]
        public int CursoClasseDisciplinaID { get; set; }
        [Reference] public CursoClasseDisciplina CursoClasseDisciplina { get; set; }

    }
}
