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
    public class RestauranteController : ControllerBase
    {
        private readonly ILogger<RestauranteController> _logger;
        private readonly NHibernate.ISession _session;

        public RestauranteController(ILogger<RestauranteController> logger, NHibernate.ISession session)
        {
            _logger = logger;
            _session = session;
        }

        /// <summary>
        /// Lista todos os restaurantes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Listar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Restaurante))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<Restaurante>> Get()
        {
            return await _session.Query<Restaurante>().ToListAsync();
        }

        /// <summary>
        /// Cria um novo restaurante
        /// </summary>
        /// <param name="restaurante"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Criar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(Restaurante restaurante)
        {
            try
            {
                using (var session = _session.BeginTransaction())
                {
                    await _session.SaveAsync(restaurante);

                    session.Commit();
                }

                return CreatedAtAction(nameof(Get), new { id = restaurante.Id }, restaurante);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Alterar o restaurante
        /// </summary>
        /// <param name="restaurante"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Alterar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(Restaurante restaurante)
        {
            try
            {
                var restauranteDB = await _session.Query<Restaurante>()
                   .FirstAsync(x => x.Id == restaurante.Id);

                using (var session = _session.BeginTransaction())
                {
                    restauranteDB.Nome = restaurante.Nome;
                    restauranteDB.Estado = restaurante.Estado;
                    restauranteDB.Cidade = restaurante.Cidade;
                    restauranteDB.Rua = restaurante.Rua;
                    restauranteDB.Numero = restaurante.Numero;
                    restauranteDB.Avaliacao = restaurante.Avaliacao;
                    restauranteDB.URL = restaurante.URL;

                    await _session.UpdateAsync(restauranteDB);

                    session.Commit();
                }

                return CreatedAtAction(nameof(Get), new { id = restauranteDB.Id }, restauranteDB);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Deleta um restaurante
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
                var restauranteDB = await _session.Query<Restaurante>()
                   .FirstAsync(x => x.Id == id);

                using (var session = _session.BeginTransaction())
                {
                    await _session.DeleteAsync(restauranteDB);

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
