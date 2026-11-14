using System.Net;
using Domain.Models;

namespace Application.Responses;

public class ApiResponse<T>
{
    private List<Department> departments;


    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; }
    public T? Data { get; set; }

    public ApiResponse(HttpStatusCode statusCode, string message, T? data)
    {
        StatusCode = statusCode;
        Message = message;
        Data = data;
    }


}
