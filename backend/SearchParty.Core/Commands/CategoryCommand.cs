using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using SearchParty.Core.Models;

namespace SearchParty.Core.Commands
{
    public class CategoryCommand
    {
        public object PerformAction(int? id, ISession dataSession)
        {
            CreateDummyDataIfEmpty(dataSession);

            if (!id.HasValue)
            {
                var results = dataSession.CreateCriteria<Category>()
                    .Add(Restrictions.IsNull("Parent")).List<Category>();
                return results.Select(category => GenerateCategory(category, true));
            }
            var result = dataSession.CreateCriteria<Category>()
                .Add(Restrictions.IdEq(id.Value)).UniqueResult<Category>();
            return GenerateCategory(result);
        }

        private void CreateDummyDataIfEmpty(ISession dataSession)
        {
            if (dataSession.CreateCriteria<Category>().List<Category>().Any()) return;
            using (var tx = dataSession.BeginTransaction())
            {
                const string tags = ",Windows7,Upgrade,";
                var resource = new Category
                {
                    Tags = tags,
                    Title = "Operating Systems",
                    Blurb = "All you need to know about Operating Systems",
                    SearchResultLinks = new List<SearchResultLink>
                                            {
                                                new SearchResultLink
                                                    {
                                                        Tags = tags,
                                                        Title = "Windows7 Upgrade"
                                                    }
                                            },
                                            
                };
                resource.SearchResultLinks.ForEach(r => dataSession.Save(r));
                dataSession.Save(resource);
                tx.Commit();
            }
        }

        private static object GenerateCategory(Category result, bool recurseOnce = false)
        {
            return new
                       {
                           id = result.Id,
                           title = result.Title,
                           blurb = result.Blurb,
                           tags = result.Tags.Tagify(),
                           parentId = result.Parent == null ? 0 : result.Parent.Id,
                           searchResultLinks = result.SearchResultLinks
                               .Select(link => new
                                                   {
                                                       id = link.Id,
                                                       title = link.Title,
                                                       tags = link.Tags.Tagify()
                                                   }),
                           subCategories = recurseOnce ? (object)
                                 result.SubCategories
                                    .Select(category => GenerateCategory(category)) : new { }
                       };
        }
    }
}