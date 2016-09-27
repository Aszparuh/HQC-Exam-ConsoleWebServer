using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace ConsoleWebServer.Framework
{
    public class JsonActionResult : IActionResult
    {
        private readonly object model;

        public JsonActionResult(HttpRequest request, object model)
        {
            this.model = model;
            this.Request = request;
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
}
