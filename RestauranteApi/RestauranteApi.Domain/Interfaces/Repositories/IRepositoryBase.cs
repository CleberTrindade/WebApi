using System.Collections.Generic;

namespace RestauranteApi.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Inserir(TEntity obj);

        TEntity BuscarPorId(int id);

        IEnumerable<TEntity> BuscarTodos();

        void Atualizar(TEntity obj);

        void Remover(TEntity obj);

        void Dispose();
    }
}
