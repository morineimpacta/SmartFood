using FluentNHibernate.Mapping;
using TechnoSolution.Entidades;

namespace TechnoSolution.NH.Mapping
{
    public class CategoriaMap: ClassMap<Categoria>
    {
        public CategoriaMap()
        {
            Id(x => x.Id);


            Map(x => x.Descricao);
            Map(x => x.Prioridade);
            Map(x => x.Ativo);

            Table("dbo.Categoria");
        }
    }
}
