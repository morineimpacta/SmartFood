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
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly ISession _session;

        public UsuarioController(ILogger<UsuarioController> logger, ISession session)
        {
            _logger = logger;
            _session = session;
        }

        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return _session.Query<Usuario>().ToList();
        }


        [HttpPost]
        public Usuario Post(Usuario usuario)
        {
            try
            {
                using (var session = _session.BeginTransaction())
                {
                    _session.Save(usuario);

                    session.Commit();
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }

            return usuario;
        }

        [HttpGet]
        [Route("Login")]
        public Usuario Post(string login, string senha)
        {
            try
            {
                var bytes = Convert.FromBase64String(senha);

                var usuario = _session.Query<Usuario>()
                    .First(x => x.Login == login);

                if(usuario == null)
                {
                    _logger.Log(LogLevel.Information, "Usuario nao encontrado");
                }

                return usuario.Senha == senha ? usuario : null;

            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }

            return null;
        }

    }
}
