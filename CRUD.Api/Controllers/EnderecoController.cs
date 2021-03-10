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
    public class EnderecoController : ControllerBase
    {
        private readonly ILogger<EnderecoController> _logger;

        public EnderecoController(ILogger<EnderecoController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Obtem um endereco pelo codigo
        /// </summary>
        /// <param name="enderecoServices">servico de endereco</param>
        /// <param name="id">codigo</param>
        /// <returns>retorna os dados do endereco</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Get([FromServices] IEnderecoServices enderecoServices, int id)
        {
            try
            {
                var endereco = enderecoServices.GetEnderecoById(id);

                return Ok(endereco);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Obtem uma lista com todos os endereco cadastrados
        /// </summary>
        /// <param name="enderecoServices">servico de endereco</param>
        /// <param name="userId">codigo do usuario</param>
        /// <returns>retorna uma lista de enderecos</returns>
        [HttpGet("listAllByUser/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetAllByUser([FromServices] IEnderecoServices enderecoServices, int userId)
        {
            try
            {
                var endereco = enderecoServices.GetAllEnderecoByUserId(userId).ToList();

                return Ok(endereco);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Salvar ou atualizar um endereco
        /// </summary>
        /// <param name="enderecoServices">servico de endereco</param>
        /// <param name="endereco">dados do endereco</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Post([FromServices] IEnderecoServices enderecoServices, [FromBody] Endereco endereco)
        {
            try
            {
                enderecoServices.SalvarEndereco(endereco);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Salvar novo endereco
        /// </summary>
        /// <param name="enderecoServices">servico de cliente</param>
        /// <param name="endereco">dados do endereco</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Put([FromServices] IEnderecoServices enderecoServices, [FromBody] Endereco endereco)
        {
            try
            {
                enderecoServices.SalvarEndereco(endereco);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// excluir dados do endereco
        /// </summary>
        /// <param name="enderecoServices">servico de endereco</param>
        /// <param name="id">codigo do endereco</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Delete([FromServices] IEnderecoServices enderecoServices, int id)
        {
            try
            {
                enderecoServices.DeleteEnderecoById(id);

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
