using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Models
{
    public class ProfessorAreaFormacao
    {
        [AutoIncrement]
        public int ProfessorAreaFormacaoID { get; set; }
        public string Descricao { get; set; }
    }
}
