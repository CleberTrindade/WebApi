using RestauranteApi.Domain.Entities;
using RestauranteApi.Domain.Interfaces.Repositories;
using RestauranteApi.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace RestauranteApi.Domain.Services
{
    public class PratoService : ServiceBase<Prato>, IPratoService
    {
        private readonly IPratoRepository _pratoRepository;

        public PratoService(IPratoRepository pratoRepository)
            : base(pratoRepository)
        {
            _pratoRepository = pratoRepository;
        }

        public IEnumerable<Prato> BuscarPorNome(string nome)
        {
            return _pratoRepository.BuscarPorNome(nome);
        }
    }
}
