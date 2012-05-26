using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace SpringWorkshop.Persistence.Mappings.Conventions
{
    public class HasManyConvention : IHasManyConvention
    {
        public void Apply(IOneToManyCollectionInstance instance)
        {
            instance.Key.Column(instance.EntityType.Name + "Id");
            instance.Inverse();
            instance.Access.CamelCaseField();
            instance.Cascade.AllDeleteOrphan();
        }
    }
}