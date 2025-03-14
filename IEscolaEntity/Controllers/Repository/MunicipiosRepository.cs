using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Models;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Repository
{
    public class MunicipiosRepository: GenericRepository<Municipios>, IMunicipios
    {
        public async Task<List<Municipios>> GetAllinclud()
        {
            var result = await DbConection.LoadSelectAsync(DbConection.From<Municipios>());

            var provincia = await DbConection.SelectAsync<Provincias>();

            result.ForEach(x => {
                    x.provincias = provincia.Find(y => y.ProvinciasID == x.ProvinciasID);
            });

            return result;
        }
    }
}
