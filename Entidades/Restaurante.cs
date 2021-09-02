
namespace TechnoSolution.Entidades
{
    public class Restaurante
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Estado { get; set; }
        public virtual string Cidade { get; set; }
        public virtual string Rua { get; set; }
        public virtual int Numero { get; set; }
        public virtual decimal Avaliacao { get; set; }
    }
}