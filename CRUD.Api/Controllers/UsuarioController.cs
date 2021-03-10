using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using CRUD.Model;
using CRUD.Services.Interfaces;



namespace CRUD.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        ///  Obtem os dados de um usuario
        /// </summary>
        /// <param name="usuarioServices">servico de usuario</param>
        /// <param name="id">codigo do usuario</param>
        /// <returns>dados do usuario</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Get([FromServices] IUsuarioServices usuarioServices, int id)
        {
            try
            {
                var usuarios = usuarioServices.GetUsuarioById(id);

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Problem(ex.Message);
            }
        }
         
        /// <summary>
        /// retorna todos os usuarios cadastrados
        /// </summary>
        /// <param name="usuarioServices">servico de usuario</param>
        /// <returns>lista de usuarios</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetAll([FromServices] IUsuarioServices usuarioServices)
        {
            try
            {
                var usuarios = usuarioServices.GetAllUsuario().ToList();

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Salva ou atualiza um usuario
        /// </summary>
        /// <param name="usuarioServices">servico de usuario</param>
        /// <param name="usuario">Dados do usuario</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Post([FromServices] IUsuarioServices usuarioServices, [FromBody] Usuario usuario)
        {
            try
            {
                usuarioServices.SalvarUsuario(usuario);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Salva um novo Usuario
        /// </summary>
        /// <param name="usuarioServices">servico do usuario</param>
        /// <param name="usuario">Dados do usuario</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Put([FromServices] IUsuarioServices usuarioServices, [FromBody] Usuario usuario)
        {
            try
            {
                usuarioServices.SalvarUsuario(usuario);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Problem(ex.Message);
            }
        }


        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="usuarioServices">Servico de usuario</param>
        /// <param name="id">codigo do usuario</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Delete([FromServices] IUsuarioServices usuarioServices, int id)
        {
            try
            {
                usuarioServices.DeleteUsuarioById(id);

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
