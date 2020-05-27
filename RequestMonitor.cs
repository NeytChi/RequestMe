using System.IO;
using Microsoft.AspNetCore.Http;

namespace RequestMe
{
    public class RequestMonitor
    {
        public string HandleRequest(HttpContext context)
        {
            string view = "Request: " +
                          "\r\n\tMethod: " + context.Request.Method +
                          "\r\n\tQueryString: " + context.Request.QueryString +
                          "\r\n\tPath: " + context.Request.Path +
                          "\r\n\tProtocol: " + context.Request.Protocol +
                          "\r\n\tContentLength: " + context.Request.ContentLength +
                          "\r\n\tIP: " + context.Connection.RemoteIpAddress +
                          "\r\n";

            foreach (var (key, value) in context.Request.Headers)
                view += "\t" + key + ": " + value + "\r\n";
            
            using (var reader = new StreamReader(context.Request.Body))
            {
                var body = reader.ReadToEnd();
                view += "\tBody: " + body;
            }
            
            return view;
        }
    }
}