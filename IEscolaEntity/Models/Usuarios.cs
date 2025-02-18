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
        [Required] public string FirstName { get; set; }
        public string LastName { get; set; }

        [Ignore] public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }
        
        public string Senha { get; set; }

        [Index(Unique = true), Required]
        public string Email { get; set; }
        public DateTime Data { get; set; }

        [Default(0)]
        public Estado Estado { get; set; }

        public string ImagemURL { get; set; }

        // Chaves estrangeiras
        [ForeignKey(typeof(Grupos), OnDelete = "CASCADE")]
        [Required] public int GruposID { get; set; }
        [Reference] public Grupos Grupos { get; set; }

        //Chave de Ligação
        [Reference]  public List<UsuariosLogs> logs { get; set; }
    }
}
