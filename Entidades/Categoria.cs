
namespace TechnoSolution.Dominio.Entidades
{
    public class Categoria
    {
        public virtual int Id { get; set; }

        public virtual string Descricao { get; set; }

        public virtual int Prioridade { get; set; }

        public virtual bool Ativo { get; set; }
    }
}
