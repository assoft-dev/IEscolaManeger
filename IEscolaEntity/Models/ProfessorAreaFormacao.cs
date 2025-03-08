using ServiceStack.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IEscolaEntity.Models
{
    public class ProfessorAreaFormacao
    {
        [AutoIncrement, Display(Name = "Código")]
        public int ProfessorAreaFormacaoID { get; set; }


        [Display(Name = "Referência")]
        public string Descricao { get; set; }


        [Reference] public List<Professores> Professores { get; set; }
    }
}
