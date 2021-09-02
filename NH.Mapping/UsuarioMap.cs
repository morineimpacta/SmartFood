using FluentNHibernate.Mapping;
using TechnoSolution.Entidades;

namespace TechnoSolution.NH.Mapping
{
    public class UsuarioMap: ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Id(x => x.Id, "ID_USUARIO");
            
            Map(x => x.Nome, "NOME");
            Map(x => x.Login, "LOGIN");
            Map(x => x.Senha, "SENHA");
            Map(x => x.Telefone, "TELEFONE");
            Map(x => x.Visibilidade, "VISIBILIDADE");

            Table("dbo.Usuario");
        }
    }
}
