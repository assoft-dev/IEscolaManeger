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
        ONLINE = 0,
        FISICO = 1,
        ONLINE_FISICO = 2,
        NORMAL = 3,
    }
}
