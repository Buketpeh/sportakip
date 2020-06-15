using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace WebApplication4.Nitelik
{
    public class OturumKontrolAttribute:ActionFilterAttribute
    {
        [Nitelik.Log]
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var cerez = filterContext.HttpContext.Request.Cookies["Oturum"];
            if (cerez != null)

            {

                FormsAuthenticationTicket bilet = FormsAuthentication.Decrypt(cerez.Value);
                if (bilet.Expired == false)
                {
                    JavaScriptSerializer serilestir = new JavaScriptSerializer();
                    var oturumBilgi = serilestir.Deserialize<Models.OturumBilgi>(bilet.UserData);
                }
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Oturum", Action = "Giris" }));
            }
          
        }
    }
}