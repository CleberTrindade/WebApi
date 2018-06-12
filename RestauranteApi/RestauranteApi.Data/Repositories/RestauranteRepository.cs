using RestauranteApi.Domain.Entities;
using RestauranteApi.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApi.Data.Repositories
{
    public class RestauranteRepository : RepositoryBase<Restaurante>, IRestauranteRepository
    {
        public IEnumerable<Restaurante> BuscarPorNome(string nome)
        {
            return Db.Restaurantes.Where(p => p.Nome == nome);
        }
    }
}
