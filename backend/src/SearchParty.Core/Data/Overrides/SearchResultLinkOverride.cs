using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using SearchParty.Core.Models;

namespace SearchParty.Core.Data.Overrides
{
    public class SearchResultLinkOverride : IAutoMappingOverride<SearchResultLink>
    {
        public void Override(AutoMapping<SearchResultLink> mapping)
        {
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