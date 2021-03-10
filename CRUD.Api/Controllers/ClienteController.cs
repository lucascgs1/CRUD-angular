using CRUD.Model;
using CRUD.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace CRUD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ILogger<ClienteController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Obtem um cliente pelo codigo
        /// </summary>
        /// <param name="clienteServices">servico de cliente</param>
        /// <param name="id">codigo</param>
        /// <returns>retorna os dados do cliente</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Get([FromServices] IClienteServices clienteServices, long id)
        {
            try
            {
                var cliente = clienteServices.GetClienteById(id);

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Obtem uma lista com todos os clientes cadastrados
        /// </summary>
        /// <param name="clienteServices">servico de cliente</param>
        /// <returns>retorna uma lista de clientes</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetAll([FromServices] IClienteServices clienteServices)
        {
            try
            {
                var cliente = clienteServices.GetAllCliente().ToList();

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Salvar ou atualizar um cliente
        /// </summary>
        /// <param name="clienteServices">servico de cliente</param>
        /// <param name="cliente">dados do cliente</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Post([FromServices] IClienteServices clienteServices, [FromBody] Cliente cliente)
        {
            try
            {
                clienteServices.SalvarCliente(cliente);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Salvar novo cliente
        /// </summary>
        /// <param name="clienteServices">servico de cliente</param>
        /// <param name="cliente">dados do cliente</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Put([FromServices] IClienteServices clienteServices, [FromBody] Cliente cliente)
        {
            try
            {
                clienteServices.SalvarCliente(cliente);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// excluir dados do cliente
        /// </summary>
        /// <param name="clienteServices">servico do cliente</param>
        /// <param name="id">codigo do cliente</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Delete([FromServices] IClienteServices clienteServices, int id)
        {
            try
            {
                clienteServices.DeleteClienteById(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Problem(ex.Message);
            }
        }
    }
}
