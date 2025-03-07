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
    public class GenericRepository<T> : TransationRepository, IGeneric<T> where T : class
    {
        #region Declaração de Variaveis
        public readonly IDbConnection DbConection;
        #endregion

        #region Contrutores da Classe
        public GenericRepository()
        {
            this.DbConection = DataConnectionConfig.Conection().OpenDbConnection();
        }

        ~ GenericRepository()
        {
            this.DbConection.Close();
        }
        #endregion

        #region Apagar os dados

        public async Task<bool> Excluir(T filter)
        {
            return await DbConection.DeleteAsync<T>(filter) > 0;
        }

        public async Task<bool> Excluir(Expression<Func<T, bool>> filter)
        {
            return await DbConection.DeleteAsync<T>(filter) > 0;
        }
        #endregion

        #region Listagem Geral

        public async Task<bool> Get(Expression<Func<T, bool>> Filter)
        {
            var result = await DbConection.ExistsAsync<T>(Filter);
            return result;
        }

        public async Task<T> Get(Expression<Func<T, bool>> Filter, string[] includes = null) 
        {
            var result = await DbConection.LoadSelectAsync<T>(Filter, includes);
            return result.FirstOrDefault();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> Filter = null)
        {
            var RESULT = await DbConection.LoadSelectAsync<T>(Filter);
                return RESULT;
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> Filter = null, string[] includes = null)
        {
             var RESULT = await DbConection.LoadSelectAsync<T>(Filter, includes);
            return RESULT;
        }
        public async Task<List<object>> GetAll(Expression<Func<T, bool>> Filter = null, Expression<Func<T, object>> FildesDevolucao = null)
        {
            var q = DbConection.From<T>()
                               .Where(Filter)
                               .Select(FildesDevolucao);

            var results = await DbConection.SelectAsync<object>(q);
            return results;
        }
        public async Task<Dictionary<object, object>> GetAllDicionary(Expression<Func<T, bool>> Filter = null, Expression<Func<T, object>> FildesDevolucao = null)
        {
            var q = DbConection.From<T>()
                               .Where(Filter)
                               .Select(FildesDevolucao);

            var results = await DbConection.DictionaryAsync<object, object>(q);
            return results;
        }
        #endregion

        #region Guardar Informação
        public async Task<bool> Guardar(T models, bool referencias = false)
        {
            return await DbConection.SaveAsync<T>(models, referencias);
        }
        public async Task<bool> Guardar(T models, int ID)
        {
            return (await DbConection.UpdateAsync<T>(models)) > 0 ? true : false;
        }

        public async Task<bool> Guardar(List<T> models)
        {
            var result = await DbConection.SaveAllAsync<T>(models.AsEnumerable<T>());

            if (result > 0)
                return true;
            return false;
        }

        public async Task<long> Guardar(T models, Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)
                return await DbConection.InsertAsync<T>(models, true);
            else
                return await DbConection.UpdateAsync<T>(models, filter);
        }
        #endregion
    }
}
