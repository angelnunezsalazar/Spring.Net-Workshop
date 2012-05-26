using FluentNHibernate.Conventions.Instances;
using FluentNHibernate.Conventions;

namespace SpringWorkshop.Persistence.Mappings.Conventions
{
    public class PrimaryKeyConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.Column("Id");
            instance.UnsavedValue("0");
            instance.GeneratedBy.HiLo("100");
        }
    }
}