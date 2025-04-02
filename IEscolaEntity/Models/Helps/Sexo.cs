using ServiceStack.DataAnnotations;

namespace IEscolaEntity.Models.Helps
{
    [EnumAsInt]
    public enum Sexo
    {
        MASCULINO  = 0,
        FEMENINO = 1,
        INDEFINIDO = 2,
    }
}
