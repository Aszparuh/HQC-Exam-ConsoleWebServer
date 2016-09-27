using System.Collections.Generic;
using System.Net;
using System.Text;

public class ContentActionResult : IActionResult
{
    private readonly object model;

    public ContentActionResult(HttpRequest request, object model)
    {
        this.model = model;
        this.Request = request;
            this
            .
            ResponseHeaders
            =
            new
            List
            <
            KeyValuePair
            <
            string,
            string
            >
            >()
            ;
    }

    public List<KeyValuePair<string, string>> ResponseHeaders { get; private set; }

    public HttpRequest Request { get; private set; }

    public HttpResponse GetResponse()
    {
        var response = new HttpResponse(this.Request.ProtocolVersion, HttpStatusCode.OK, this.model.ToString(), "text/plain; charset=utf-8");
        foreach (var responseHeader in this.ResponseHeaders)
        {
            response.AddHeader(responseHeader.Key, responseHeader.Value);
        }

        return response;
    }
}
