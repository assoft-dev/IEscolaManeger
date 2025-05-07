using ServiceStack.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = ServiceStack.DataAnnotations.RequiredAttribute;

namespace IEscolaEntity.Models
{
    public class Salas
    {
        [AutoIncrement]
        public int SalasID { get; set; }

        [Required, Display(Name = "Nome da Sala"), Unique]
        public string Descricao { get; set; }

        [Reference] public List<Turmas> Turmas { get; set; }
    }
}
