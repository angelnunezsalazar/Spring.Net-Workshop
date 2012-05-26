namespace SpringWorkshop.Domain.PersistenceInterfaces
{
    public interface IClienteRepository:IRepository<Cliente>
    {
        void Agregar(Cliente cliente);
    }
}
