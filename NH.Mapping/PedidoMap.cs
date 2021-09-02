using FluentNHibernate.Mapping;
using TechnoSolution.Entidades;

namespace TechnoSolution.NH.Mapping
{
    public class PedidoMap : ClassMap<Pedido>
    {
        public PedidoMap()
        {
            Id(x => x.Id, "ID_PEDIDO");

            Map(x => x.Pessoas, "ID_PESSOAS");
            Map(x => x.Situacao, "ID_SITUACAO");
            Map(x => x.Avaliacao, "AVALIACAO");
            Map(x => x.DataPedido, "DATA_PEDIDO");

            HasManyToMany(x => x.Pratos)
                .Table("dbo.PRATO_PEDIDO")
                .ParentKeyColumn("ID_PEDIDO")
                .ChildKeyColumn("ID_PRATO")
                .LazyLoad()
                .Cascade.SaveUpdate();

            References(x => x.Restaurante).Column("ID_RESTAURANTE");
            References(x => x.Usuario).Column("ID_USUARIO");

            Table("dbo.Pedido");
        }
    }
}
