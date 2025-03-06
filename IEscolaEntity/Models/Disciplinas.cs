using ServiceStack.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IEscolaEntity.Models
{
    public class Disciplinas
    {
        [ServiceStack.DataAnnotations.AutoIncrement, Display(Name = "Código")]
        public int DisciplinasID { get; set; }

        [System.ComponentModel.DataAnnotations.Required, Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public string Sigla { get; set; }

        [Reference] public List<CursoClasseDisciplina> CursoClasseDisciplina { get; set; }
    }
}
