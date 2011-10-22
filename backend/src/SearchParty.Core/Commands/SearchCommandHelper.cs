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

                #region Resource Spam - Solutions Anyone?

                var resource = new Resource
                                   {
                                       Tags = "Email, Spam",
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
                                   Tags = "Email, Contact, AddressBook",
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
                                   Tags = "Email, Font",
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
                                   Tags = "Payments, PCI-DSS",
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
                                   Tags = "Payments, DirectDebit",
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
                                   Tags = "Payments, Pricing",
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

                tx.Commit();
            }
        }
    }
}