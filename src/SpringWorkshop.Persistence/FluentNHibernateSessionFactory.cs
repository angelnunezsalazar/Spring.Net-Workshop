using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using NHibernate.Cfg;
using Spring.Data.NHibernate;
using SpringWorkshop.Domain;
using SpringWorkshop.Domain.Bases;
using SpringWorkshop.Persistence.Mappings.Conventions;

namespace SpringWorkshop.Persistence
{
    public class FluentNHibernateSessionFactory : LocalSessionFactoryObject
    {

        protected override void PostProcessConfiguration(Configuration configuration)
        {
            base.PostProcessConfiguration(configuration);
            var mapModel = AutoMap.AssemblyOf<Cliente>()
                           .IgnoreBase<Entity>()
                           .Where(t => t.Namespace == typeof(Cliente).Namespace)
                           .Conventions.AddFromAssemblyOf<PrimaryKeyConvention>();

            Fluently.Configure(configuration)
            .Mappings(m => m.AutoMappings.Add(mapModel))
            .BuildConfiguration();
        }
    }
}