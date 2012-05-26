using System;
using SpringWorkshop.Domain.Bases;

namespace SpringWorkshop.Domain
{
    public class Pedido : Entity
    {
        public virtual DateTime FechaPedido { get; set; }
        public virtual DateTime? FechaEnvio { get; set; }
        public virtual string DireccionEnvio { get; set; }
        public virtual Cliente Cliente { get; set; }

        public virtual bool HaSidoEnviado()
        {
            return FechaEnvio.HasValue;
        }

        public virtual void Enviar()
        {
            FechaEnvio = DateTime.Now;
        }
    }
}
