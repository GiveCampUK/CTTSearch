using System.Web.Mvc;
using NHibernate.Tool.hbm2ddl;
using SearchParty.Data;

namespace SearchParty.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult CreateDatabase()
        {
            new SchemaExport(NHibernateHelper.Configuration).Execute(false, true, false, DataSession.Connection, null);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateDatabase()
        {
            new SchemaUpdate(NHibernateHelper.Configuration).Execute(false, true);
            return RedirectToAction("Index");
        }
    }
}
