using System;
using SearchParty.Core.Models;
using NHibernate;
using NHibernate.Criterion;

namespace SearchParty.Core.Commands
{
    public class CategoryUpdateCommand: CategoryCommandBase
    {
        public object PerformAction(Category category, ISession dataSession)
        {
            if (category.Id == 0)
            {
                // Creating a new Category
                try
                {
                    category.Tags = category.Tags.WrapCommas();
                    dataSession.SaveOrUpdate(category);
                    return GenerateCategory(category);
                }
                catch (Exception exception)
                {
                    return new { status = "failed", exception = exception.ToString() };
                }
            }

            // Updating an existing category
            return UpdateCategory(category, dataSession);
        }

        private static object UpdateCategory(Category category, ISession dataSession)
        {
            using (var tx = dataSession.BeginTransaction())
            {
                var existingCategory = dataSession.CreateCriteria<Category>()
                    .Add(Restrictions.IdEq(category.Id)).UniqueResult<Category>();
                if (existingCategory == null)
                {
                    return new { status = "failed", message = "Category to be updated does not exist" };
                }
                existingCategory.Title = category.Title;
                existingCategory.Tags = category.Tags.WrapCommas();
                existingCategory.Blurb = category.Blurb;
                existingCategory.Parent = category.Parent;
                existingCategory.SearchResultLinks = category.SearchResultLinks;
                existingCategory.SubCategories = category.SubCategories;
                dataSession.SaveOrUpdate(existingCategory);
                tx.Commit();
            }

            return GenerateCategory(category);
        }
    }
}
