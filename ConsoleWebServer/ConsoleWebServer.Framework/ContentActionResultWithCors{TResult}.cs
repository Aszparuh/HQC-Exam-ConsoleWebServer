using System.Collections.Generic;
using System.Net;
using System.Text;

public class ContentActionResultWithCors<TResult> : ContentActionResult
{
    public ContentActionResultWithCors(HttpRequest request, object model, string corsSettings)
        : base(request, model)
    {
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
    }
}
