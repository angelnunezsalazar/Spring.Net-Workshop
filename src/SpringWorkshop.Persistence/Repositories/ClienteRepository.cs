using Spring.Transaction.Interceptor;
using SpringWorkshop.Domain;
using SpringWorkshop.Domain.PersistenceInterfaces;

namespace SpringWorkshop.Persistence.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        [Transaction]
        public void Agregar(Cliente cliente)
        {
            Session.Save(cliente);
        }
    }
}
