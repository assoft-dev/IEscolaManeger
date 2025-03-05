using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Models.Helps
{
    [EnumAsInt]
    public enum AbilitacoesLiterarias
    {
        PHD = 0,
        LICENCIADO = 1,
        MESTRE = 2,
        BAIXAREL = 3,
        TECNICO_MÉDIO = 4,
    }
}
