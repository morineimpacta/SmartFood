using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHibernate;
using System.Collections.Generic;
using System.Linq;
using TechnoSolution.Dominio.Entidades;

namespace TechnoSolution.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly ISession _session;

        public CategoriaController(ILogger<CategoriaController> logger, ISession session)
        {
            _logger = logger;
            _session = session;
        }

        [HttpGet]
        public IEnumerable<Categoria> Get()
        {
            return _session
                .Query<Categoria>()
                .Where(x => x.Ativo)
                .ToList();
        }
    }
}
