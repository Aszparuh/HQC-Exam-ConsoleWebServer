using System.Collections.Generic;

namespace ConsoleWebServer.Framework
{
    public class JsonActionResultWithCors : JsonActionResult
    {
        public JsonActionResultWithCors(HttpRequest request, object model, string corsSettings)
            : base(request, model)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
        }
    }
}
