using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Repository
{
    public class ClasseRepository : IClasse
    {
        public ClasseRepository()
        {
            
        }

        public Task<bool> Excluir(int filter)
        {
            throw new NotImplementedException();
        }

        public Task<Classes> Get(Expression<Func<Classes, bool>> Filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<Classes>> GetAll(Expression<Func<Classes, bool>> Filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Guardar(Classes models)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Guardar(List<Classes> models)
        {
            throw new NotImplementedException();
        }
    }
}
