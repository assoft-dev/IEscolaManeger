using ServiceStack.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IEscolaEntity.Models
{
    public class ProfessoresCategorias
    {
        [AutoIncrement]
        public int ProfessoresCategoriasID { get; set; }

        [Display(Name = "Referência"), Unique]
        public string Descricao { get; set; }

        [Display(Name = "Professor/Nome")]
        [Reference] public List<Professores> Professores { get; set; }
    }
}
