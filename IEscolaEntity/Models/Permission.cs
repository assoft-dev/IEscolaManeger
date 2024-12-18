using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Models
{
    public class Permission
    {

        [AutoIncrement]
        public int PermissionsID { get; set; }

        // Permissions Geral

        public bool List { get; set; }
        public bool Create { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }


        public bool Classes { get; set; }
        public bool Estudantes { get; set; }
        public bool Grupo { get; set; }
        public bool Logs { get; set; }
        public bool Periodos { get; set; }
        public bool Permissions { get; set; }
        public bool Turmas { get; set; }
        public bool Usuarios { get; set; }
        
        [Reference] public List<Grupos> Grupos { get; set; }
    }
}
