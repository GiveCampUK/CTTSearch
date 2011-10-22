using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using SearchParty.Api.Models;

namespace SearchParty.Api.Data.Overrides
{
    public class ResourceOverride : IAutoMappingOverride<Resource>
    {
        public void Override(AutoMapping<Resource> mapping)
        {
            //mapping.HasManyToMany(m => m.Tags)
            //    .Table("ResourceTag");
        }
    }
}
