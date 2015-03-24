using System;
using System.Web.Mvc;

namespace YumSale.Models
{
    public class PrincipalModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }
            if (bindingContext == null)
            {
                throw new ArgumentNullException("bindingContext");
            }
            var p = controllerContext.HttpContext.User;
            return p;
        }
    }
}