
namespace TechnoSolution.Entidades
{
    public class Usuario
    {
        public virtual int Id { get; set; }
        public virtual string Login { get; set; }
        public virtual string Senha { get; set; }
        public virtual string Nome { get; set; }
        public virtual long Telefone { get; set; }
        public virtual bool Visibilidade{ get; set; }
    }
}