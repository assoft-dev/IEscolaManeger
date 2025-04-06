namespace IEscolaEntity.Controllers.Repository
{
    using IEscolaEntity.Controllers.Interfaces;
    using IEscolaEntity.Models;
    using IEscolaEntity.Models.Biblioteca;
    using ServiceStack.OrmLite;
    using System.Threading.Tasks;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using ServiceStack.OrmLite.Legacy;

    public class EstudantesIncricoesRepository: GenericRepository<EstudantesInscricoes>, IEstudantesInscricoes
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
                        var fatur = "QR " + "EST" + DateTime.Now.Year + "/" + 1;
                        return fatur;
                    }
                }
                else
                {
                    return "QR " + "EST" + DateTime.Now.Year + "/" + 1;
                }
            }
            else
            {
                var fatura = "QR " + "EST" + DateTime.Now.Year + "/" + 1;
                return fatura;
            }
        }

        public async Task<List<EstudantesInscricoes>> GetAllinclud()
        {
            var sql = DbConection.From<EstudantesInscricoes>();

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
        public async Task<EstudantesInscricoes> GetAllinclud(Expression<Func<EstudantesInscricoes, bool>> Filter = null)
        {
            var result = await DbConection.LoadSelectAsync<EstudantesInscricoes>(Filter, new string [] { "ProvinciasMunicipios" });

            var provincia = await DbConection.SelectAsync<Provincias>();
            var municipio = await DbConection.SelectAsync<Municipios>();

            if (result != null)
            {
                var t = result.FirstOrDefault();

                t.ProvinciasMunicipios.Provincias = provincia.Find(y => y.ProvinciasID == t.ProvinciasMunicipios.ProvinciasID);
                t.ProvinciasMunicipios.Municios = municipio.Find(y => y.MunicipiosID == t.ProvinciasMunicipios.MunicipiosID);
                return t;
            }
            return null;
        }
    }
}
