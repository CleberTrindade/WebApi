using RestauranteApi.Domain.Entities;
using System.Collections.Generic;

namespace RestauranteApi.Domain.Interfaces.Repositories
{
    public interface IPratoRepository : IRepositoryBase<Prato>
    {
        IEnumerable<Prato> BuscarPorNome(string nome);
    }
}
