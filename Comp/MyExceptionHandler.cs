using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_all.Comp
{
    public class MyExceptionHandle : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext error) {

            Exception ex = error.Exception;
            error.ExceptionHandled = true;
            


          var res  = new ViewResult() { ViewName = "Error" };
            res.TempData["error"] = ex.Message;
            error.Result = res;



        }

    }
}