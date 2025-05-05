using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Models;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Repository
{
    public class EntidadeConvenioRepository : GenericRepository<EntidadeConvenios>, IEntidadeConvenios
    {
        public async Task<List<EntidadeConvenios>> GetAllinclud()
        {
            var sql = DbConection.From<EntidadeConvenios>();

            var result = await DbConection.LoadSelectAsync(sql);

            var curso = await DbConection.SelectAsync<Cursos>();
            var Classe = await DbConection.SelectAsync<Classes>();
            var disciplina = await DbConection.SelectAsync<Disciplinas>();

            result.ForEach(x =>
            {
                x.CursoClasseDisciplina.Cursos = curso.Find(y => y.CursosID == x.CursoClasseDisciplina.CursosID);
                x.CursoClasseDisciplina.Classes = Classe.Find(y => y.ClassesID == x.CursoClasseDisciplina.ClassesID);
                x.CursoClasseDisciplina.Disciplinas = disciplina.Find(y => y.DisciplinasID == x.CursoClasseDisciplina.DisciplinasID);
            });

            return result;
        }
    }
}

