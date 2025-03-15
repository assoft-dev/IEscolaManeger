using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Models;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Repository
{
    public class EntidadeRepository: GenericRepository<Entidade>, IEntidades
    {
        public async Task<List<Entidade>> GetAllinclud()
        {
            var sql = DbConection.From<Entidade>();

            var result = await DbConection.LoadSelectAsync(sql);

            var curso = await DbConection.SelectAsync<Provincias>();
            var Classe = await DbConection.SelectAsync<Municipios>();

            result.ForEach(x =>
            {
                x.ProvinciasMunicipios.Provincias = curso.Find(y => y.ProvinciasID == x.ProvinciasMunicipios.ProvinciasID);
                x.ProvinciasMunicipios.Municios = Classe.Find(y => y.MunicipiosID == x.ProvinciasMunicipios.MunicipiosID);
            });

            return result;
        }
    }
}
