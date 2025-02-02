using ServiceStack.DataAnnotations;

namespace IEscolaEntity.Models.Helps
{
    [EnumAsInt]
    public enum Escolaridade
    {
        Medio = 0,
        Baixarel = 1,
        Licenciado = 2,
        Doutorado = 3,
    }
}
