using IEscolaEntity.Controllers.Helps;
using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Models;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Repository
{
    public class DisciplinaProgramaRepository : GenericRepository<DisciplinasProgramas>, IDisciplinaPrograma
    {
        public async Task<List<DisciplinasProgramas>> GetAllinclud()
        {
            var sql = DbConection.From<DisciplinasProgramas>();

            var result = await DbConection.LoadSelectAsync(sql);

            var curso = await DbConection.SelectAsync<Cursos>();
            var Classe = await DbConection.SelectAsync<Classes>();
            var disciplina = await DbConection.SelectAsync<Disciplinas>();

            result.ForEach( x =>
            {
                x.CursoClasseDisciplina.Cursos = curso.Find(y => y.CursosID == x.CursoClasseDisciplina.CursosID);
                x.CursoClasseDisciplina.Classes = Classe.Find(y => y.ClassesID == x.CursoClasseDisciplina.ClassesID);
                x.CursoClasseDisciplina.Disciplinas = disciplina.Find(y => y.DisciplinasID == x.CursoClasseDisciplina.DisciplinasID);
            });

            return result;
        }
    }
}
