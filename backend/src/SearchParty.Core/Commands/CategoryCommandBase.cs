using System.Linq;
using SearchParty.Core.Models;

namespace SearchParty.Core.Commands
{
    public class CategoryCommandBase
    {
        protected static object GenerateCategory(Category result, bool recurseOnce = false)
        {
            return new
            {
                id = result.Id,
                title = result.Title,
                blurb = result.Blurb,
                tags = result.Tags.UnwrapCommas(),
                parentId = result.Parent == null ? 0 : result.Parent.Id,
                searchResultLinks = result.SearchResultLinks == null ? null :
                    result.SearchResultLinks
                    .Select(link => new
                    {
                        id = link.Id,
                        title = link.Title,
                        tags = link.Tags.UnwrapCommas()
                    }),
                subCategories = result.SubCategories == null ? null : recurseOnce
                                    ? (object)
                                      result.SubCategories
                                          .Select(category => GenerateCategory(category))
                                    : new { }
            };
        }
    }
}
