using FluentNHibernate.Mapping;
using TechnoSolution.Entidades;

namespace TechnoSolution.NH.Mapping
{
    public class UsuarioMap: ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Id(x => x.Id);
            Map(x => x.Nome);
            Map(x => x.Login);
            Map(x => x.Email);
            Map(x => x.Senha);
            Map(x => x.ExpiracaoSenha);
            Map(x => x.CPF);
            Map(x => x.NumeroCelular);
            Map(x => x.DataNascimento);

            Table("dbo.Usuario");
        }
    }
}
