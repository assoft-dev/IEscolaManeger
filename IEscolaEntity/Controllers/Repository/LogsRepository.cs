using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Models;

namespace IEscolaEntity.Controllers.Repository
{
    public class LogsRepository :  GenericRepository<Logs>, Ilogs
    {
    }
}
