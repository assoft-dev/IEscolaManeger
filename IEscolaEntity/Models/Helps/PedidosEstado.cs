using ServiceStack.DataAnnotations;

namespace IEscolaEntity.Models.Helps
{
    [EnumAsInt]
    public enum PedidosEstado
    {
        REQUISITADO,
        DEVOLVIDO,
        NORMAL
    }
}
