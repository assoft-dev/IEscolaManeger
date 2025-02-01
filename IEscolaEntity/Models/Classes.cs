using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Models
{
    public class Classes
    {
        [AutoIncrement]
        public int ClasseID { get; set; }

        [Required]
        public string Descricao { get; set; }


        //   Turmas
        [Reference] public List<Turmas> Turmas { get; set; }
    }
}
