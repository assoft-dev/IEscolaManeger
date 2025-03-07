using IEscolaEntity.Models.Helps;
using ServiceStack.DataAnnotations;
using System.Collections.Generic;

namespace IEscolaEntity.Models
{
    public class CursoClasseDisciplina
    {
        [AutoIncrement]
        public int CursoClasseDisciplinaID { get; set; }

        [References(typeof(Cursos))]
        public int CursosID { get; set; }
        [Reference] public Cursos  Cursos { get; set; }


        [References(typeof(Classes))]
        public int ClassesID { get; set; }
        [Reference] public Classes Classes { get; set; }


        [ForeignKey(typeof(Disciplinas))]
        public int DisciplinasID { get; set; }
        [Reference] public Disciplinas Disciplinas { get; set; }

        public DisciplinasComponentesType DisciplinasComponentesType { get; set; }

        [Ignore]
        public string Descricao
        {
            get
            {
                {
                    if (Cursos != null && Classes != null && Disciplinas != null)
                        return string.Format("{0} -> {1} => {2}", 
                            Cursos.Descricao, Classes.Descricao, Disciplinas.Descricao);
                    else
                        return string.Empty;
                };
            }
        }

        [Reference] public List<DisciplinasProgramas> disciplinasProgramas { get; set; }
    }
}
