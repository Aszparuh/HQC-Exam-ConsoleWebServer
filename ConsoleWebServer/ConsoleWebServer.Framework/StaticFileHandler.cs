using System;
using System.IO;
using System.Linq;
using System.Net;

namespace ConsoleWebServer.Framework
{
    public class StaticFileHandler
    {
        public bool CanHandle(HttpRequest request)
        {
            var lastIndexOfDot = request.Uri.LastIndexOf(".", StringComparison.Ordinal);
            var lastIndexOfForwardSlash = request.Uri.LastIndexOf("/", StringComparison.Ordinal);
            var result = lastIndexOfDot > lastIndexOfForwardSlash;

            return result;
        }

        public HttpResponse Handle(HttpRequest request)
        {
            string filePath = Environment.CurrentDirectory + "/" + request.Uri;
            if (!this.FileExists("C:\\", filePath, 3))
            {
                return new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotFound, "File not found");
            }

            string fileContents = File.ReadAllText(filePath);
            var response = new HttpResponse(request.ProtocolVersion, HttpStatusCode.OK, fileContents);
            return response;
        }

        private bool FileExists(string path, string filePath, int depth)
        {
            if (depth <= 0)
            {
                return File.Exists(filePath);
            }

            try
            {
                var file = Directory.GetFiles(path);
                if (file.Contains(filePath))
                {
                    return true;
                }

                var directories = Directory.GetDirectories(path);
                foreach (var directory in directories)
                {
                    if (this.FileExists(directory, filePath, depth - 1))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
