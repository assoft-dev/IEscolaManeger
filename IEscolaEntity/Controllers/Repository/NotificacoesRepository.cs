using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Models;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Legacy;
using System;

namespace IEscolaEntity.Controllers.Repository
{
    public class NotificacoesRepository : GenericRepository<Notificacoes>, INotificacoes
    {
        public string Alert(int professorid)
        {
            var validNotifi = DbConection.Single<Notificacoes>(x => x.ProfessoresID == professorid &&
                                                                     x.Visualizado != false);

            if (validNotifi != null)
            {
                var datatrabalhada = DateTime.Now.AddDays(validNotifi.Duracao);

                var datas = DbConection.Single<Notificacoes>(x => x.Data.Date > datatrabalhada.Date &&
                                                                  x.Data.Date < datatrabalhada.Date);

                return datas.Descricao;
            }

            return null;
        }
    }
}
