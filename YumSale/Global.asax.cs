using System.Data.Entity;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using YumSale.Migrations;
using YumSale.Models;

namespace YumSale
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            // Manually installed WebAPI 2.2 after making an MVC project.
            GlobalConfiguration.Configure(WebApiConfig.Register); // NEW way


            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders[typeof (IPrincipal)] = new PrincipalModelBinder();
            Bootstrapper.Initialise();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            new ApplicationDbContext().Database.Initialize(false);

        }
    }
}