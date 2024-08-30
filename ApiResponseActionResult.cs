using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApplication2;

public class ApiResponseActionResult : IActionResult
{
    public async Task ExecuteResultAsync(ActionContext context)
    {
        var objectResult = new ObjectResult(new ApiResponse());

        await objectResult.ExecuteResultAsync(context);
    }
}

public class ApiResponseActionResult<T> : IActionResult
{
    private readonly T _data;

    public ApiResponseActionResult(T data)
    {
        _data = data;
    }
    public async Task ExecuteResultAsync(ActionContext context)
    {
        var objectResult = new ObjectResult(new ApiResponse<T>(_data));

        await objectResult.ExecuteResultAsync(context);
    }
}
public class ApiResponse
{
    public ApiResponse()
    {
        StatusCode = HttpStatusCode.OK;
        Message = "Success";
    }

    public ApiResponse(HttpStatusCode statusCode, string message = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetStatusCodeMessage(statusCode);
    }


    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; }

    protected virtual string GetStatusCodeMessage(HttpStatusCode statusCode)
    {
        switch ((int)statusCode)
        {
            case 200: return "Ok";
            case 201: return "Created";
            case 400: return "Bad Request";
            case 401: return "Unauthorized";
            case 403: return "Access Forbidden";
            case 404: return "Not Found";
            case 500: return "Internal Server Error";
            default:
                return "Ok";
        }

    }

}

public class ApiResponse<T> : ApiResponse
{
    public T Data { get; set; }

    public ApiResponse()
    {

    }

    public ApiResponse(T model)
    {
        Data = model;
    }

    public ApiResponse(HttpStatusCode statusCode, string description, T model) : base(statusCode, description)
    {
        Data = model;
    }
}