using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechnoSolution.Entidades;

namespace TechnoSolution.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly NHibernate.ISession _session;

        public UsuarioController(ILogger<UsuarioController> logger, NHibernate.ISession session)
        {
            _logger = logger;
            _session = session;
        }

        /// <summary>
        /// Lista todos os usuários da base
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuario))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<IEnumerable<Usuario>> Get()
        {
            return await _session.Query<Usuario>().ToListAsync();
        }

        /// <summary>
        /// Cria um usuário para o app
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            try
            {
                using (var session = _session.BeginTransaction())
                {
                    await _session.SaveAsync(usuario);

                    session.Commit();
                }

                return CreatedAtAction(nameof(Get), new { id = usuario.Id }, usuario);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Valida se a senha do usuario está correta
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuario))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(string login, string senha)
        {
            try
            {
                //var bytes = Convert.FromBase64String(senha);

                var usuario = await _session.Query<Usuario>()
                    .FirstAsync(x => x.Login == login);

                if(usuario == null)
                {
                    _logger.Log(LogLevel.Information, "Usuario não encontrado");
                    return NotFound();
                }

                if (usuario.Senha == senha)
                    return Ok(usuario);

                return Unauthorized();

            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return BadRequest();
            }
        }
    }
}
