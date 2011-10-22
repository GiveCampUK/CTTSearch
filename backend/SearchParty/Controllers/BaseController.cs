using System.Web.Mvc;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using SearchParty.Data;

namespace SearchParty.Controllers
{
    public class BaseController : Controller
    {
        private ISession _session;

        protected ISession DataSession
        {
            get
            {
                return _session ?? (_session = NHibernateHelper.OpenSession());
            }
        }

    }
}
