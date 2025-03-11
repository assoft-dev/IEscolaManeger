using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Models;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Repository
{
    public class ProfessoresRepository: GenericRepository<Professores>, IProfessores
    {
        public async Task<string> GetQR()
        {
            return await GetListaUnik();
        }

        private async Task<string> GetListaUnik()
        {
            var sql1 = DbConection.From<EstudantesInscricoes>().OrderByDescending(x => x.InscricaoID);

            var result = await DbConection.SingleAsync<EstudantesInscricoes>(sql1);

            if (result != null)
            {
                var fatura = result.Codigo;

                if (fatura != null)
                {
                    var tipo = fatura.Split(' ').FirstOrDefault();
                    var serie = fatura.Split(' ').LastOrDefault().Split('/').FirstOrDefault();
                    var numero = fatura.Split('/').LastOrDefault();

                    var serieFilterAno = Convert.ToInt32(serie.Substring(serie.Length - 4));

                    if (serieFilterAno == DateTime.Now.Year)
                    {
                        var numerosomado = Convert.ToInt32(numero) + 1;
                        var minhafatura = tipo + " " + serie + "/" + numerosomado;
                        return minhafatura;
                    }
                    else
                    {
                        var fatur = "QR " + "PRO" + DateTime.Now.Year + "/" + 1;
                        return fatur;
                    }
                }
                else
                {
                    return "QR " + "PRO" + DateTime.Now.Year + "/" + 1;
                }
            }
            else
            {
                var fatura = "QR " + "PRO" + DateTime.Now.Year + "/" + 1;
                return fatura;
            }
        }

        public async Task<List<Professores>> GetAllinclud()
        {
            var sql = DbConection.From<Professores>();

            var result = await DbConection.LoadSelectAsync(sql);

            var provincia = await DbConection.SelectAsync<Provincias>();
            var municipio = await DbConection.SelectAsync<Municipios>();

            result.ForEach(x =>
            {
                x.ProvinciasMunicipios.Provincias = provincia.Find(y => y.ProvinciasID == x.ProvinciasMunicipios.ProvinciasID);
                x.ProvinciasMunicipios.Municios = municipio.Find(y => y.MunicipiosID == x.ProvinciasMunicipios.MunicipiosID);
            });

            return result;
        }
    }
}
