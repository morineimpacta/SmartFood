using FluentNHibernate.Mapping;
using TechnoSolution.Entidades;

namespace TechnoSolution.NH.Mapping
{
    public class RestauranteMap: ClassMap<Restaurante>
    {
        public RestauranteMap()
        {
          Id(x => x.Id, "ID_RESTAURANTE");

            Map(x => x.Nome, "NOME_RESTAURANTE");
            Map(x => x.Estado, "ESTADO");
            Map(x => x.Cidade, "CIDADE");
            Map(x => x.Rua, "RUA");
            Map(x => x.Numero, "NUMERO");
            Map(x => x.Avaliacao, "AVALIACAO");

            Table("dbo.Restaurante");
        }
    }
}
