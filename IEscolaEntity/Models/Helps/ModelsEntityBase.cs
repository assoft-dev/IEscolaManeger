using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Models.Helps
{
    public class ModelsEntityBase
    {
        [Index(Unique = true)]
        public string Codigo { get; set; }

        //Dados Pessoas
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Ignore]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

    }
}
