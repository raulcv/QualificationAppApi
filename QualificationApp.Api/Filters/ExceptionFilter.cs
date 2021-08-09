using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using QualificationApp.Domain.Base;
using QualificationApp.Domain.Interfaces.Parametro.Usuario;
using QualificationApp.Infrastructure.Repositories.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace QualificationApp.Api.Filters
{
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ExceptionLogRepository _usuarioRepository;
        public ExceptionFilter(ExceptionLogRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task OnExceptionAsync(ExceptionContext exceptionContext)
        {
            var statusCode = HttpStatusCode.InternalServerError;

            if (exceptionContext.Exception is ExceptionControlada == false)
            {
                statusCode = HttpStatusCode.InternalServerError;

                //var host = exceptionContext.RequestContext.HttpContext.Server.MachineName;
                string strHostName = string.Empty;
                strHostName = Dns.GetHostName();
                IPHostEntry ipHostEntry = Dns.GetHostEntry(strHostName);
                IPAddress[] address = ipHostEntry.AddressList;
                var hostNmae = strHostName;
                var LocalIpAdress = address[3].ToString();
                //var uri = exceptionContext.RequestContext.HttpContext.Request.Url.ToString();
                var host = exceptionContext.HttpContext.Request.Host.ToString();
                var pathBase = exceptionContext.HttpContext.Request.Path;
                var stackTrace = exceptionContext.Exception.StackTrace;
                var message = exceptionContext.Exception.Message.ToString();
                var controllerName = exceptionContext.ActionDescriptor.DisplayName.ToString();
                var actionName = exceptionContext.RouteData.Values["action"].ToString();
                var lst = exceptionContext.HttpContext.User.Claims.ToList();
                string usuario = lst[0].Value;
                string uri = host + pathBase;
                //string Message = "Date :" + DateTime.Now.ToString() + ", Controller: " + controllerName + ", Action:" + actionName +
                //                 "Error Message : " + message
                //                + Environment.NewLine + "Stack Trace : " + stackTrace;
                exceptionContext.ExceptionHandled = true;

                int id = await _usuarioRepository.registrarExcepcion(strHostName, uri, message, usuario);
                //var idDeRegistro = claseBase.RegistrarExcepcion(new ExcepcionLogDto()
                //{
                //    Content = "Controller: " + controllerName + " | Action Name: " + actionName,
                //    Host = host,
                //    Uri = uri,
                //    Stack = stackTrace,
                //    Mensaje = message,
                //    Excepcion = exception
                //});

                var resultado = new RespuestaTransaction<RespuestaException> { Resultado = 0, Mensaje = $"Ha ocurrido un problema no controlado, por favor comuníquese con TI y bríndele este número para que lo ayuden : {id}", StatusCode = 500, Retorno1 = "" };
                //exceptionContext.Result = new JsonResult() { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
                exceptionContext.Result = new JsonResult(resultado);
                //return Task.CompletedTask;
                //base.OnException(exceptionContext);
            }

            //exceptionContext.HttpContext.Response.ContentType = "application/json";
            //exceptionContext.HttpContext.Response.StatusCode = (int)code;
            //exceptionContext.Result = new JsonResult(new
            //{
            //    error = new[] { context.Exception.Message },
            //    stackTrace = context.Exception.StackTrace
            //});
        }
    }
}
