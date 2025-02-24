namespace IEscolaEntity.Controllers.Repository
{
    using IEscolaEntity.Controllers.Interfaces;
    using IEscolaEntity.Models;
    using IEscolaEntity.Models.Biblioteca;
    using ServiceStack.OrmLite;
    using System.Threading.Tasks;
    using System;
    using System.Linq;

    public class EstudantesIncricoesRepository: GenericRepository<EstudantesInscricoes>, IEstudantesInscricoes
    {
        public async Task<string> GetQR()
        {
            return await GetListaUnik();
        }
        private async Task<string> GetListaUnik()
        {
            var sql1 = DbConection.From<Estudantes>().OrderByDescending(x => x.InscricoesID);

            var result = await DbConection.SingleAsync<Estudantes>(sql1);

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
                        var fatur = "QR " + "FAC" + DateTime.Now.Year + "/" + 1;
                        return fatur;
                    }
                }
                else
                {
                    return "QR " + "FAC" + DateTime.Now.Year + "/" + 1;
                }
            }
            else
            {
                var fatura = "QR " + "FAC" + DateTime.Now.Year + "/" + 1;
                return fatura;
            }
        }
    }
}
