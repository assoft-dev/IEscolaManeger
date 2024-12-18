using ServiceStack.DataAnnotations;
using System;

namespace IEscolaEntity.Models
{
    public class Logs
    {

        [AutoIncrement]
        public int LogsID { get; set; }
        public string Referencias { get; set; }

        public DateTime Data { get; set; }
        public string  Operacao { get; set; }


        // Relacionamentos

        [ForeignKey(typeof(Usuarios), OnDelete = "CASCADE")]
        public int UsuariosID { get; set; }
        [Reference] public Usuarios Usuarios { get; set; }
    }
}
