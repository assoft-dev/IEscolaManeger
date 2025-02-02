using ServiceStack.DataAnnotations;

namespace IEscolaEntity.Models.Helps
{
    [EnumAsInt]
    public enum Sexo
    {
        Masculuno  = 0,
        Femenino = 1,
        Indefinido = 2,
    }
}
