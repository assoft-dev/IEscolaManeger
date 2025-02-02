using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Models.Helps
{
    [EnumAsInt]
    public enum Estado
    {
        Activado = 0,
        Desativado = 1,
        Desativado_Temp = 2,
        Excluido = 3,
    }
}
