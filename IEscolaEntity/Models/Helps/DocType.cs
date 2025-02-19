using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Models.Helps
{
    [EnumAsInt]
    public enum DocType
    {
        SemDocumento,
        Bilhete_de_Identidade,
        Cedula_Pessoal,
        Outros_Documentos
    }
}
