namespace SearchParty.Core.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using NHibernate;
    using NHibernate.Criterion;
    using NHibernate.Linq;

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
                #region Category Getting Started with IT

                var category = new Category
                                   {
                                       Title = "Getting Started with IT",
                                       Blurb =
                                           "When you're not an IT professional, where to start with IT can be a daunting question. Like all things, a bit of research never goes amiss.",
                                       Tags = "GettingStarted",
                                       SearchResultLinks = new List<SearchResultLink>
                                                               {
                                                                   new SearchResultLink
                                                                       {
                                                                           Title =
                                                                               "How do I Plan and budget for IT equipment?",
                                                                           Tags = "GettingStarted, ITEquipment"
                                                                       },
                                                                   new SearchResultLink
                                                                       {
                                                                           Title = "Choosing and using consultants",
                                                                           Tags = "GettingStarted, Consultants"
                                                                       }
                                                               },
                                       SubCategories = new List<Category>
                                                           {
                                                               new Category
                                                                   {
                                                                       Title = "Technology Planning and Strategy",
                                                                       Blurb =
                                                                           "A technology plan can sound like another piece of bureaucracy. Don't be fooled! There is no substitute for thinking through what you need and how you will meet those needs. Technology planning is the process that will help you save money on technology, buy what you need and use technology as a tool to accomplish your organisation's mission.",
                                                                       Tags = "GettingStarted, Strategy",
                                                                       SearchResultLinks = new List<SearchResultLink> {},
                                                                       SubCategories = new List<Category> {}
                                                                   }
                                                           }
                                   };
                category.SearchResultLinks.ForEach(r => dataSession.Save(r));
                category.SubCategories.ForEach(r => dataSession.Save(r));
                dataSession.Save(category);

                #endregion

                #region Category Payment Solutions

                category = new Category
                               {
                                   Title = "Payment Solutions",
                                   Blurb =
                                       "Online fundraising is now an integral part of the fundraising mix. Not-for-profit organisations wanting to maximise their income, must be able to offer the full range of payment options.",
                                   Tags = "Payments",
                                   SearchResultLinks =
                                       new List<SearchResultLink>
                                           {
                                               new SearchResultLink
                                                   {Title = "Chip & Pin Terminals", Tags = "Payments, ChipAndPin"}
                                           },
                                   SubCategories =
                                       new List<Category>
                                           {
                                               new Category
                                                   {
                                                       Title = "Direct Debit Services",
                                                       Blurb =
                                                           "Direct Debit is an essential tool for charities seeking regular gifts either online or via telephone fundraising campaigns",
                                                       Tags = "Payments, DirectDebit",
                                                       SearchResultLinks = new List<SearchResultLink> {},
                                                       SubCategories = new List<Category> {}
                                                   }
                                           }
                               };
                category.SearchResultLinks.ForEach(r => dataSession.Save(r));
                category.SubCategories.ForEach(r => dataSession.Save(r));
                dataSession.Save(category);

                #endregion

                #region Category EMail

                category = new Category
                               {
                                   Title = "Email",
                                   Blurb =
                                       "Connecting to the Internet will allow you better access to information and better communication with members and other partners through the use of email.",
                                   Tags = "Email",
                                   SearchResultLinks =
                                       new List<SearchResultLink>
                                           {
                                               new SearchResultLink
                                                   {
                                                       Title = "Choosing An Internet Service Provider",
                                                       Tags = "Email, ISP"
                                                   }
                                           },
                                   SubCategories = new List<Category>
                                                       {
                                                           new Category
                                                               {
                                                                   Title = "Using Broadband",
                                                                   Blurb =
                                                                       "As greater numbers of people connect to broadband those left without a service are increasingly struggling to keep up.  In the voluntary and community sector large numbers of people work from home and a slow internet connection can seriously hamper productivity.",
                                                                   Tags = "Email, Broadband",
                                                                   SearchResultLinks = new List<SearchResultLink> {},
                                                                   SubCategories = new List<Category> {}
                                                               },
                                                           new Category
                                                               {
                                                                   Title = "Building And Designing Email Newsletters",
                                                                   Blurb =
                                                                       "Different Email Clients (Outlook, Hotmail, Yahoo!, AOL, Gmail) display email slightly differently, and many of them are dependant on the web browser the user has chosen. So how do we build and design emails to fit across all systems?",
                                                                   Tags = "Email, Newsletters",
                                                                   SearchResultLinks = new List<SearchResultLink> {},
                                                                   SubCategories = new List<Category> {}
                                                               }
                                                       }
                               };
                category.SearchResultLinks.ForEach(r => dataSession.Save(r));
                category.SubCategories.ForEach(r => dataSession.Save(r));
                dataSession.Save(category);

                #endregion

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
                           subCategories = recurseOnce
                                               ? (object)
                                                 result.SubCategories
                                                     .Select(category => GenerateCategory(category))
                                               : new {}
                       };
        }
    }
}