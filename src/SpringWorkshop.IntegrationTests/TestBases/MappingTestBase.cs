using NHibernate;
using NUnit.Framework;
using Spring.Data.NHibernate;
using Spring.Testing.NUnit;

namespace SpringWorkshop.IntegrationTests.TestBases
{

    [TestFixture]
    public class MappingTestBase : AbstractDependencyInjectionSpringContextTests
    {
        public ISessionFactory SessionFactory { get; set; }
        public LocalSessionFactoryObject FactoryObject { get; set; }

        protected override string[] ConfigLocations
        {
            get
            {
                return new[]
                    {
                        "assembly://SpringWorkshop.Bootstrapper/SpringWorkshop.Bootstrapper.Dependencies/Persistence.xml"
                    };
            }
        }
    }
}
