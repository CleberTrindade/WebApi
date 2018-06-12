using RestauranteApi.Domain.Entities;
using System.Collections.Generic;

namespace RestauranteApi.Domain.Interfaces.Services
{
    public interface IRestauranteService : IServiceBase<Restaurante>
    {
        IEnumerable<Restaurante> BuscarPorNome(string nome);
    }
}
