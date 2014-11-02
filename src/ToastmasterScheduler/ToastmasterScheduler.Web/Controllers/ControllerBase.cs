using System.Web.Mvc;
using Raven.Client;

namespace ToastmasterScheduler.Web.Controllers
{
    public abstract class ControllerBase : Controller
    {
        public IDocumentSession DocumentSession { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            DocumentSession = (IDocumentSession) HttpContext.Items["CurrentRequestRevanSession"];
            base.OnActionExecuting(filterContext);
        }
    }
}