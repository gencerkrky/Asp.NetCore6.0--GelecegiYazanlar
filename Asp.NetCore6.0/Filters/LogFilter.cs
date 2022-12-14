using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Asp.NetCore6._0.Filters
{
    public class LogFilter : ActionFilterAttribute
    {

        //Action methos çalışmadan önce
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine("Action Method Çalışmadan önce");
        }

        //Action methos çalıştıktan sonra
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("Action Method Çalıştıktan sonra");
        }

        //Sonuç üretilmeden önce
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Debug.WriteLine("Action Method sonuc üretilmeden önce");
        }


        //Sonuç üretildikten sonra
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Debug.WriteLine("Action Method sonuc üretildikten sonra");
        }
    }
}
