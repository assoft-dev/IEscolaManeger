using ServiceStack;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Models.Biblioteca
{
    public class Autores
    {
        [AutoIncrement]
        public int AutoresID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Ignore]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
        public DateTime DataNascimento { get; set; }


        [Reference] public List<Livros> Livros { get; set; }
    }
}
