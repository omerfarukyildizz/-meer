
using Edp.Core.Features.Response;
using Newtonsoft.Json;

namespace Edp.WebApi.AzureAD.Middleware;

public sealed class ExceptionMiddleware : IMiddleware
{
	public async Task InvokeAsync(HttpContext context, RequestDelegate next)
	{
		try
		{
			await next(context);
		}
		catch (Exception ex)
		{
			await HandleExceptionAsync(context, ex);
		}
	}

	private Task HandleExceptionAsync(HttpContext context, Exception ex)
	{  
		context.Response.ContentType = "application/json";
		context.Response.StatusCode = 200;

		return context.Response.WriteAsync(new ErrorResult()
		{
			messages = ex.Message,
			status = StatusType.Error,
			data = null
		}.ToString()); ;
	}
}

public class ErrorResult
{
	public string? messages { get; set; }
    public string status { get; set; }
    public Object? data { get; set; }
    


    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);	
    }
}
