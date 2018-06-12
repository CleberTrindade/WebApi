using RestauranteApi.Domain.Entities;
using RestauranteApi.Domain.Interfaces.Repositories;
using RestauranteApi.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace RestauranteApi.Domain.Services
{
    public class RestauranteService : ServiceBase<Restaurante>, IRestauranteService
    {
        private readonly IRestauranteRepository _restauranteRepository;

        public RestauranteService(IRestauranteRepository restauranteRepository)
            : base(restauranteRepository)
        {
            _restauranteRepository = restauranteRepository;
        }

        public IEnumerable<Restaurante> BuscarPorNome(string nome)
        {
            return _restauranteRepository.BuscarPorNome(nome);
        }
    }
}
