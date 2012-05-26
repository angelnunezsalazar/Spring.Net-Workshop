using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace SpringWorkshop.Persistence.Mappings.Conventions
{
    public class ReferenceConvention : IReferenceConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            instance.Column(instance.Name + "Id");
        }
    }
}