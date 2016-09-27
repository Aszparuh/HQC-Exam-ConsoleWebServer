using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

public class JsonActionResultWithCors : JsonActionResult
{
    public JsonActionResultWithCors(HttpRequest request, object model, string corsSettings)
        : base(request, model)
    {
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
    }
}
