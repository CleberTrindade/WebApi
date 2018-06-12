using RestauranteApi.Domain.Entities;
using System.Collections.Generic;

namespace RestauranteApi.Domain.Interfaces.Repositories
{
    public interface IRestauranteRepository : IRepositoryBase<Restaurante>
    {
        IEnumerable<Restaurante> BuscarPorNome(string nome);
    }
}
