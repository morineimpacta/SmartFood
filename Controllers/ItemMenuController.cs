using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHibernate;
using System.Collections.Generic;
using System.Linq;
using TechnoSolution.Entidades;

namespace TechnoSolution.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemMenuController : ControllerBase
    {
        private readonly ILogger<ItemMenuController> _logger;
        private readonly ISession _session;

        public ItemMenuController(ILogger<ItemMenuController> logger, ISession session)
        {
            _logger = logger;
            _session = session;
        }

        [HttpGet]
        public IEnumerable<ItemMenu> Get()
        {
            return _session.Query<ItemMenu>()
                .Where(x => x.Ativo)
                .ToList();
        }
    }
}
