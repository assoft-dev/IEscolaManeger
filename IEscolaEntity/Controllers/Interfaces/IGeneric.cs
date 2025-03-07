using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Interfaces
{
    public interface IGeneric<T> where T : class
    {

        #region Guardar - Update        
        Task<bool> Guardar(List<T> models);
        Task<bool> Guardar(T models, bool referencias = false);
        Task<long> Guardar(T models, Expression<Func<T, bool>> Filter = null);
        #endregion

        #region Listagem
        Task<bool> Get(Expression<Func<T, bool>> Filter);
        Task<T> Get(Expression<Func<T, bool>> Filter, string[] includes = null);
        Task<List<T>> GetAll(Expression<Func<T, bool>> Filter = null);
        Task<List<T>> GetAll(Expression<Func<T, bool>> Filter, string [] includes);
        Task<List<object>> GetAll(Expression<Func<T, bool>> Filter, Expression<Func<T, object>> FildesDevolucao = null);
        Task<Dictionary<object, object>> GetAllDicionary(Expression<Func<T, bool>> Filter = null, Expression<Func<T, object>> FildesDevolucao = null);

        #endregion

        #region Excluir
        Task<bool> Excluir(T models);
        Task<bool> Excluir(Expression<Func<T, bool>> filter);
        #endregion
    }
}
