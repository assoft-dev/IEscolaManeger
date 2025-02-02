using ServiceStack.DataAnnotations;

namespace IEscolaEntity.Models.Helps
{
    [EnumAsInt]
    public enum PedidosEstado
    {
        REQUISITADO = 0,
        DEVOLVIDO = 1,
        NORMAL = 2,
    }
}
