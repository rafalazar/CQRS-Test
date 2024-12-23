namespace Api.Models;

public class ResponseModel
{
    public string Version { get; set; }
    public string Severity { get; set; }
    public string HttpStatus { get; set; }
    public string Status { get; set; }
    public string Code { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
}