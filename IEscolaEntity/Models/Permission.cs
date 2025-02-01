using ServiceStack.DataAnnotations;
using System.Collections.Generic;

namespace IEscolaEntity.Models
{
    public class Permissoes
    {
        [AutoIncrement]
        public int PermissoeID { get; set; }

        // Permissions Geral

        public bool List { get; set; }
        public bool Create { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }


        public bool Classes { get; set; }
        public bool Estudantes { get; set; }
        public bool Grupos { get; set; }
        public bool Logs { get; set; }
        public bool Periodos { get; set; }
        public bool Permissions { get; set; }
        public bool Turmas { get; set; }
        public bool Usuarios { get; set; }

        // Localização
        public bool Provincias { get; set; }
        public bool Municipios { get; set; }
        public bool ProvinciasMunicipios { get; set; }

        [Reference] public List<Grupos> grupos { get; set; }
    }
}
