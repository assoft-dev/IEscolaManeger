using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Models;
using ServiceStack;
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

                var result = DbConection.Select<Notificacoes>(x => x.Data > datatrabalhada.Date &&
                                                                  x.Data < datatrabalhada.Date).FirstNonDefault();

                if (result != null) { 
                
                    return result.Descricao.ToString();
                }
                return null;
            }

            return null;
        }
    }
}
