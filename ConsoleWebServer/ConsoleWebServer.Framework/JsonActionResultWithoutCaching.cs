using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

public class JsonActionResultWithoutCaching : JsonActionResult
{
    public JsonActionResultWithoutCaching(HttpRequest r, object model)
        : base(r, model)
    {
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
        throw new Exception();
    }
}
