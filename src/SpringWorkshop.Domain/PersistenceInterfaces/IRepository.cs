using System.Collections.Generic;

namespace SpringWorkshop.Domain.PersistenceInterfaces
{
    public interface IRepository<T>
    {
        IList<T> ObtenerTodos();
        T Obtener(int id);
    }
}