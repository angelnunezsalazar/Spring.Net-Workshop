using System;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using SpringWorkshop.Domain;
using SpringWorkshop.Domain.PersistenceInterfaces;

namespace SpringWorkshop.ApplicationServices
{
    public interface IPedidoService
    {
        void EnviarPedidos(int idCliente);
        IEnumerable<Pedido> ObtenerPedidos(int idCliente);
    }

    public class PedidoService : IPedidoService
    {
        private readonly IClienteRepository clientes;

        public PedidoService(IClienteRepository clientes)
        {
            this.clientes = clientes;
        }

        [Transaction]
        public void EnviarPedidos(int idCliente)
        {
            Cliente cliente = clientes.Obtener(idCliente);
            foreach (var pedido in cliente.Pedidos)
            {
                if (!pedido.HaSidoEnviado())
                {
                    pedido.Enviar();
                }
            }
        }

        public IEnumerable<Pedido> ObtenerPedidos(int idCliente)
        {
            Cliente cliente= clientes.Obtener(idCliente);
            return cliente.Pedidos;
        }
    }
}
