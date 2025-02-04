using ServiceStack.DataAnnotations;

namespace IEscolaEntity.Models.Helps
{
    [EnumAsInt]
    public enum PedidosEstado
    {
        AQUISICAO = 0,
        REQUISITADO = 1,
        DEVOLVIDO = 2,
        NORMAL = 3,
    }
}
