using RestauranteApi.Domain.Entities;
using RestauranteApi.Domain.Interfaces.Services;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RestauranteApi.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/v1/public")]
    public class RestaurantesController : ApiController
    {

        private readonly IRestauranteService _restauranteService;

        public RestaurantesController(IRestauranteService restauranteService)
        {
            _restauranteService = restauranteService;
        }

        [HttpGet]
        [Route("restaurantes")]
        public HttpResponseMessage ObterRestaurantes()
        {
            var result = _restauranteService.BuscarTodos().ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("restaurantes/{nome}")]
        public HttpResponseMessage ObterRestaurantePorNome(string nome)
        {
            var result = _restauranteService.BuscarPorNome(nome);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("restaurantes_/{id}")]
        public HttpResponseMessage ObterRestaurantePorId(int id)
        {
            var result = _restauranteService.BuscarPorId(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("restaurantes")]
        public HttpResponseMessage InserirRestaurante(Restaurante restaurante)
        {
            if (restaurante == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                _restauranteService.Inserir(restaurante);

                var result = _restauranteService.BuscarTodos().ToList();
                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir o Restaurante.");
            }
        }

        [HttpPut]
        [Route("restaurantes")]
        public HttpResponseMessage AtualizarPrato(Restaurante restaurante)
        {
            if (restaurante == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                _restauranteService.Atualizar(restaurante);

                var result = _restauranteService.BuscarTodos().ToList();
                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao atualizar o Restaurante informado.");
            }
        }

        [HttpDelete]
        [Route("restaurantes/{RestauranteId}")]
        public HttpResponseMessage RemoverPrato(int RestauranteId)
        {
            if (RestauranteId <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                var rest = _restauranteService.BuscarPorId(RestauranteId);
                _restauranteService.Remover(rest);

                var result = _restauranteService.BuscarTodos().ToList();
                return Request.CreateResponse(HttpStatusCode.OK, "Restaurante excluido com sucesso.");

            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao atualizar o Restaurante.");
            }
        }


    }
}