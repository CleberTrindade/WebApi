using RestauranteApi.Domain.Interfaces.Repositories;
using RestauranteApi.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace RestauranteApi.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public void Inserir(TEntity obj)
        {
            _repositoryBase.Inserir(obj);
        }

        public TEntity BuscarPorId(int id)
        {
            return _repositoryBase.BuscarPorId(id);
        }        

        public IEnumerable<TEntity> BuscarTodos()
        {
            return _repositoryBase.BuscarTodos();
        }

        public void Remover(TEntity obj)
        {
            _repositoryBase.Remover(obj);
        }

        public void Atualizar(TEntity obj)
        {
            _repositoryBase.Atualizar(obj);
        }

        public void Dispose()
        {
            _repositoryBase.Dispose();
        }

        
    }
}