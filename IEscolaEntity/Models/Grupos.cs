using ServiceStack.DataAnnotations;

namespace IEscolaEntity.Models
{
    public class Grupos
    {
        [AutoIncrement]
        public int GruposID { get; set; }

        [Index(Unique = true)]
        public string Descricao { get; set; }

        public string Comentario { get; set; }
        public string Detalhes { get; set; }

        // Permissions
        [ForeignKey(typeof(Permissoes), OnDelete = "CASCADE")]
        public int PermissionID { get; set; }

        [Reference] public Permissoes Permissions { get; set; }
    }
}
