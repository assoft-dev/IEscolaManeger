using ServiceStack.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IEscolaEntity.Models
{
    public class Salas
    {
        [AutoIncrement]
        public int SalasID { get; set; }

        [System.ComponentModel.DataAnnotations.Required, Display(Name = "Nome da Sala")]
        public string Descricao { get; set; }

        [Reference] public List<Turmas> Turmas { get; set; }
    }
}
