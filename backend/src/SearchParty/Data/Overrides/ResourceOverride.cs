using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using SearchParty.Core.Models;

namespace SearchParty.Api.Data.Overrides
{
    public class ResourceOverride : IAutoMappingOverride<Resource>
    {
        public void Override(AutoMapping<Resource> mapping)
        {
            mapping
                .Map(q => q.LongDescription)
                .CustomType(typeof(string))
                .Length(10000)
                .Column("LongDescription");
            mapping
                .Map(q => q.ShortDescription)
                .CustomType(typeof(string))
                .Length(10000)
                .Column("ShortDescription");     
            mapping
                .Map(q => q.Tags)
                .CustomType(typeof(string))
                .Length(10000)
                .Column("Tags");
            mapping
                .Map(q => q.Title)
                .CustomType(typeof(string))
                .Length(10000)
                .Column("Title");
            mapping
                .Map(q => q.Uri)
                .CustomType(typeof(string))
                .Length(10000)
                .Column("Uri");
        }
    }
}
