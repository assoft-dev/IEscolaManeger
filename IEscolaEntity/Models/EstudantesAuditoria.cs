using IEscolaEntity.Models.Helps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Models
{
    public class EstudantesAuditoria
    {
        public int EstudanteID { get; set; }
        public EstudanteOperacao Operacao { get; set; }

        public DateTime Data { get; set; }
    }
}
