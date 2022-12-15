using _101_Controller.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;namespace Asp.NetCore6._0.Filters{    public class CustonExceptionFilter: ExceptionFilterAttribute    {        public override void OnException(ExceptionContext context)        {            context.ExceptionHandled = true;            var error = context.Exception.Message;            context.Result = new RedirectToActionResult("Error", "Home", new ErrorViewModel()
            {
                Errors = new List<string>() { $"{error}" }
            });        }    }}