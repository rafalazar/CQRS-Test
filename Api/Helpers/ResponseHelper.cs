using Api.Models;

namespace Api.Helpers;

public static class ResponseHelper
{
    public static ResponseModel Success(object data, string code = "200", string message = "Operation successful")
    {
        return new ResponseModel
        {
            Version = "1",
            Severity = "INFO",
            HttpStatus = code,
            Status = "success",
            Code = code,
            Message = message,
            Data = data
        };
    }
    
    public static ResponseModel Error(string code, string message, object data)
    {
        return new ResponseModel
        {
            Version = "1",
            Severity = "FATAL",
            HttpStatus = code,
            Status = "error",
            Code = code,
            Message = message,
            Data = data
        };
    }
}