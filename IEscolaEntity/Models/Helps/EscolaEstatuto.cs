using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Models.Helps
{
    [EnumAsInt]
    public enum EscolaEstatuto
    {
        PUBLICO=0,
        PRIVADO=1,
    }
}
