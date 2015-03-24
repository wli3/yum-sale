using System.Data;
using System.Data.Common;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using YumSale.Controllers;
using YumSale.Models;

namespace YumSale
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();  
            container.RegisterType<IApplicationDbContext, ApplicationDbContext>();
            return container;
        }
    }
}