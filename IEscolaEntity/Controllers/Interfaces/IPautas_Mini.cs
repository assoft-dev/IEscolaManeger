using IEscolaEntity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Interfaces
{
    public interface IPautas_Mini: IGeneric<MiniPautas>, ITransationRepository
    {
        Task<List<MiniPautas>> GetAllinclud();
    }
}
