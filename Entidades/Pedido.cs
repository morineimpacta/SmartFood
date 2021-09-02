
using System;
using System.Collections.Generic;

namespace TechnoSolution.Entidades
{
    public class Pedido
    {
        public virtual int Id { get; set; }
        public virtual int Pessoas { get; set; }
        public virtual int Situacao { get; set; }
        public virtual string Avaliacao { get; set; }
        public virtual string Motivo { get; set; }
        public virtual IList<Prato> Pratos { get; set; }
        public virtual DateTime DataPedido { get; set; }
        public virtual Restaurante Restaurante { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
