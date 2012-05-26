using System;
using System.Collections.Generic;
using SpringWorkshop.Domain.Bases;

namespace SpringWorkshop.Domain
{
    public class Cliente : Entity
    {
        public virtual string Nombre { get; set; }
        public virtual string Direccion { get; set; }
        public virtual int Telefono { get; set; }

        private IList<Pedido> pedidos = new List<Pedido>();

        public virtual IEnumerable<Pedido> Pedidos
        {
            get { return pedidos; }
        }

        public virtual void RegistrarPedido(Pedido pedido)
        {
            pedido.Cliente = this;
            pedidos.Add(pedido);
        }
    }
}
