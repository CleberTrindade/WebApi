using RestauranteApi.Domain.Entities;
using RestauranteApi.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RestauranteApi.Data.Repositories
{
    public class PratoRepository : RepositoryBase<Prato>, IPratoRepository
    {
        public IEnumerable<Prato> BuscarPorNome(string nome)
        {
            return Db.Pratos.Where(p => p.NomePrato == nome);
        }
    }
}
