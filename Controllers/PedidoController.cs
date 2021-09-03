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
    public class PedidoController : ControllerBase
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly NHibernate.ISession _session;

        public PedidoController(ILogger<PedidoController> logger, NHibernate.ISession session)
        {
            _logger = logger;
            _session = session;
        }

        /// <summary>
        /// Lista os pedidos criados
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Pedido))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<IEnumerable<Pedido>> Get()
        {
            return await _session.Query<Pedido>().ToListAsync();
        }
    }
}
