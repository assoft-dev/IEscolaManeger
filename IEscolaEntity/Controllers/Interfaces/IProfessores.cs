using IEscolaEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Interfaces
{
    public interface IProfessores: ITransationRepository, IGeneric<Professores>
    {
        Task<string> GetQR();
        Task<List<Professores>> GetAllinclud();
    }
}
