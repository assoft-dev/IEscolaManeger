﻿using IEscolaEntity.Controllers.Helps;
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
        private readonly IDbConnection DbConection;
        #endregion

        #region Contrutores da Classe
        public GenericRepository()
        {
            this.DbConection = DataConnectionConfig.Conection().OpenDbConnection();
        }
        #endregion

        #region Apagar os dados
        public async Task<bool> Excluir(int filter)
        {
            return await DbConection.DeleteAsync<T>(filter) > 0;

            if (result > 0)
                return true;
            else
                return false;
        }
        #endregion

        #region Listagem Geral
        public async Task<T> Get(Expression<Func<T, bool>> Filter, string[] includes = null) 
        {
            var result = await DbConection.LoadSelectAsync<T>(Filter, includes);
            return result.FirstOrDefault();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> Filter = null, string[] includes = null)
        {
            return await DbConection.LoadSelectAsync<T>(Filter, includes);
        }
        #endregion


        #region Guardar Informação
        public async Task<long> Guardar(T models)
        {
            return await DbConection.InsertAsync<T>(models, true);
        }

        public async Task<bool> Guardar(T models, bool referencias)
        {
             return await DbConection.SaveAsync<T>(models, referencias);
        }

        public async Task<bool> Guardar(List<T> models)
        {
            var result = await DbConection.SaveAllAsync<T>(models.AsEnumerable<T>());

            if (result > 0)
                return true;
            return false;
        }
        #endregion
    }
}