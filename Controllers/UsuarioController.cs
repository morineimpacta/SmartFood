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
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        [HttpGet]
        [Route("Listar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuario))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<Usuario>> Get()
        {
            return await _session.Query<Usuario>().ToListAsync();
        }

        /// <summary>
        /// Cria um usuário 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Criar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        /// Atualiza o usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Alterar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(Usuario usuario)
        {
            try
            {
                var usuarioDB = await _session.Query<Usuario>()
                   .FirstAsync(x => x.Id == usuario.Id);

                using (var session = _session.BeginTransaction())
                {
                    usuarioDB.Login = usuario.Login;
                    usuarioDB.Nome = usuario.Nome;
                    usuarioDB.Senha = usuario.Senha;
                    usuarioDB.Telefone = usuario.Telefone;
                    usuarioDB.Visibilidade = usuario.Visibilidade;

                    await _session.UpdateAsync(usuarioDB);

                    session.Commit();
                }

                return CreatedAtAction(nameof(Get), new { id = usuarioDB.Id }, usuarioDB);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Deletar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var usuarioDB = await _session.Query<Usuario>()
                   .FirstAsync(x => x.Id == id);

                using (var session = _session.BeginTransaction())
                {
                    await _session.DeleteAsync(usuarioDB);

                    session.Commit();
                }

                return Ok();
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
        public async Task<IActionResult> Login(Usuario usuario)
        {
            try
            {
                //var bytes = Convert.FromBase64String(senha);

                var usuarioDB = await _session.Query<Usuario>()
                    .FirstAsync(x => x.Login == usuario.Login);

                if(usuarioDB == null)
                {
                    _logger.Log(LogLevel.Information, "Usuario não encontrado");
                    return NotFound();
                }

                if (usuarioDB.Senha == usuario.Senha)
                    return Ok(usuarioDB);

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
