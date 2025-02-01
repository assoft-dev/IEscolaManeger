using ServiceStack.DataAnnotations;
using System.Collections.Generic;

namespace IEscolaEntity.Models
{
    public class Salas
    {
        [AutoIncrement]
        public int SalasID { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Reference] public List<Turmas> Turmas { get; set; }
    }
}
