using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Trabalho.Final.Visual.Dominio.Interface.Services;
using Trabalho.Final.Visual.Dominio.Modelo;

namespace Trabalho.Final.Visual.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        protected readonly ILogger _logger;

        private readonly IClienteServices _iClienteServices;

        public ClienteController(IClienteServices iClienteServices, ILogger<ClienteController> logger)
        {
            _iClienteServices = iClienteServices;
            _logger = logger;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Cadastrar([FromBody] ClienteModelo request)
        {
            try
            {
                var result = await _iClienteServices.Cadastrar(request);
                if (result)
                {
                    return StatusCode(StatusCodes.Status200OK, new { Message = $"Cliente {request.Nome} cadastrado!" });
                }

                return StatusCode(StatusCodes.Status400BadRequest, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Atualizar([FromBody] ClienteModelo request)
        {
            try
            {
                var result = await _iClienteServices.Atualizar(request);
                if (result)
                {
                    return StatusCode(StatusCodes.Status200OK, new { Message = $"Cliente {request.Nome} atualizado!" });
                }

                return StatusCode(StatusCodes.Status400BadRequest, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public async Task<IActionResult> GetByid([FromRoute] int id)
        {
            try
            {
                var result = await _iClienteServices.BuscarPorId(id);
                if (result != null)
                {
                    return StatusCode(StatusCodes.Status200OK, result);
                }

                return StatusCode(StatusCodes.Status400BadRequest, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("change-status")]
        public async Task<IActionResult> MudarStatus([FromBody] MudarStatusModelo request)
        {
            try
            {
                var result = await _iClienteServices.MudarStatsu(request.Id, request.Ativo);
                if (result)
                {
                    var msg = "Ativado";
                    if (!request.Ativo)
                        msg = "Desativado";
                    
                    return StatusCode(StatusCodes.Status200OK, new { Message = $"{msg} Cliente!" });
                }

                return StatusCode(StatusCodes.Status400BadRequest, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
