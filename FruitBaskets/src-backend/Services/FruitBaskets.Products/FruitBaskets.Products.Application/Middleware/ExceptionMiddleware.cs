using Microsoft.AspNetCore.Http;
using System.Text.Json;


namespace FruitBaskets.Products.Application
{
    public class ExceptionMiddleware:IMiddleware
    {
        
        public ExceptionMiddleware()
        {
            
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(Exception ex) {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode =StatusCodes.Status500InternalServerError;
               var result=new Result<string>();
                result.Success = false;
                result.Message = ex.Message;
               await context.Response.WriteAsync(JsonSerializer.Serialize(result));
            }
        }
    }
}
