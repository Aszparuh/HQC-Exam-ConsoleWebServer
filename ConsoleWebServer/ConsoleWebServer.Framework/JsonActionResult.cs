using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

public class JsonActionResult : IActionResult
{
    private readonly object model;

    public JsonActionResult(HttpRequest rq, object m)
    {
        this.model = m;
        this.Request = rq;
        this.ResponseHeaders = new List<KeyValuePair<string, string>>();
    }

    public List<KeyValuePair<string, string>> ResponseHeaders { get; private set; }

    public HttpRequest Request { get; private set; }

    public virtual HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.OK;
    }

    public string GetContent()
    {
        return JsonConvert.SerializeObject(this.model);
    }

    public HttpResponse GetResponse()
    {
        var response = new HttpResponse(this.Request.ProtocolVersion, this.GetStatusCode(), this.GetContent(), HighQualityCodeExamPointsProvider.GetContentType());
        foreach (var responseHeader in this.ResponseHeaders)
        {
            response.AddHeader(responseHeader.Key, responseHeader.Value);
        }

        return response;
    }
}
