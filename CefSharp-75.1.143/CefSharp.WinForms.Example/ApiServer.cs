using CefSharp.Example;
using Newtonsoft.Json;
using SimpleHttpServer;
using SimpleHttpServer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace CefSharp.WinForms.Example
{
    public class ApiServer : ITcpClient
    {
        static string root = ConfigurationManager.AppSettings["ROOT_PATH"];

        static List<Route> routes;
        static HttpServer httpServer;

        static ManualResetEvent _EVENT = new ManualResetEvent(false);
        static OCR_BUF _RESULT = null;

        string SaveImage(string imageUrl)
        {
            try
            {
                string file = Path.GetFileName(imageUrl);
                string fileName = file.Substring(0, file.Length - 4) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".jpg";

                file = Path.Combine(root, fileName);
                ImageFormat format = ImageFormat.Jpeg;

                WebClient client = new WebClient();
                Stream stream = client.OpenRead(imageUrl);
                Bitmap bitmap; bitmap = new Bitmap(stream);

                if (bitmap != null)
                {
                    bitmap.Save(file, format);
                }

                stream.Flush();
                stream.Close();
                client.Dispose();

                return fileName;
            }
            catch (Exception ex) { }

            return "";
        }

        HttpResponse ___response_ocr(HttpRequest request)
        {
            if (HandlerCallback.OcrRunning)
                return new HttpResponse(new OCR_RESULT("OCR_ENGINE is busy").getStringJson());

            if (request.Url.Contains("?") == false)
                return new HttpResponse(new OCR_RESULT("QueryString is null").getStringJson());

            string files = string.Empty;
            string queryString = request.Url.Split('?')[1];
            if (queryString[0] == '/') queryString = queryString.Substring(1);
            if (!string.IsNullOrEmpty(queryString))
            {
                var paras = System.Web.HttpUtility.ParseQueryString(queryString);
                if (paras != null && paras.HasKeys())
                {
                    HandlerCallback.OcrRunning = true;
                    var front_side = paras.Get("front_side");
                    var back_side = paras.Get("back_side");

                    var f1 = SaveImage(front_side);
                    var f2 = SaveImage(back_side);

                    if (string.IsNullOrEmpty(f1) || string.IsNullOrEmpty(f2))
                    {
                        HandlerCallback.OcrRunning = false;
                        return new HttpResponse(new OCR_RESULT("Cannot download images").getStringJson());
                    }

                    files = f1 + ";" + f2;

                    //Thread.Sleep(1000);

                    HandlerCallback.requestOcr(files);
                }
            }
            else
                return new HttpResponse(new OCR_RESULT("QueryString is null").getStringJson());

            _EVENT.WaitOne();

            return new HttpResponse(new OCR_RESULT(true, _RESULT).getStringJson());
        }
        public ApiServer(int port)
        {
            routes = new List<Route>() {
                //new Route {
                //    Name = "Ocr files",
                //    //UrlRegex = @"^\\/$",
                //    //UrlRegex = @"^/$",
                //    //UrlRegex = "^\\/$",
                //    //UrlRegex = @"^/Test/Example$",
                //    //UrlRegex = @"^\\/Test\\/Example\\?id=(\\d+)$",
                //    //UrlRegex = "^\\/Static\\/(.*)$",
                //    //UrlRegex = "^/(?=[^/]*$)",
                //    UrlRegex = "/?files=(.*)",
                //    Method = "GET",
                //    Callable = ___response
                //},
                new Route {
                    Name = "Ocr", 
                    //   /api/ocr?front_side=https://f88.vn/test/19.jpg&back_side=https://f88.vn/test/2.jpg
                    UrlRegex = "/api/ocr",
                    Method = "GET",
                    Callable = ___response_ocr
                },
                //new Route {
                //    Name = "Stop Reload",
                //    UrlRegex = "/stop-reload",
                //    Method = "GET",
                //    Callable = (HttpRequest request) =>
                //    {
                //        HandlerCallback.OcrRunning = true;

                //        return new HttpResponse()
                //        {
                //            ContentAsUTF8 = "DONE",
                //            ReasonPhrase = "OK",
                //            StatusCode = "200"
                //        };
                //    }
                //}, 
                //new Route {   
                //    Name = "FileSystem Static Handler",
                //    UrlRegex = @"^/Static/(.*)$",
                //    Method = "GET",
                //    Callable = new FileSystemRouteHandler() { BasePath = @"C:\Tmp", ShowDirectories=true }.Handle,
                //},
            };

            httpServer = new HttpServer(port, routes);
        }

        public void Start()
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(httpServer.Listen));
                thread.Start();
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }

        public IHandlerCallback HandlerCallback { get; set; }

        public void SendOcrResult(string data)
        {
            ////var cli = new System.Net.WebClient();
            ////cli.Headers[System.Net.HttpRequestHeader.ContentType] = "application/json";
            ////byte[] buf = Encoding.UTF8.GetBytes(data);
            ////string response = Encoding.UTF8.GetString(cli.UploadData(URL_OCR_API, buf));
            //////string response = cli.UploadString(URL_OCR_API, data);
            _RESULT = JsonConvert.DeserializeObject<OCR_BUF>(data);
            _EVENT.Set();
            _EVENT.Reset();
        }
    }

    public class OCR_RESULT
    {
        public string address = "N/A";
        public string id = "N/A";
        public string fullname = "N/A";
        public string birthday = "N/A";
        public string expiry = "N/A";
        public string gender = "N/A";
        public string ethnicity = "N/A";
        public string issue_by = "N/A";
        public string issue_date = "N/A";
        public string religion = "N/A";
        public int status_code = 2;
        public string status = "success";

        public bool ok = false;
        public OCR_BUF ocr_result = null;
        public string ocr_error = "";

        public OCR_RESULT() { }
        public OCR_RESULT(string message_error)
        {
            ocr_error = message_error;
        }

        public OCR_RESULT(bool ok_, OCR_BUF data_)
        {
            var o = this;
            o.ok = ok_;
            o.ocr_result = data_;

            string s = data_.DataFront.Trim();

            string t = "", f = "";
            string[] a;
            t = s;

            var k = t.ToLower().IndexOf("số");
            if (k != -1)
            {
                t = t.Substring(k + 2, t.Length - k - 2).Trim();
                f = t.Split('\n')[0];
                if (f.IndexOf(':') != -1) f = f.Split(':')[1].Trim();
                while (f.StartsWith(".")) f = f.Substring(1).Trim();
                if (f[f.Length - 1] == '.') f = f.Substring(0, f.Length - 1).Trim();
                f = Regex.Replace(f, @"\s+", " ").Trim();
                o.id = f;

                f = t.Split('\n')[0];
                t = t.Substring(f.Length + 1, t.Length - f.Length - 1); 
            }


            k = t.ToLower().IndexOf("tên");
            if (k != -1)
            {
                t = t.Substring(k + 3, t.Length - k - 3).Trim();
                f = t.Split('\n')[0].Replace(":", "").Trim();
                if (f.IndexOf(':') != -1) f = f.Split(':')[1].Trim();
                while (f.StartsWith(".")) f = f.Substring(1).Trim();
                if (f[f.Length - 1] == '.') f = f.Substring(0, f.Length - 1).Trim();
                f = Regex.Replace(f, @"\s+", " ").Trim();
                o.fullname = f;

                f = t.Split('\n')[0];
                t = t.Substring(f.Length + 1, t.Length - f.Length - 1);
            }

            k = t.ToLower().IndexOf("ngày");
            if (k != -1)
            {
                t = t.Substring(k + 4, t.Length - k - 4).Trim();
                f = t.Split('\n')[0].Replace(":", "").Trim();
                if (f.IndexOf(':') != -1) f = f.Split(':')[1].Trim();
                while (f.StartsWith(".")) f = f.Substring(1).Trim();
                if (f[f.Length - 1] == '.') f = f.Substring(0, f.Length - 1).Trim(); 
                f = Regex.Replace(f, @"\s+", " ").Trim();
                o.birthday = f;

                f = t.Split('\n')[0];
                t = t.Substring(f.Length + 1, t.Length - f.Length - 1);
            }
             
            k = t.ToLower().IndexOf("trú");
            if (k != -1)
            {
                t = t.Substring(k + 3, t.Length - k - 3).Trim();
                f = t;
                if (f.IndexOf(':') != -1) f = f.Split(':')[1].Trim();
                while (f.StartsWith(".")) f = f.Substring(1).Trim();
                if (f[f.Length - 1] == '.') f = f.Substring(0, f.Length - 1).Trim();
                f = f.Replace("\n", " ").Trim();
                f = Regex.Replace(f, @"\.+", " ").Trim();
                f = Regex.Replace(f, @"\s+", " ").Trim();
                o.address = f;
            }

        }

        public string getStringJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

    public class OCR_BUF
    {
        public string[] files { set; get; }
        public string DataFront { set; get; }
        public string DataBack { set; get; }
    }
}
