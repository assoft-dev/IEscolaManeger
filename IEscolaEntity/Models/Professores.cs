using IEscolaEntity.Models.Helps;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Models
{
    public class Professores
    {
        [AutoIncrement]
        public int ProfessoresID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DataNacimento { get; set; }
        public Escolaridade Escolaridade { get; set; }
    }
}
