using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using SearchParty.Core.Models;

namespace SearchParty.Core.Data.Overrides
{
    public class CategoryOverride : IAutoMappingOverride<Category>
    {
        public void Override(AutoMapping<Category> mapping)
        {
            mapping
                .Map(q => q.Blurb)
                .CustomType(typeof(string))
                .Length(10000)
                .Column("Blurb");
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
        }
    }
}