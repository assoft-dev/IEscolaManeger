using ServiceStack.DataAnnotations;

namespace IEscolaEntity.Models.Helps
{
    [EnumAsInt]
    public enum UsuariosRetorno
    {
        Valido = 0,
        Invalido = 1,
        Desativado = 2,
        Initial = 3,
        PrimeiraVez = 4,
        Permissoes_Invalida = 5,
        Agrupamento_Invalida = 6,
        Desativado_Temp = 7,
        Excluido = 8,
    }
}
