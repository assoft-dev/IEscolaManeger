using IEscolaEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Interfaces
{
    public interface IEstudantesInscricoes: ITransationRepository, IGeneric<EstudantesInscricoes>
    {
        Task<string> GetQR();
        Task<List<EstudantesInscricoes>> GetAllinclud();
        Task<EstudantesInscricoes> GetAllinclud(Expression<Func<EstudantesInscricoes, bool>> Filter = null);
    }
}
