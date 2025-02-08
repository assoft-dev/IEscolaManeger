using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Models;
using IEscolaEntity.Models.Biblioteca;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Repository.Biblioteca
{
    public class PedidosRepository : GenericRepository<Pedidos>, IPedidos
    {
        public async Task<string> GetQR()
        {
            return await GetListaUnik();
        }
        private async Task<string> GetListaUnik()
        {
            var sql1 = DbConection.From<Pedidos>().OrderByDescending(x => x.PedidosID);

            var result = await DbConection.SingleAsync<Pedidos>(sql1);

            if (result != null)
            {
                var fatura = result.DocNumero;

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
