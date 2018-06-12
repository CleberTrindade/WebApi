using RestauranteApi.Domain.Entities;
using RestauranteApi.Domain.Interfaces.Services;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PratoApi.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/v1/public")]
    public class PratoController : ApiController
    {

        private readonly IPratoService _pratoService;

        public PratoController(IPratoService pratoService)
        {
            _pratoService = pratoService;
        }

        //private RestaurantesDataContexts db = new RestaurantesDataContexts();
        [HttpGet]
        [Route("pratos")]
        public HttpResponseMessage ObterPratos()
        {
            var result = _pratoService.BuscarTodos().ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("pratos_/{pratoId}")]
        public HttpResponseMessage ObterPratosPorId(int pratoId)
        {
            var result = _pratoService.BuscarPorId(pratoId);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("pratos/{nome}")]
        public HttpResponseMessage ObterPratosPorNome(string nome)
        {
            var result = _pratoService.BuscarPorNome(nome);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("pratos")]
        public HttpResponseMessage InserirPrato(Prato prato)
        {
            if (prato == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                _pratoService.Inserir(prato);

                var result = _pratoService.BuscarTodos().ToList();
                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir o Prato.");
            }
        }

        [HttpPut]
        [Route("pratos")]
        public HttpResponseMessage AtualizarPrato(Prato prato)
        {
            if (prato == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                _pratoService.Atualizar(prato);

                var result = _pratoService.BuscarTodos().ToList();
                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao atualizar o Prato.");
            }
        }

        [HttpDelete]
        [Route("pratos/{pratoId}")]
        public HttpResponseMessage RemoverPrato(int pratoId)
        {
            if (pratoId <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                var obj = _pratoService.BuscarPorId(pratoId);
                _pratoService.Remover(obj);

                var result = _pratoService.BuscarTodos().ToList();
                return Request.CreateResponse(HttpStatusCode.OK, "Prato excluido com sucesso.");

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao atualizar o Prato.");
            }
        }

        
    }
}