using NUnit.Framework;
using Spring.Data.NHibernate;
using SpringWorkshop.Domain;
using SpringWorkshop.Domain.PersistenceInterfaces;
using SpringWorkshop.IntegrationTests.TestBases;
using System.Linq;
using System;

namespace SpringWorkshop.IntegrationTests.Repositories
{
    public class ClienteRepository:RepositoryTestBase
    {
        public IClienteRepository Clientes { get; set; }

        [Test]
        public void GuardaUnClienteYSusOrdenes()
        {
            Pedido pedido = NuevoPedido();
            Cliente nuevoCliente = NuevoCliente(pedido);

            Clientes.Agregar(nuevoCliente);
            FlushSession();
            Cliente cliente = Clientes.Obtener(nuevoCliente.Id);

            Assert.AreEqual(cliente, nuevoCliente);
            Assert.AreEqual(cliente.Pedidos.First(), pedido);
        }

        private Pedido NuevoPedido()
        {
            return new Pedido {DireccionEnvio = "Calle Santa Paula", FechaPedido = DateTime.Today};
        }

        private Cliente NuevoCliente(Pedido pedido)
        {
            Cliente nuevoCliente=new Cliente {Nombre = "Luis Alberto"};
            nuevoCliente.RegistrarPedido(pedido);
            return nuevoCliente;
        }
    }
}
