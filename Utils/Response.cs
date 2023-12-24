namespace IS220_WebApplication.Utils;

public class Response
{
    private string? message { get; set; }
    private List<List<string>>? data { get; set; }
    private StatusCode? _statusCodes { get; set; }

    public Response()
    {
        message = "Ok";
        _statusCodes = StatusCode.Ok;
        data = new List<List<string>>();
    }
    public Response(string message, StatusCode statusCode)
    {
        this.message = message;
        _statusCodes = statusCode;
    }
    public Response(string message, StatusCode statusCode, List<List<string>> data)
    {
        this.message = message;
        _statusCodes = statusCode;
        this.data = data;
    }
    public List<List<string>>? GetData()
    {
        return data;
    }
    public string? GetMessage()
    {
        return message;
    }
    public StatusCode? GetStatusCode()
    {
        return _statusCodes;
    }
    public void SetMessage(string message)
    {
        this.message = message;
    }
    public void SetStatusCode(StatusCode statusCode)
    {
        _statusCodes = statusCode;
    }
}