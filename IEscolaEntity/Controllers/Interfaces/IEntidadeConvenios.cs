using IEscolaEntity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Interfaces
{
    public interface IEntidadeConvenios: IGeneric<EntidadeConvenios>, ITransationRepository
    {
        Task<List<EntidadeConvenios>> GetAllinclud();
    }
}
