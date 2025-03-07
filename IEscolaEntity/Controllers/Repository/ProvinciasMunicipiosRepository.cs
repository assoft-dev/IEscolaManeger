using IEscolaEntity.Controllers.Helps;
using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Models;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Repository
{
    public class ProvinciasMunicipiosRepository: GenericRepository<ProvinciasMunicipios>, IProvinciasMunicipios
    {
    }
}
