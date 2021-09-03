using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHibernate.Linq;
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
        /// Lista os pratos existentes
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Prato))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<IEnumerable<Prato>> Get()
        {
            return await _session.Query<Prato>().ToListAsync();
        }

        /// <summary>
        /// Cria um novo prato
        /// </summary>
        /// <param name="prato"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Prato))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
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
            catch (System.Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return BadRequest();
            }
        }

    }
}
