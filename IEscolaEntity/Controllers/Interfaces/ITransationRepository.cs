using IEscolaEntity.Controllers.Helps;
using IEscolaEntity.Controllers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Interfaces
{
    public interface ITransationRepository
    {
        void Dispose();

        #region Delete
        TransationRepository DoDelete<TEntity>(int entity) where TEntity : class;
        TransationRepository DoDelete<TEntity>(List<TEntity> entity) where TEntity : class;
        TransationRepository DoDelete<TEntity>(TEntity entity) where TEntity : class;
        TransationRepository DoDelete<TEntity>(List<TEntity> entity, Func<TEntity, bool> expression) where TEntity : class;
        TransationRepository DoDelete<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class;
        #endregion

        #region Get
        List<TEntity> DoGet<TEntity>() where TEntity : class;
        List<TEntity> DoGet<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        int DoGetCount<TEntity>() where TEntity : class;
        #endregion

        #region Insert
        TransationRepository DoInsert<TEntity>(TEntity entity) where TEntity : class;
        TransationRepository DoInsert<T>(List<T> entity) where T : class;
        TEntity DoInsertReturnAsync<TEntity>(TEntity entity) where TEntity : class;
        TransationRepository DoInsert<TEntity>(TEntity entities, Func<TEntity, object> predicate) where TEntity : class;
        #endregion

        #region Update
        TransationRepository DoUpdate<T>(List<T> entity) where T : class;
        TransationRepository DoUpdate<T>(string entity, object vs = null) where T : class;
        #endregion

        #region Saves
        EstadoTransations EndTransaction();
        TransationRepository DoInsert<TEntity>(TEntity entity, bool References) where TEntity : class;

        bool DoSaveAsync<TEntity>(TEntity entity) where TEntity : class;
        Task TaskExecutes(Func<Task> func);
        #endregion
    }
}
