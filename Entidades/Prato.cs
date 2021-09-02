
using System.Collections.Generic;

namespace TechnoSolution.Entidades
{
    public class Prato
    {
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual string Descricao { get; set; }

        public virtual decimal Avaliacao { get; set; }

        public virtual int QuantidadePedidos { get; set; }

        public virtual IList<Pedido> Pedidos { get; set; }

        public virtual decimal Preco { get; set; }

        public virtual Restaurante Restaurante { get; set; }
    }
}