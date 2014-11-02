using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Raven.Client;
using Raven.Client.Document;

namespace ToastmasterScheduler.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IDocumentStore DocumentStore { get; private set; }

        public MvcApplication()
        {
            BeginRequest += (s, a) =>
            {
                HttpContext.Current.Items["CurrentRequestRevanSession"] = DocumentStore.OpenSession();
            };

            EndRequest += (s, a) =>
            {
                using (var session = (IDocumentSession) HttpContext.Current.Items["CurrentRequestRavenSession"])
                {
                    if (session == null) return;
                    if (Server.GetLastError() != null) return;

                    session.SaveChanges();
                }
            };
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitializeDocumentStore();
        }

        private static void InitializeDocumentStore()
        {
            if (DocumentStore != null) return;

            DocumentStore = new DocumentStore()
            {
                ConnectionStringName = "RavenDB"
            }.Initialize();
        }
    }
}
