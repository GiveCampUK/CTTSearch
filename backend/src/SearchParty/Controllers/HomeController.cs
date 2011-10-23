namespace SearchParty.Api.Controllers
{
    using System.Web.Mvc;
    using Core;
    using Core.Data;
    using NHibernate.Tool.hbm2ddl;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult CreateDatabase()
        {
            new SchemaExport(NHibernateSessionHelper.Configuration).Execute(false, true, false, DataSession.Connection, null);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateDatabase()
        {
            new SchemaUpdate(NHibernateSessionHelper.Configuration).Execute(false, true);
            return RedirectToAction("Index");
        }

        public ActionResult ResetDatabase()
        {
            DropTable("ResourceTag");
            DropTable("Tag");
            DropTable("Resource");
            DropTable("Category");
            DropTable("SearchQuery");

            new SchemaExport(NHibernateSessionHelper.Configuration).Drop(false, true);
            new SchemaExport(NHibernateSessionHelper.Configuration).Execute(false, true, false, DataSession.Connection, null);
            return RedirectToAction("Index");
        }

        private void DropTable(string tableName)
        {
            var query = DataSession.Connection.CreateCommand();
            query.CommandText =
                string.Format("IF EXISTS (SELECT 1 FROM sysobjects WHERE xtype='u' AND name='{0}') DROP TABLE {0}",
                              tableName);
            query.ExecuteNonQuery();
        }
    }
}