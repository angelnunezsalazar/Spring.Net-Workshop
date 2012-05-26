using System.Collections.Generic;
using SpringWorkshop.Domain.PersistenceInterfaces;
using SpringWorkshop.Domain;

namespace SpringWorkshop.ApplicationServices
{
    public interface IClienteService
    {
        IList<Cliente> ObtenerTodos();
        void Registrar(Cliente cliente);
    }

    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository clientes;

        public ClienteService(IClienteRepository clientes)
        {
            this.clientes = clientes;
        }
        
        public IList<Cliente> ObtenerTodos()
        {
            return clientes.ObtenerTodos();
        }

        public void Registrar(Cliente cliente)
        {
            clientes.Agregar(cliente);
        }
    }
}
