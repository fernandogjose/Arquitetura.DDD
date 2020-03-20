using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using WebMotors.FernandoJose.Application.Interfaces;
using WebMotors.FernandoJose.Application.ViewModels;

namespace WebMotors.FernandoJose.Api.Controllers
{
    // Obs: Sempre "retorno" um Ok e não uso try catch porque criei dois middlewares, um que faz o tratamento do response e o outro de erros (exceptions) da aplicação
    [Route("api/anuncio")]
    [ApiController]
    public class AnuncioController : ControllerBase
    {
        private readonly IAnuncioAppService _anuncioAppService;

        public AnuncioController(IAnuncioAppService anuncioAppService)
        {
            _anuncioAppService = anuncioAppService;
        }

        [HttpPost("adicionar")]
        [ProducesResponseType(typeof(AnuncioAdicionarResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Adicionar(AnuncioAdicionarRequest request)
        {
            AnuncioAdicionarResponse response = _anuncioAppService.Adicionar(request);
            return Ok(response);
        }

        [HttpPut("editar")]
        [ProducesResponseType(typeof(AnuncioEditarResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Editar(AnuncioEditarRequest request)
        {
            AnuncioEditarResponse response = _anuncioAppService.Editar(request);
            return Ok(response);
        }

        [HttpDelete("deletar/{request:int}")]
        [ProducesResponseType(typeof(AnuncioDeletarResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Deletar(int request)
        {
            AnuncioDeletarResponse response = _anuncioAppService.Deletar(request);
            return Ok(response);
        }

        [HttpGet("obter/{id:int}")]
        [ProducesResponseType(typeof(AnuncioObterResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Obter(int id)
        {
            AnuncioObterResponse response = _anuncioAppService.Obter(new AnuncioObterRequest { Id = id });
            return Ok(response);
        }

        [HttpGet("listar")]
        [ProducesResponseType(typeof(IEnumerable<AnuncioListarResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Listar()
        {
            IEnumerable<AnuncioListarResponse> response = _anuncioAppService.Listar(new AnuncioListarRequest());
            return Ok(response);
        }
    }
}