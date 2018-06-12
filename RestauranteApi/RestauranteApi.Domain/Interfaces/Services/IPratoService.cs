using RestauranteApi.Domain.Entities;
using System.Collections.Generic;

namespace RestauranteApi.Domain.Interfaces.Services
{
    public interface IPratoService : IServiceBase<Prato>
    {
        IEnumerable<Prato> BuscarPorNome(string nome);
    }
}
