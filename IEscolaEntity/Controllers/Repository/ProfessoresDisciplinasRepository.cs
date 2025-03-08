using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Models;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Repository
{
    public class ProfessoresDisciplinasRepository: GenericRepository<ProfessoresDisciplinas>, IProfessoresDisciplinas
    {
        public async Task<List<ProfessoresDisciplinas>> GetAllinclud()
        {
            var sql = DbConection.From<ProfessoresDisciplinas>();

            var result = await DbConection.LoadSelectAsync(sql);

            var curso = await DbConection.SelectAsync<Cursos>();
            var Classe = await DbConection.SelectAsync<Classes>();
            var disciplina = await DbConection.SelectAsync<Disciplinas>();

            result.ForEach(x =>
            {
                x.CursoClasseDisciplina.Cursos = curso.Find(y => y.CursosID == x.CursoClasseDisciplina.CursosID);
                x.CursoClasseDisciplina.Classes = Classe.Find(y => y.ClasseID == x.CursoClasseDisciplina.ClassesID);
                x.CursoClasseDisciplina.Disciplinas = disciplina.Find(y => y.DisciplinasID == x.CursoClasseDisciplina.DisciplinasID);
            });

            return result;
        }
    }
}
