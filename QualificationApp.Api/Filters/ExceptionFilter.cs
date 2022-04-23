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
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ExceptionLogRepository _usuarioRepository;
        public ExceptionFilter(ExceptionLogRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public override async Task OnExceptionAsync(ExceptionContext exceptionContext)
        {
            if (exceptionContext.Exception is ExceptionControlada == false)
            {
                string strHostName = string.Empty;
                strHostName = Dns.GetHostName();
                IPHostEntry ipHostEntry = Dns.GetHostEntry(strHostName);
                IPAddress[] address = ipHostEntry.AddressList;
                var hostNmae = strHostName;
                //var LocalIpAdress = address[3].ToString();
                var host = exceptionContext.HttpContext.Request.Host.ToString();
                var pathBase = exceptionContext.HttpContext.Request.Path;
                var stackTrace = exceptionContext.Exception.StackTrace;
                var message = exceptionContext.Exception.Message.ToString();
                var controllerName = exceptionContext.ActionDescriptor.DisplayName.ToString();
                var actionName = exceptionContext.RouteData.Values["action"].ToString();
                var lst = exceptionContext.HttpContext.User.Claims.ToList();
                string usuario = lst[0].Value;
                string uri = host + pathBase;

                exceptionContext.ExceptionHandled = true;

                int id = await _usuarioRepository.registrarExcepcion(strHostName, uri, message, usuario);

                var resultado = new RespuestaTransaction<RespuestaException> { Resultado = 0, Mensaje = $"Ha ocurrido un problema no controlado, por favor comuníquese con TI y bríndele este número para que lo ayuden : {id}", StatusCode = 500, Retorno1 = "" };
                exceptionContext.Result = new JsonResult(resultado);
            }


        }
    }
}
