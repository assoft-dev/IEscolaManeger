using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Models.Helps
{

    [EnumAsInt]
    public enum Meses
    {
        JANEIRO = 0,
        FEVEREIRO = 2,
        MARCO = 3,
        ABRIL = 4,
        MAIO = 5,
        JULHO = 6,
        JUNHO = 7,
        AGOSTO = 8,
        SETEMBRO = 9,
        OUTUBRO = 10,
        NOVEMBRO = 11,
        DEZEMBRO = 12,
    }
}
