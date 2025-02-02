using ServiceStack.DataAnnotations;

namespace IEscolaEntity.Models.Helps
{
    [EnumAsInt]
    public enum UsuariosRetorno
    {
        Valido,
        Invalido,
        Desativado,
        Initial,
        PrimeiraVez,
        Permissoes_Invalida,
        Agrupamento_Invalida,
        Desativado_Temp,
    }
}
