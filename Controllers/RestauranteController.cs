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
        /// Lista todos os restaurantes criados
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Restaurante))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<IEnumerable<Restaurante>> Get()
        {
            return await _session.Query<Restaurante>().ToListAsync();
        }

        /// <summary>
        /// Cria um novo restaurante
        /// </summary>
        /// <param name="restaurante"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
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

    }
}
