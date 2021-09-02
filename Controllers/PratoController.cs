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
    public class PratoController : ControllerBase
    {
        private readonly ILogger<PratoController> _logger;
        private readonly ISession _session;

        public PratoController(ILogger<PratoController> logger, ISession session)
        {
            _logger = logger;
            _session = session;
        }

        [HttpGet]
        public IEnumerable<Prato> Get()
        {
            return _session.Query<Prato>().ToList();
        }

        [HttpPost]
        public Prato Post(Prato prato)
        {
            try
            {
                using (var session = _session.BeginTransaction())
                {
                    _session.Save(prato);

                    session.Commit();
                }
            }
            catch (System.Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }

            return prato;
        }

    }
}
