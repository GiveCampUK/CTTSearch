using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                tags = result.Tags.Tagify(),
                parentId = result.Parent == null ? 0 : result.Parent.Id,
                searchResultLinks = result.SearchResultLinks == null ? null :
                    result.SearchResultLinks
                    .Select(link => new
                    {
                        id = link.Id,
                        title = link.Title,
                        tags = link.Tags.Tagify()
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
