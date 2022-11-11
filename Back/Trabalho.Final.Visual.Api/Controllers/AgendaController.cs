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
    public class AgendaController : ControllerBase
    {
        protected readonly ILogger _logger;

        private readonly IAgendaServices _agendaServices;

        public AgendaController(IAgendaServices agendaServices, ILogger<AgendaController> logger)
        {
            _agendaServices = agendaServices;
            _logger = logger;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Cadastrar([FromBody] AgendaModelo request)
        {
            try
            {
                var result = await _agendaServices.Cadastrar(request);
                if (result)
                {
                    return StatusCode(StatusCodes.Status200OK, new { Message = $"Agenda cadastrado!" });
                }

                return StatusCode(StatusCodes.Status400BadRequest, new { Message = "create error!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public async Task<IActionResult> GetByid([FromRoute] int id)
        {
            try
            {
                var result = await _agendaServices.BuscarPorId(id);
                if (result != null)
                {
                    return StatusCode(StatusCodes.Status200OK, result);
                }

                return StatusCode(StatusCodes.Status400BadRequest, new { Message = "user not found!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("buscarTodas")]
        public async Task<IActionResult> BuscarAgendasFuturas()
        {
            try
            {
                var result = await _agendaServices.BuscarTodos();
                if (result != null)
                {
                    return StatusCode(StatusCodes.Status200OK, result);
                }

                return StatusCode(StatusCodes.Status400BadRequest, new { Message = "error!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Deletar([FromRoute] int id)
        {
            try
            {
                var result = await _agendaServices.Deletar(id);
                if (result)
                {
                    return StatusCode(StatusCodes.Status200OK, new { Message = $"Agenda excluida!" });
                }

                return StatusCode(StatusCodes.Status400BadRequest, new { Message = "delete error!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }
    }
}
