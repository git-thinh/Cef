using CefSharp.Example;
using SimpleHttpServer;
using SimpleHttpServer.Models;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CefSharp.WinForms.Example
{
    public class ApiServer : ITcpClient
    {
        const string URL_OCR_API = "http://127.0.0.1:1502/api/ocr-cef";
        const int PORT_API = 1501;

        static List<Route> routes;
        static HttpServer httpServer;
        //static EventWaitHandle signal = new EventWaitHandle(false, EventResetMode.AutoReset);
        //static EventWaitHandle signal = new AutoResetEvent(false);

        HttpResponse ___response(HttpRequest request)
        {
            string files = string.Empty;
            string queryString = request.Url;
            if (queryString[0] == '/') queryString = queryString.Substring(1);
            if (!string.IsNullOrEmpty(queryString))
            {
                var paras = System.Web.HttpUtility.ParseQueryString(queryString);
                if (paras != null && paras.HasKeys()) {
                    files = paras.Get("files");
                    if (!string.IsNullOrEmpty(files)) {
                        HandlerCallback.requestOcr(files);
                    }
                }
            }
            return new HttpResponse()
            {
                ContentAsUTF8 = files,
                ReasonPhrase = "OK",
                StatusCode = "200"
            };
        }

        public ApiServer()
        {
            routes = new List<Route>() {
                new Route {
                    Name = "Hello Handler",
                    //UrlRegex = @"^\\/$",
                    //UrlRegex = @"^/$",
                    //UrlRegex = "^\\/$",
                    //UrlRegex = @"^/Test/Example$",
                    //UrlRegex = @"^\\/Test\\/Example\\?id=(\\d+)$",
                    //UrlRegex = "^\\/Static\\/(.*)$",
                    //UrlRegex = "^/(?=[^/]*$)",
                    UrlRegex = "/?files=(.*)",
                    Method = "GET",
                    Callable = ___response
                }, 
                //new Route {   
                //    Name = "FileSystem Static Handler",
                //    UrlRegex = @"^/Static/(.*)$",
                //    Method = "GET",
                //    Callable = new FileSystemRouteHandler() { BasePath = @"C:\Tmp", ShowDirectories=true }.Handle,
                //},
            };
            httpServer = new HttpServer(PORT_API, routes);
        }

        public void Start()
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(httpServer.Listen));
                thread.Start();
                //signal.WaitOne();
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }
         
        public IHandlerCallback HandlerCallback { get; set; }
         
        public void SendOcrResult(string data)
        {
            var cli = new System.Net.WebClient();
            cli.Headers[System.Net.HttpRequestHeader.ContentType] = "application/json";
            byte[] buf = Encoding.UTF8.GetBytes(data);
            string response = Encoding.UTF8.GetString(cli.UploadData(URL_OCR_API, buf));
            //string response = cli.UploadString(URL_OCR_API, data);

        }
    }

}
