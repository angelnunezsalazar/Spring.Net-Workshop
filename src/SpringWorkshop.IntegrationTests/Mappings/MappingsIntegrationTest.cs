using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using SpringWorkshop.IntegrationTests.TestBases;

namespace SpringWorkshop.IntegrationTests.Mappings
{
    public class MappingsIntegrationTest : MappingTestBase
    {
        [Test]
        public void LosMappingsConcuerdanConLaBaseDeDatos()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                var allClassMetadata = session.SessionFactory.GetAllClassMetadata();
                foreach (var entry in allClassMetadata)
                {
                    session.CreateCriteria(entry.Value.GetMappedClass(EntityMode.Poco))
                        .SetMaxResults(0).List();
                }
            }
        }

        [Test, Explicit]
        public void GeneraSchemaBaseDatos()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
               new SchemaExport(FactoryObject.Configuration).Execute(false, true, false, session.Connection, null);
            }
        }
    }
}
