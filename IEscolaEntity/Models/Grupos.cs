using ServiceStack.DataAnnotations;

namespace IEscolaEntity.Models
{
    public class Grupos
    {

        [AutoIncrement]
        public int GruposID { get; set; }

        [Index(Unique = true)]
        public string Referencias { get; set; }


        // Permissions
        [ForeignKey(typeof(Permission), OnDelete = "CASCADE")]
        public int PermissionID { get; set; }

        [Reference] public Permission Permissions { get; set; }
    }
}
