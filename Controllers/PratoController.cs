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
    public class PratoController : ControllerBase
    {
        private readonly ILogger<PratoController> _logger;
        private readonly NHibernate.ISession _session;

        public PratoController(ILogger<PratoController> logger, NHibernate.ISession session)
        {
            _logger = logger;
            _session = session;
        }

        /// <summary>
        /// Lista os pratos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Listar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Prato))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<Prato>> Get()
        {
            return await _session.Query<Prato>().ToListAsync();
        }

        /// <summary>
        /// Cria um novo prato
        /// </summary>
        /// <param name="prato"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Criar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Prato))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(Prato prato)
        {
            try
            {
                using (var session = _session.BeginTransaction())
                {
                    await _session.SaveAsync(prato);

                    session.Commit();
                }

                return CreatedAtAction(nameof(Get), new { id = prato.Id }, prato);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Alterar um prato
        /// </summary>
        /// <param name="prato"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Alterar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(Prato prato)
        {
            try
            {
                var pratoDB = await _session.Query<Prato>()
                   .FirstAsync(x => x.Id == prato.Id);

                using (var session = _session.BeginTransaction())
                {
                    pratoDB.Nome = prato.Nome;
                    pratoDB.Descricao = prato.Descricao;
                    pratoDB.Avaliacao = prato.Avaliacao;
                    pratoDB.QuantidadePedidos = prato.QuantidadePedidos;
                    pratoDB.Preco = prato.Preco;

                    if(prato?.Restaurante?.Id != null)
                    {
                        var restauranteDB = await _session.Query<Restaurante>().FirstAsync(x => x.Id == prato.Restaurante.Id);
                        pratoDB.Restaurante = restauranteDB;
                    }
                    
                    await _session.UpdateAsync(pratoDB);

                    session.Commit();
                }

                return CreatedAtAction(nameof(Get), new { id = pratoDB.Id }, pratoDB);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Deleta um prato
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
                var pratoDB = await _session.Query<Prato>()
                   .FirstAsync(x => x.Id == id);

                using (var session = _session.BeginTransaction())
                {
                    await _session.DeleteAsync(pratoDB);

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

    }
}
