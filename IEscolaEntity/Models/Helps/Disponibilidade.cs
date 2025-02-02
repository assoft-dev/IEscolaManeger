using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Models.Helps
{
    [EnumAsInt]
    public enum Disponibilidade
    {
        ONLINE,
        FISICO,
        ONLINE_FISICO,
        NORMAL
    }
}
