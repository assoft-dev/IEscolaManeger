using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Models
{
    public class Inscricoes
    {
        [AutoIncrement]
        public int incricoesID { get; set; }
        public string Codigo { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Ignore] public string FullName { get { return string.Format("", FirstName, LastName); } }

        // Encarregados


        // Identidades

    }
}
