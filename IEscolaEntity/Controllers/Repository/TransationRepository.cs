using IEscolaEntity.Controllers.Helps;
using IEscolaEntity.Controllers.Interfaces;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Repository
{
    public class TransationRepository : IDisposable, ITransationRepository
    {
        #region Declaração de Variaveis
        private readonly IDbConnection DbConection;
        private IDbTransaction DbTransaction;
        #endregion

        #region Construtores
        public TransationRepository()
        {
            this.DbConection = new DataConnectionConfig().ConectionDb().OpenDbConnection();
        }

        public async Task TaskExecutes(Func<Task> func)
        {
            DbTransaction = DbConection.OpenTransaction();
            await func.Invoke();
        }
        #endregion

        #region Insertsssssssssssssssss
        public TransationRepository DoInsert<TEntity>(TEntity entity) where TEntity : class
        {
            DbConection.Insert<TEntity>(entity);
            return this;
        }
        public TransationRepository DoInsert<TEntity>(TEntity entity, bool References) where TEntity : class
        {
            if (References)
                DbConection.Save<TEntity>(entity, true);
            DbConection.Insert<TEntity>(entity);
            return this;
        }
        public TransationRepository DoInsert<T>(List<T> entity) where T : class
        {
            foreach (var item in entity)
                DbConection.Save<T>(item);
            return this;
        }
        public TEntity DoInsertReturnAsync<TEntity>(TEntity entity) where TEntity : class
        {
            var result = DbConection.Insert<TEntity>(entity, true);
            var resultData = DbConection.SingleById<TEntity>(result);
            return resultData;
        }
        public bool DoSaveAsync<TEntity>(TEntity entity) where TEntity : class
        {
            var result = DbConection.Save<TEntity>(entity, references: true);
            return result;
        }
        public TransationRepository DoInsert<TEntity>(TEntity entities, Func<TEntity, object> predicate) where TEntity : class
        {
            var newValues = predicate.Invoke(entities);
            Expression<Func<TEntity, bool>> compare = arg => predicate(arg).Equals(newValues);
            var compiled = compare.Compile();

            var existing = DbConection.Single<TEntity>(compiled);

            if (existing == null)
                this.DbConection.Save(entities);
            else
            {
                this.DbConection.Update(entities);
            }
            return this;
        }
        #endregion

        #region ListAll
        public List<TEntity> DoGet<TEntity>() where TEntity : class
        {
            return DbConection.Select<TEntity>();
        }
        public List<TEntity> DoGet<TEntity>(Expression<Func<TEntity, bool>> predicate, string[] Includes) where TEntity : class
        {
            return DbConection.LoadSelect<TEntity>(predicate, Includes);
        }
        public List<TEntity> DoGet<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return DbConection.Select<TEntity>(DbConection.From<TEntity>().Where(predicate));
        }
        public TEntity DoGetSimples<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            var data = DbConection.Select<TEntity>(DbConection.From<TEntity>().Where(predicate));
            return data.FirstOrDefault();
        }
        public long DoGetCount<TEntity>() where TEntity : class
        {
            return DbConection.Count<TEntity>(DbConection.From<TEntity>());
        } 
        public long DoGetCount<TEntity>(Expression<Func<TEntity, bool>> Filter) where TEntity : class
        {
            return DbConection.Count<TEntity>(Filter);
        }
        #endregion

        #region Update
        public TransationRepository DoUpdate<TEntity>(TEntity entities) where TEntity : class
        {
            this.DbConection.Update<TEntity>(entities);
            return this;
        }
        public TransationRepository DoUpdate<TEntity>(TEntity entities, int key = 0) where TEntity : class
        {
            if (key != 0)
            {
                var entity1 = this.DbConection.SingleById<TEntity>(key);
                if (entity1 == null)
                    new Exception();
                this.DbConection.Update<TEntity>(entity1);
            }
            else
                this.DbConection.Update<TEntity>(entities);
            return this;
        }
        public TransationRepository DoUpdate<T>(List<T> entity) where T : class
        {
            this.DbConection.UpdateAll<T>(entity);
            return this;
        }
        public TransationRepository DoUpdate<T>(string entity, object dbParameter = null) where T : class
        {
            this.DbConection.ExecuteSql(entity, dbParameter);
            return this;
        }
        public void DoUpdate(string sql, object p)
        {
            this.DbConection.ExecuteSql(sql, p);
        }
        #endregion

        #region Delete
        public TransationRepository DoDelete<TEntity>(TEntity entity) where TEntity : class
        {
            DbConection.Delete<TEntity>(entity);
            return this;
        }
        public TransationRepository DoDelete<TEntity>(int entity) where TEntity : class
        {
            var values = DbConection.SingleById<TEntity>(entity);
            DbConection.Delete<TEntity>(values);
            return this;
        }
        public TransationRepository DoDelete<TEntity>(List<TEntity> entity) where TEntity : class
        {
            foreach (var item in entity)
                DbConection.Delete<TEntity>(entity);
            return this;
        }
        public TransationRepository DoDelete<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
        {
            DbConection.Delete<TEntity>(expression);
            return this;
        }
        public TransationRepository DoDelete<TEntity>(List<TEntity> entity, Func<TEntity, bool> expression) where TEntity : class
        {
            foreach (var item in entity.Where(expression))
                DbConection.Delete<TEntity>(item);
            return this;
        }
        #endregion

        #region Saves
        public EstadoTransations EndTransaction()
        {
            try
            {
                DbTransaction.Commit();
            }
            catch (Exception exe)
            {
                RollBack();
                return new EstadoTransations
                {
                    Estado = false,
                    Exception = exe,
                };
            }
            return new EstadoTransations
            {
                Estado = true,
                Exception = null,
            };
        }
        #endregion

        #region Error end Roll Back
        public void RollBack()
        {
            DbTransaction.Rollback();
            Dispose();
        }
        public void Dispose()
        {
            DbTransaction?.Dispose();
            DbConection?.Dispose();
        }
        #endregion

    }
}
