using FluentNHibernate.Mapping;
using TechnoSolution.Entidades;

namespace TechnoSolution.NH.Mapping
{
    public class PratoMap : ClassMap<Prato>
    {
        public PratoMap()
        {
            Id(x => x.Id, "ID_PRATO");

            Map(x => x.Nome, "NOME_PRATO");
            Map(x => x.Descricao, "DESC_PRATO");
            Map(x => x.Avaliacao, "AVALIACAO");
            Map(x => x.QuantidadePedidos, "PEDIDOS");
            Map(x => x.Preco, "PRECO");

            HasManyToMany(x => x.Pedidos)
                .Table("dbo.PRATO_PEDIDO")
                .ParentKeyColumn("ID_PEDIDO")
                .ChildKeyColumn("ID_PRATO")
                .Inverse();

            References(x => x.Restaurante).Column("ID_RESTAURANTE");

            Table("dbo.Prato");
        }
    }
}
