
using System.ComponentModel;

namespace IEscolaEntity.Models.Helps
{
    [ServiceStack.DataAnnotations.EnumAsInt]
    public enum ProvinciasLocal
    {
        BENGUELA = 0,
        LUANDA = 1,
        MALANJE = 2,
        UIGE = 3,
        CABINDA = 4,
        CUANDO = 5,
        CUBANGO = 6,
        BENGO = 7,
        ICOLIBENGO = 8,
        NAMIBE = 9,
        HUAMBO = 10,
        ZAIRE = 11,

        [Description("LUNDA NORTE")]
        LUNDA_NORTE = 12,

        [Description("LUNDA SUL")]
        LUNDA_SUL = 13,

        [Description("HUÍLA")]
        CUANZA_NORTE = 14,

        [Description("CUANZA SUL")]
        CUANZA_SUL = 15,

        [Description("HUÍLA")]
        HUILA = 16,

        [Description("MOXICO OESTE")]
        MOXICO_NORTE = 17,

        [Description("MOXICO LESTE")]
        MOXICO_LESTE = 18,

        [Description("BIÉ")]
        BIE = 19,
    }
}
