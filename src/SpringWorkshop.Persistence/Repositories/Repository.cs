using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;
using NHibernate;
using SpringWorkshop.Domain.PersistenceInterfaces;

namespace SpringWorkshop.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> 
    {
        private ISessionFactory SessionFactory
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ISessionFactory>();
            }
        }

        protected ISession Session
        {
            get { return SessionFactory.GetCurrentSession(); }
        }

        public IList<T> ObtenerTodos()
        {
            ICriteria criteria = Session.CreateCriteria(typeof (T));
            return criteria.List<T>();
        }

        public T Obtener(int id)
        {
            return Session.Get<T>(id);
        }
    }
}