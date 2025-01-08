using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Models;

namespace IEscolaEntity.Controllers.Repository
{
    public class EstudantesRepository : GenericRepository<Estudantes>, IEstudantes
    {
    }
}
