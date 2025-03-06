using IEscolaEntity.Models.Helps;
using ServiceStack.DataAnnotations;
using ServiceStack.Script;
using System.Collections.Generic;

namespace IEscolaEntity.Models
{
    public class CursoClasseDisciplina
    {
        [AutoIncrement]
        public int CursoClasseDisciplinaID { get; set; }

        [ForeignKey(typeof(Cursos))]
        public int CursosID { get; set; }
        [Reference] public Cursos  Cursos { get; set; }


        [ForeignKey(typeof(Classes))]
        public int ClassesID { get; set; }
        [Reference] public Classes Classes { get; set; }


        [ForeignKey(typeof(Disciplinas))]
        public int DisciplinasID { get; set; }
        [Reference] public Disciplinas Disciplinas { get; set; }

        public string Comentarios { get; set; }

        public DisciplinasComponentesType DisciplinasComponentesType { get; set; }

        [Reference] public List<DisciplinasProgramas> disciplinasProgramas { get; set; }
    }
}
