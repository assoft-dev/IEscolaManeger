using IEscolaEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Interfaces
{
    public interface IDisciplinaPrograma : IGeneric<DisciplinasProgramas>, ITransationRepository
    {
        Task<List<DisciplinasProgramas>> GetAllinclud();
    }
}
