using DocumentFormat.OpenXml.Drawing.Diagrams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Nitelik
{
    public class LogAttribute :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            antremantakipEntities1 db = new antremantakipEntities1();
            Models.Log yenilog = new Models.Log();
            yenilog.tarih = DateTime.Now;
            yenilog.ıp = filterContext.HttpContext.Request.UserHostAddress;
            yenilog.metot = filterContext.ActionDescriptor.ActionName;
            yenilog.tarayici = filterContext.HttpContext.Request.Browser.Browser;

            db.Log.Add(yenilog);
            db.SaveChanges();
            
        }
    }
}