using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Models;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Repository
{
    public class MiniPautaRepository: GenericRepository<MiniPautas>, IPautas_Mini
    {
        public async Task<List<MiniPautas>> GetAllinclud()
        {
            var sql = DbConection.From<MiniPautas>();

            var result = await DbConection.LoadSelectAsync(sql);

            var inscricao = await DbConection.SelectAsync<EstudantesInscricoes>();
            var Classe = await DbConection.SelectAsync<Classes>();
            var disciplina = await DbConection.SelectAsync<Disciplinas>();

            result.ForEach(x =>
            {
                x.Estudantes.Inscricoes = inscricao.Find(y => y.InscricaoID == x.Estudantes.InscricoesID);
                //x.ProfessoresDisciplinas.Classes = Classe.Find(y => y.ClasseID == x.CursoClasseDisciplina.ClassesID);
                //x.CursoClasseDisciplina.Disciplinas = disciplina.Find(y => y.DisciplinasID == x.CursoClasseDisciplina.DisciplinasID);
            });

            return result;
        }

        public async Task<bool> GuardarList(List<MiniPautas> miniPautas)
        {
            var resul = false;
            if (miniPautas != null)
            {
                foreach (var item in miniPautas)
                {
                    if (item.PautasID == 0)
                    {
                        await DbConection.InsertAsync<MiniPautas>(item);
                        resul = true;
                    }            
                    else
                       { await DbConection.UpdateAsync<MiniPautas>(item); resul = true; }         
                }
            }
            return resul;
        }
    }
}
