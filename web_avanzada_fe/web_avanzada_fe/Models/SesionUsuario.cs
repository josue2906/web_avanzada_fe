using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace web_avanzada_fe.Models
{
    public class SesionUsuario : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("Token") == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"controller", "Home"},
                        {"action", "Error"}
                    }
                );
            }

            base.OnActionExecuting(context);
        }



    }
    public class ValidarAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("Token") == null || context.HttpContext.Session.GetString("Rol").ToString()!="1")
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"controller", "Home"},
                        {"action", "ErrorRol"}
                    }
                );
            }

            base.OnActionExecuting(context);
        }
    }


    public class ValidarVeterinario : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("Token") == null || context.HttpContext.Session.GetString("Rol").ToString() != "1" && 
                context.HttpContext.Session.GetString("Rol").ToString() != "2")
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"controller", "Home"},
                        {"action", "ErrorRol"}
                    }
                );
            }

            base.OnActionExecuting(context);
        }
    }


    public class ValidarAsistente : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("Token") == null || context.HttpContext.Session.GetString("Rol").ToString() != "1"
                && context.HttpContext.Session.GetString("Rol").ToString() != "3")
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"controller", "Home"},
                        {"action", "ErrorRol"}
                    }
                );
            }

            base.OnActionExecuting(context);
        }
    }

}
