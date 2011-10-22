namespace SearchParty.Core.Commands
{
    using System.Linq;
    using SearchParty.Core.Models;
    using NHibernate;

    public static class SearchCommandHelper
    {
        public static void CreateDummyDataIfEmpty(ISession dataSession)
        {
            if (dataSession.CreateCriteria<Resource>().List<Resource>().Any()) return;
            using (var tx = dataSession.BeginTransaction())
            {
                //var tag1 = new Tag { Name = "Windows7" };
                //DataSession.Save(tag1);
                const string smallOrgSize = "org_size:1-5,";
                const string mediumOrgSize = "org_size:6-25,";
                const string largeOrgSize = "org_size:26plus,";
                const string proficiencyNovice = "user_prof:novice,";
                const string proficiencyIntermediate = "user_prof:intermediate,";
                const string proficiencyExpert = "user_prof:expert,";
                const string promoted = "promoted,";

                #region Resource Spam - Solutions Anyone?

                var resource = new Resource
                                   {
                                       Tags = proficiencyNovice + proficiencyIntermediate 
                                                + smallOrgSize + mediumOrgSize + largeOrgSize 
                                                + promoted
                                                + "Email, Spam",
                                       Title = "Spam - solutions anyone?",
                                       Uri = "http://www.ictknowledgebase.org.uk/spamsolutions",
                                       ShortDescription =
                                           "Spam (unsolicited bulk email) is now a real problem for many organisations. This article will help you choose a solution for your organisation.",
                                       LongDescription =
                                           "Spam (unsolicited bulk email) is now a real problem for many organisations.his article looks in more depth at how the various solutions on offer work and provides some guidance on issues to consider when choosing a solution for your organisation.",
                                       ResourceType = "ExternalLink"
                                   };
                dataSession.Save(resource);

                #endregion

                #region Resource Delete an email contact or an address book

                resource = new Resource
                               {
                                   Tags = proficiencyNovice + 
                                            mediumOrgSize + largeOrgSize + 
                                            promoted +
                                            "Email, Contact, AddressBook",
                                   Title = "Delete an email contact or an address book",
                                   Uri = "http://www.youtube.com/user/CTTCTX?blend=2&ob=5#p/c/6/juYn0TUrW90",
                                   ShortDescription =
                                       "This is a training video to help you delete a contact or addressbook in CTT Mail.",
                                   LongDescription =
                                       "This is a training video to help you delete a contact or addressbook in CTT Mail.",
                                   ResourceType = "YouTubeVideo"
                               };
                dataSession.Save(resource);

                #endregion

                #region Resource Font Colours

                resource = new Resource
                               {
                                   Tags = proficiencyNovice + 
                                                smallOrgSize + "Email, Font",
                                   Title = "Changing Font Colours in Email",
                                   Uri = "http://www.youtube.com/user/CTTCTX?blend=2&ob=5#p/c/10/ZQQloZ3rk5g",
                                   ShortDescription =
                                       "This is a training video to help you change the font colours used in CTT Mail.",
                                   LongDescription =
                                       "This is a training video to help you change the font colours used in CTT Mail.",
                                   ResourceType = "YouTubeVideo"
                               };
                dataSession.Save(resource);

                #endregion

                #region Resource PCI-DSS regulations – D day for charities

                resource = new Resource
                               {
                                   Tags = proficiencyExpert + 
                                                largeOrgSize + 
                                                promoted + 
                                                "Payments, PCI-DSS",
                                   Title = "PCI-DSS regulations – D day for charities",
                                   Uri = "http://www.ctt.org/sites/default/files/PCI_Whitepaper.pdf",
                                   ShortDescription =
                                       "Payment Card Industry – Data Security Standards (PCI-DSS) were developed to address the increased threat of card fraud around the world.",
                                   LongDescription =
                                       "Payment Card Industry – Data Security Standards (PCI-DSS) were developed to address the increased threat of card fraud around the world.",
                                   ResourceType = "PDF"
                               };
                dataSession.Save(resource);

                #endregion

                #region Resource Paperless Direct Debit (PDD) User Guide

                resource = new Resource
                               {
                                   Tags = proficiencyIntermediate + proficiencyExpert + 
                                                mediumOrgSize + largeOrgSize + "Payments, DirectDebit",
                                   Title = "Paperless Direct Debit (PDD) User Guide",
                                   Uri = "http://www.ctt.org/sites/default/files/pdd_userguide290711.pdf",
                                   ShortDescription =
                                       "A user guide for the Paperless Direct Debit (PDD) system.",
                                   LongDescription =
                                       "A user guide for the Paperless Direct Debit (PDD) system.",
                                   ResourceType = "PDF"
                               };
                dataSession.Save(resource);

                #endregion

                #region CTPayments Pricing

                resource = new Resource
                               {
                                   Tags = proficiencyIntermediate + proficiencyExpert + 
                                            mediumOrgSize + "Payments, Pricing",
                                   Title = "CTPayments Pricing",
                                   Uri = "http://www.ctt.org/ctpayments/pricing",
                                   ShortDescription =
                                       "A pricing list for the CTPayments Pricing system",
                                   LongDescription =
                                       "A pricing list for the CTPayments Pricing system",
                                   ResourceType = "InternalLink"
                               };
                dataSession.Save(resource);

                #endregion

                #region Sight Advice South Lakes - CTT case study

                resource = new Resource
                               {
                                   Tags = proficiencyNovice + proficiencyIntermediate + proficiencyExpert + 
                                            smallOrgSize + mediumOrgSize + largeOrgSize +
                                            "CaseStudy, DonatedTechnology",
                                   Title = "Sight Advice South Lakes - CTT case study",
                                   Uri = "http://www.youtube.com/watch?v=rNnKJ6naWgQ&feature=player_embedded&noredirect=1",
                                   ShortDescription =
                                       "The Sight Advice South Lakes charity has set up a technology suite, using donated software from CTT and Microsoft, aimed at providing new opportunities for their clients.",
                                   LongDescription =
                                       "Sight Advice South Lakes are a small charity supporting blind, partially sighted and vision impaired people in South Lakeland, Cumbria. The charity has set up a technology suite, using donated software from CTT and Microsoft, aimed at providing new opportunities for their clients.",
                                   ResourceType = "YouTubeVideo"
                               };
                dataSession.Save(resource);

                #endregion

                #region Why Be Concerned About Managing IT

                resource = new Resource
                               {
                                   Tags = proficiencyNovice +  
                                            smallOrgSize + mediumOrgSize + largeOrgSize +
                                            "GettingStarted, Strategy",
                                   Title = "Why Be Concerned About Managing IT",
                                   Uri = "http://www.ictknowledgebase.org.uk/whyworryaboutictmanagement",
                                   ShortDescription = "Managers increasingly face important decisions about IT. It is too important to be ignored, and this article tells you why.",
                                   LongDescription = "Managers increasingly face important decisions about IT. It is too important to be ignored, even by people who feel they don't know much about it. But why do we single out IT? Why not write about managing filing cabinets, or managing notice-boards? This article explains why IT needs your attention.",
                                   ResourceType = "ExternalLink"
                               };
                dataSession.Save(resource);

                #endregion

                #region Viruses, Spyware & Malware

                resource = new Resource
                               {
                                   Tags = proficiencyNovice +  
                                            smallOrgSize + mediumOrgSize + largeOrgSize +
                                            "GettingStarted, Virus, Malware, Spyware",
                                   Title = "Viruses, Spyware & Malware",
                                   Uri = "http://www.ictknowledgebase.org.uk/virusesspywaremalware",
                                   ShortDescription = "A collection of articles telling you about keeping nasties off your organisation's network and computers.",
                                   LongDescription = "A collection of articles telling you about keeping nasties off your organisation's network and computers.",
                                   ResourceType = "ExternalLink"
                               };
                dataSession.Save(resource);

                #endregion

                #region Infection Control

                resource = new Resource
                               {
                                   Tags = proficiencyNovice + proficiencyIntermediate +
                                            smallOrgSize + mediumOrgSize + largeOrgSize +
                                            promoted + 
                                            "Virus, Malware, Spyware",
                                   Title = "Infection Control",
                                   Uri = "http://www.ictknowledgebase.org.uk/infectioncontrol",
                                   ShortDescription = "Computer viruses plague millions around the world and email is a common way of spreading them. This article looks at the main issues.",
                                   LongDescription = "Computer viruses plague millions around the world and email is a common way of spreading them. Protecting your system effectively against email viruses depends on adopting a range of different measures. This article looks at the main issues.",
                                   ResourceType = "ExternalLink"
                               };
                dataSession.Save(resource);

                #endregion

                #region Virus Hoax Alert

                resource = new Resource
                               {
                                   Tags = proficiencyNovice + proficiencyIntermediate + proficiencyExpert + 
                                            smallOrgSize + mediumOrgSize + largeOrgSize +
                                            "Virus, Malware, Spyware",
                                   Title = "Virus Hoax Alert",
                                   Uri = "http://www.ictknowledgebase.org.uk/virushoax",
                                   ShortDescription = "Virus hoaxes can cause mayhem and confusion. They often encourage recipients to delete important system files. This article gives examples of past hoaxes and tips on how to spot hoaxes so you can avoid spreading them.",
                                   LongDescription = "Virus hoaxes can cause mayhem and confusion. They often encourage recipients to delete important system files. This article gives examples of past hoaxes and tips on how to spot hoaxes so you can avoid spreading them.",
                                   ResourceType = "ExternalLink"
                               };
                dataSession.Save(resource);

                #endregion

                #region Choosing An Antivirus Solution For Your Organisation

                resource = new Resource
                               {
                                   Tags = proficiencyNovice +  
                                            smallOrgSize + mediumOrgSize + largeOrgSize +
                                            promoted + 
                                            "GettingStarted, Virus, Malware, Spyware",
                                   Title = "Choosing An Antivirus Solution For Your Organisation",
                                   Uri = "http://www.ictknowledgebase.org.uk/choosingantivirus",
                                   ShortDescription = "Your organisation needs antivirus - that we can all agree. Don't rely on antivirus products that come with new computers. Coordinate a strategy across your organisation to benefit from time and money savings.",
                                   LongDescription = "Your organisation needs antivirus - that we can all agree. Don't rely on antivirus products that come with new computers. Coordinate a strategy across your organisation to benefit from time and money savings.",
                                   ResourceType = "ExternalLink"
                               };
                dataSession.Save(resource);

                #endregion  
              
                #region A Day In The Life Of A PDA User

                resource = new Resource
                {
                    Tags =  proficiencyIntermediate + proficiencyExpert +
                             largeOrgSize +
                             promoted +
                             "Mobile, PDA",
                    Title = "A Day In The Life Of A PDA User",
                    Uri = "http://www.ictknowledgebase.org.uk/pdadiary",
                    ShortDescription = "Whilst not in itself a true story, all of these events show how a Personal Digital Assistants (PDA) could commonly be used by an Advice Worker. For this example we are going to use an Outreach Advice Worker working for a Housing charity.",
                    LongDescription = "Whilst not in itself a true story, all of these events show how a Personal Digital Assistants (PDA) could commonly be used by an Advice Worker. For this example we are going to use an Outreach Advice Worker working for a Housing charity.",
                    ResourceType = "ExternalLink"
                };
                dataSession.Save(resource);

                #endregion  

                tx.Commit();
            }
        }
    }
}