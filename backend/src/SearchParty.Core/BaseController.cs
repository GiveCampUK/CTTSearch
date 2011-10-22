namespace SearchParty.Core
{
    using System.Web.Mvc;
    using Data;
    using NHibernate;

    public class BaseController : Controller
    {
        private ISession _session;

        protected ISession DataSession
        {
            get { return _session ?? (_session = NHibernateSessionHelper.OpenSession()); }
        }
    }
}