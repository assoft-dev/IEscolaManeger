using IEscolaEntity.Models.Helps;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace IEscolaEntity.Models
{

    public class Usuarios
    {
        [AutoIncrement]
        public int UsuariosID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Ignore] public string FullName { 
            get { return string.Format("{0} {1}", FirstName, LastName); } 
        }


        [Index(Unique = true)]
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Pin { get; set; }

        public Estado Estado { get; set; }
        public DateTime Data { get; set; }


        // Chaves estrangeiras

        [ForeignKey(typeof(Grupos), OnDelete = "CASCADE")]
        public int GruposID { get; set; }
        [Reference] public Grupos Grupos { get; set; }


        //Chave de Ligação
        [Reference]  public List<Logs> logs { get; set; }

    }
}
