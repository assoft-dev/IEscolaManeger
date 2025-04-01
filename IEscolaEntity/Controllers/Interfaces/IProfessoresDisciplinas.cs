using IEscolaEntity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Interfaces
{
    public interface IProfessoresDisciplinas : IGeneric<ProfessoresDisciplinas>, ITransationRepository
    {
        Task<List<ProfessoresDisciplinas>> GetAllinclud();
    }
}
