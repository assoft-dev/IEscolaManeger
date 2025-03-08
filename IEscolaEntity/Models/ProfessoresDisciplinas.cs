using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace IEscolaEntity.Models
{
    public class ProfessoresDisciplinas
    {
        [AutoIncrement, Display(Name = "Código")]
        public int ProfessoresDisciplinasID { get; set; }


        [References(typeof(Professores)), Display(Name = "Nome")]
        public int ProfessoresID { get; set; }
        [Reference] public Professores Professores { get; set; }


        [References(typeof(CursoClasseDisciplina)), Display(Name = "Curso=>Classe->Disciplina")]
        public int CursoClasseDisciplinaID { get; set; }
        [Reference] public CursoClasseDisciplina CursoClasseDisciplina { get; set; }
    }
}
