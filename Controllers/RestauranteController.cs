using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using TechnoSolution.Entidades;

namespace TechnoSolution.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestauranteController : ControllerBase
    {
        private readonly ILogger<RestauranteController> _logger;
        private readonly ISession _session;

        public RestauranteController(ILogger<RestauranteController> logger, ISession session)
        {
            _logger = logger;
            _session = session;
        }

        [HttpGet]
        public IEnumerable<Restaurante> Get()
        {
            return _session.Query<Restaurante>().ToList();
        }


        [HttpPost]
        public Restaurante Post(Restaurante estab)
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
