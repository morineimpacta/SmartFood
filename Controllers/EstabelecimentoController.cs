using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using TechnoSolution.Dominio;

namespace TechnoSolution.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstabelecimentoController : ControllerBase
    {
        private readonly ILogger<EstabelecimentoController> _logger;
        private readonly ISession _session;

        public EstabelecimentoController(ILogger<EstabelecimentoController> logger, ISession session)
        {
            _logger = logger;
            _session = session;
        }

        [HttpGet]
        public IEnumerable<Estabelecimento> Get()
        {
            return _session.Query<Estabelecimento>().ToList();
        }


        [HttpPost]
        public Estabelecimento Post(Estabelecimento estab)
        {
            try
            {
                using (var session = _session.BeginTransaction())
                {
                    _session.Save(estab);

                    session.Commit();
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }

            return estab;
        }

    }
}
