using FluentNHibernate.Mapping;
using TechnoSolution.Entidades;

namespace TechnoSolution.NH.Mapping
{
    public class EstabelecimentoMap: ClassMap<Estabelecimento>
    {
        public EstabelecimentoMap()
        {
            Id(x => x.Id);
            Map(x => x.NomeFantasia);
            Map(x => x.RazaoSocial);
            Map(x => x.Login);
            Map(x => x.Email);
            Map(x => x.Senha);
            Map(x => x.ExpiracaoSenha);
            Map(x => x.CNPJ);
            Map(x => x.NomeContato);
            Map(x => x.NumeroCelular);

            Table("dbo.Estabelecimento");
        }
    }
}
