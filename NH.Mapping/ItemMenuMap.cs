using FluentNHibernate.Mapping;
using TechnoSolution.Entidades;

namespace TechnoSolution.NH.Mapping
{
    public class ItemMenuMap: ClassMap<ItemMenu>
    {
        public ItemMenuMap()
        {
            Id(x => x.Id);

            Map(x => x.Titulo);
            Map(x => x.Descricao);
            Map(x => x.Imagem);
            Map(x => x.LinkVideo);
            Map(x => x.QuantidadePessoas);
            Map(x => x.Calorias);
            Map(x => x.Peso);
            Map(x => x.Preco);
            Map(x => x.TempoPreparo);
            Map(x => x.Ativo);

            References<Categoria>(x => x.Categoria).Column("IdCategoria");
            References<Estabelecimento>(x => x.Estabelecimento).Column("IdEstabelecimento");

            Table("dbo.ItemMenu");
        }
    }
}
