using ServiceStack.DataAnnotations;
using System;

namespace IEscolaEntity.Models
{
    public class UsuariosLogs
    {
        [AutoIncrement]
        public int UsuariosLogsID { get; set; }
        [Required] public string Descricao { get; set; }
        public string Local { get; set; }

        public DateTime Data { get; set; }

        // Chave Estrangeira
        [ForeignKey(typeof(Usuarios), OnDelete = "CASCADE")] 
        public int UsuariosID { get; set; }
        [Reference] public Usuarios  Usuarios { get; set; }
    }
}
