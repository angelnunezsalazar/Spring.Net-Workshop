using CommonServiceLocator.SpringAdapter;
using Microsoft.Practices.ServiceLocation;
using NHibernate;
using NUnit.Framework;
using Spring.Data.NHibernate;
using Spring.Testing.NUnit;

namespace SpringWorkshop.IntegrationTests.TestBases
{

    [TestFixture]
    public class RepositoryTestBase : AbstractTransactionalDbProviderSpringContextTests
    {
        public ISessionFactory SessionFactory { get; set; }

        public RepositoryTestBase()
        {
            ServiceLocator.SetLocatorProvider(() => new SpringServiceLocatorAdapter(applicationContext));
        }

        protected override string[] ConfigLocations
        {
            get
            {
                return new[] { "assembly://SpringWorkshop.CrossCutting/SpringWorkshop.CrossCutting.Ioc/Persistence.xml" };
            }
        }

        protected void FlushSession()
        {
            ISession session = SessionFactoryUtils.GetSession(SessionFactory, true);
            session.Flush();
        }
    }
}
