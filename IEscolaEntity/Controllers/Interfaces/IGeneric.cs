﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Interfaces
{
    public interface IGeneric<T> where T : class
    {

        #region Guardar - Update
        Task<int> Guardar(T models);
        Task<bool> Guardar(List<T> models);
        Task<bool> Guardar(T models, bool devolver = false);
        #endregion

        #region Listagem
        Task<T>       Get(Expression<Func<T, bool>> Filter, string[] includes = null);
        Task<List<T>> GetAll(Expression<Func<T, bool>> Filter = null, string[] includes = null);

        #endregion

        #region Excluir
        Task<bool> Excluir(int filter);

        #endregion
    }
}