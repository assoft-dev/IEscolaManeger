using IEscolaEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Interfaces
{
    public interface IEstudantesInscricoes: ITransationRepository, IGeneric<EstudantesInscricoes>
    {
        Task<string> GetQR();
    }
}
