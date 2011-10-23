namespace SearchParty.Core.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using NHibernate;
    using NHibernate.Criterion;
    using NHibernate.Linq;

    public class CategoryCommand: CategoryCommandBase
    {
        public object PerformAction(int? id, ISession dataSession)
        {
            CreateDummyDataIfEmpty(dataSession);

            if (!id.HasValue)
            {
                var results = dataSession.CreateCriteria<Category>()
                    .Add(Restrictions.IsNull("Parent")).List<Category>();
                if (!results.Any())
                {
                    return new { };
                }
                return results.Select(category => GenerateCategory(category, true));
            }
            var result = dataSession.CreateCriteria<Category>()
                .Add(Restrictions.IdEq(id.Value)).UniqueResult<Category>();
            if (result == null)
            {
                return new { };
            }
            return GenerateCategory(result);
        }

        private void CreateDummyDataIfEmpty(ISession dataSession)
        {
            if (dataSession.CreateCriteria<Category>().List<Category>().Any()) return;
            using (var tx = dataSession.BeginTransaction())
            {
                const string smallOrgSize = "org_size:1to5,";
                const string mediumOrgSize = "org_size:6to25,";
                const string largeOrgSize = "org_size:26plus,";
                const string proficiencyNovice = "user_prof:novice,";
                const string proficiencyIntermediate = "user_prof:intermediate,";
                const string proficiencyExpert = "user_prof:expert,";
                const string promoted = "promoted,";

                #region Category Getting Started with IT

                var category = new Category
                                   {
                                       Title = "Getting Started with IT",
                                       Blurb = "When you're not an IT professional, where to start with IT can be a daunting question. Like all things, a bit of research never goes amiss.",
                                       Tags = (smallOrgSize + mediumOrgSize + largeOrgSize +
                                                proficiencyNovice + 
                                                promoted +
                                                "GettingStarted").WrapCommas(),
                                       SearchResultLinks = new List<SearchResultLink>
                                                               {
                                                                   new SearchResultLink
                                                                       {
                                                                           Title = "How do I Plan and budget for IT equipment?",
                                                                           Tags = (smallOrgSize + mediumOrgSize + largeOrgSize +
                                                                                    proficiencyNovice + proficiencyIntermediate +
                                                                                    promoted + 
                                                                                    "GettingStarted,ITEquipment").WrapCommas()
                                                                       },
                                                                   new SearchResultLink
                                                                       {
                                                                           Title = "Choosing and using consultants",
                                                                           Tags = (smallOrgSize + mediumOrgSize + largeOrgSize +
                                                                                    proficiencyNovice + proficiencyIntermediate + proficiencyExpert +
                                                                                    promoted + 
                                                                                    "GettingStarted,Consultants").WrapCommas()
                                                                       },
                                                                   new SearchResultLink
                                                                       {
                                                                           Title = "Making Decisions On ICT: Roles And Responsibilities",
                                                                           Tags = (smallOrgSize + mediumOrgSize + largeOrgSize +
                                                                                    proficiencyNovice + 
                                                                                    promoted + 
                                                                                    "GettingStarted,Roles,Responsibilities").WrapCommas()
                                                                       }
                                                               },
                                       SubCategories = new List<Category>
                                                           {/*
                                                               new Category
                                                                   {
                                                                       Title = "Technology Planning and Strategy",
                                                                       Blurb = "A technology plan can sound like another piece of bureaucracy. Don't be fooled! There is no substitute for thinking through what you need and how you will meet those needs. Technology planning is the process that will help you save money on technology, buy what you need and use technology as a tool to accomplish your organisation's mission.",
                                                                       Tags = (smallOrgSize + mediumOrgSize + largeOrgSize +
                                                                                    proficiencyNovice + 
                                                                                    promoted + 
                                                                                    "GettingStarted,Strategy").WrapCommas(),
                                                                       SearchResultLinks = new List<SearchResultLink> {
                                                                                    new SearchResultLink 
                                                                                    {
                                                                                        Title = "What can IT do for me?",
                                                                                        Tags = (smallOrgSize + mediumOrgSize + largeOrgSize +
                                                                                                proficiencyNovice + 
                                                                                                promoted + 
                                                                                                "GettingStarted,Strategy,Infrastructure,Planning").WrapCommas()
                                                                                    },
                                                                                    new SearchResultLink 
                                                                                    {
                                                                                        Title = "Case Studies",
                                                                                        Tags = (smallOrgSize + mediumOrgSize + largeOrgSize +
                                                                                                proficiencyNovice + 
                                                                                                promoted + 
                                                                                                "GettingStarted,CaseStudies").WrapCommas()
                                                                                    },
                                                                                    new SearchResultLink 
                                                                                    {
                                                                                        Title = "Project Planning",
                                                                                        Tags = (smallOrgSize + mediumOrgSize + largeOrgSize +
                                                                                                proficiencyNovice + 
                                                                                                promoted + 
                                                                                                "GettingStarted,ProjectPlanning").WrapCommas()
                                                                                    }
                                                                       },
                                                                       SubCategories = new List<Category> {}
                                                                   }
                                                           */}
                                   };
                SaveChildObjects(dataSession, category);

                #endregion

                #region Category Payment Solutions

                category = new Category
                               {
                                   Title = "Payment Solutions",
                                   Blurb = "Online fundraising is now an integral part of the fundraising mix. Not-for-profit organisations wanting to maximise their income, must be able to offer the full range of payment options.",
                                   Tags = "Payments",
                                   SearchResultLinks =
                                       new List<SearchResultLink>
                                           {
                                               new SearchResultLink {Title = "Web Online Payments", Tags = smallOrgSize + mediumOrgSize + largeOrgSize +
                                                                                                            proficiencyNovice + proficiencyIntermediate +
                                                                                                            promoted + 
                                                                                                            "Payments,Online"},
                                               new SearchResultLink {Title = "Chip & Pin Terminals", Tags = smallOrgSize + mediumOrgSize + largeOrgSize +
                                                                                                            proficiencyNovice + proficiencyIntermediate + proficiencyExpert +
                                                                                                            promoted + 
                                                                                                            "Payments,ChipAndPin"},
                                               new SearchResultLink {Title = "Security of PCI-DSS Payment Card Industry Data", Tags = smallOrgSize + mediumOrgSize + largeOrgSize +
                                                                                                            proficiencyNovice + proficiencyIntermediate + proficiencyExpert +
                                                                                                            promoted + 
                                                                                                            "Payments,PCI-DSS,Security"}
                                           },
                                   SubCategories =
                                       new List<Category>
                                           {/*
                                               new Category
                                                   {
                                                       Title = "Direct Debit Services",
                                                       Blurb =
                                                           "Direct Debit is an essential tool for charities seeking regular gifts either online or via telephone fundraising campaigns",
                                                       Tags = "Payments, DirectDebit",
                                                       SearchResultLinks = new List<SearchResultLink> { new SearchResultLink {Title = "What are Online Direct Debits?", 
                                                                                                            Tags = smallOrgSize + mediumOrgSize + largeOrgSize +
                                                                                                            proficiencyNovice + 
                                                                                                            promoted + 
                                                                                                            "Payments,DirectDebit,Online"},
                                                                                                        new SearchResultLink {Title = "Direct Debit Bureau Services", 
                                                                                                            Tags = mediumOrgSize + largeOrgSize +
                                                                                                            proficiencyNovice + proficiencyIntermediate + proficiencyExpert +
                                                                                                            promoted + 
                                                                                                            "Payments,DirectDebit,Bureau"},
                                                                                                        new SearchResultLink {Title = "Direct Debit Facilities Management", 
                                                                                                            Tags = mediumOrgSize + largeOrgSize +
                                                                                                            proficiencyNovice + proficiencyIntermediate + proficiencyExpert +
                                                                                                            promoted + 
                                                                                                            "Payments,DirectDebit,Facilities"}
                                                       },
                                                       SubCategories = new List<Category> {}
                                                   }
                                           */}
                               };
                SaveChildObjects(dataSession, category);

                #endregion

                #region Category EMail

                category = new Category
                               {
                                   Title = "Email",
                                   Blurb = "Connecting to the Internet will allow you better access to information and better communication with members and other partners through the use of email.",
                                   Tags = smallOrgSize + mediumOrgSize + largeOrgSize +
                                            proficiencyNovice + 
                                            "Email",
                                   SearchResultLinks =
                                       new List<SearchResultLink>
                                           {
                                                   new SearchResultLink
                                                   {
                                                       Title = "Choosing An Internet Service Provider",
                                                       Tags =  smallOrgSize + mediumOrgSize + largeOrgSize +
                                                               proficiencyNovice + proficiencyIntermediate +
                                                               promoted + 
                                                               "Email,ISP"
                                                   },
                                                   new SearchResultLink
                                                   {
                                                       Title = "Email in the Cloud: A Google Apps Case Study",
                                                       Tags =  smallOrgSize + mediumOrgSize + largeOrgSize +
                                                               proficiencyNovice + proficiencyIntermediate + proficiencyExpert +
                                                               promoted + 
                                                               "Email,Cloud,Google,CaseStudy"
                                                   },
                                                   new SearchResultLink
                                                   {
                                                       Title = "Using Email Marketing",
                                                       Tags =  smallOrgSize + mediumOrgSize + largeOrgSize +
                                                               proficiencyNovice + proficiencyIntermediate +
                                                               promoted + 
                                                               "Email,Marketing"
                                                   }
                                           },
                                   SubCategories = new List<Category>
                                                       {/*
                                                           new Category
                                                               {
                                                                   Title = "Using Broadband",
                                                                   Blurb =
                                                                       "As greater numbers of people connect to broadband those left without a service are increasingly struggling to keep up.  In the voluntary and community sector large numbers of people work from home and a slow internet connection can seriously hamper productivity.",
                                                                   Tags = "Email,Broadband",
                                                                   SearchResultLinks = new List<SearchResultLink> {},
                                                                   SubCategories = new List<Category> {}
                                                               },
                                                           new Category
                                                               {
                                                                   Title = "Building And Designing Email Newsletters",
                                                                   Blurb =
                                                                       "Different Email Clients (Outlook, Hotmail, Yahoo!, AOL, Gmail) display email slightly differently, and many of them are dependant on the web browser the user has chosen. So how do we build and design emails to fit across all systems?",
                                                                   Tags = "Email,Newsletters",
                                                                   SearchResultLinks = new List<SearchResultLink> {},
                                                                   SubCategories = new List<Category> {}
                                                               }
                                                       */}
                               };
                SaveChildObjects(dataSession, category);

                #endregion

                tx.Commit();
            }
        }

        private static void SaveChildObjects(ISession dataSession, Category category)
        {
            category.SearchResultLinks.ForEach(r => dataSession.Save(r));
            category.SubCategories.ForEach(r =>
                                               {
                                                   r.SubCategories.ForEach(s => dataSession.Save(s));
                                                   r.SearchResultLinks.ForEach(s => dataSession.Save(s));
                                                   dataSession.Save(r);
                                               });
            dataSession.Save(category);
        }
    }
}