using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ShopBack.ResponeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBack.MiddleWares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate requestDelegate)
        {
            this.next = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, 500, ex.Message, ex.StackTrace);
            }
            finally
            {
                var statusCode = context.Response.StatusCode;
                var msg = "";
                if (statusCode == 401)
                {
                    msg = "无效的Token";
                }
                else if (statusCode == 404)
                {
                    msg = "未找到服务";
                }
                else if (statusCode == 502)
                {
                    msg = "请求错误";
                }
                else if (statusCode != 200)
                {
                    msg = "未知错误";
                }
                if (!string.IsNullOrWhiteSpace(msg))
                {
                    await HandleExceptionAsync(context, statusCode, msg);
                }
            }
        }

        private Task HandleExceptionAsync(HttpContext context, int statusCode, string msg, string stackTrace = "")
        {
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new ResponeDTO<string>()
            {
                StatusCode = statusCode,
                Message = msg,
                Trace = stackTrace,
                Data = null,
                IsSuccess = false
            }
            ));
        }
    }
}
