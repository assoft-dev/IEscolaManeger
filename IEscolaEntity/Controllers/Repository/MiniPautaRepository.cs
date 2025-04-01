using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Models;
using ServiceStack.OrmLite;
using System.Collections.Generic;
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
    }
}
