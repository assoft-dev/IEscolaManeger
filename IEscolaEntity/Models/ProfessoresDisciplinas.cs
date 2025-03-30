using ServiceStack.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IEscolaEntity.Models
{
    public class ProfessoresDisciplinas
    {
        [AutoIncrement, Display(Name = "Código")]
        public int ProfessoresDisciplinasID { get; set; }

        [ForeignKey(typeof(Professores)), Display(Name = "Nome")]
        public int ProfessoresID { get; set; }
        [Reference] public Professores Professores { get; set; }

        [ForeignKey(typeof(CursoClasseDisciplina)), Display(Name = "Curso=>Classe->Disciplina")]
        public int CursoClasseDisciplinaID { get; set; }
        [Reference] public CursoClasseDisciplina CursoClasseDisciplina { get; set; }


        [Reference] public List<Pautas_Mini> pautas_Minis { get; set; }
    }
}
