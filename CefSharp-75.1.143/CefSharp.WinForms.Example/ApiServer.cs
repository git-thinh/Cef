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
using System.Linq;
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

            string files = string.Empty,front_side = string.Empty,back_side = string.Empty;
            string queryString = request.Url.Split('?')[1];
            if (queryString[0] == '/') queryString = queryString.Substring(1);
            if (!string.IsNullOrEmpty(queryString))
            {
                var paras = System.Web.HttpUtility.ParseQueryString(queryString);
                if (paras != null && paras.HasKeys())
                {
                    HandlerCallback.OcrRunning = true;
                    front_side = paras.Get("front_side");
                    back_side = paras.Get("back_side");

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

            _RESULT.urls = new string[] { front_side, back_side };

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
                new Route {
                    Name = "Hook Ocr JS",
                    UrlRegex = "/vision.min.js",
                    Method = "GET",
                    Callable = (HttpRequest request) =>
                    {
                        string s = "";
                        if(File.Exists("vision.min.js")) s = File.ReadAllText("vision.min.js");
                        return new HttpResponse()
                        {
                            Headers = new Dictionary<string, string>(){
                                { "Content-Type", "application/x-javascript" }
                            },
                            ContentAsUTF8 = s,
                            ReasonPhrase = "OK",
                            StatusCode = "200"
                        };
                    }
                },
                new Route {
                    Name = "Hook Ocr JS",
                    UrlRegex = "/a.js",
                    Method = "GET",
                    Callable = (HttpRequest request) =>
                    {
                        string s = "";
                        if(File.Exists("a.js")) s = File.ReadAllText("a.js");
                        return new HttpResponse()
                        {
                            Headers = new Dictionary<string, string>(){
                                { "Content-Type", "application/x-javascript" }
                            },
                            ContentAsUTF8 = s,
                            ReasonPhrase = "OK",
                            StatusCode = "200"
                        };
                    }
                },
                new Route {
                    Name = "Hook Ocr CSS",
                    UrlRegex = "/a.css",
                    Method = "GET",
                    Callable = (HttpRequest request) =>
                    {
                        string s = "";
                        if(File.Exists("a.css")) s = File.ReadAllText("a.css");
                        return new HttpResponse()
                        {
                            Headers = new Dictionary<string, string>(){
                                { "Content-Type", "text/css" }
                            },
                            ContentAsUTF8 = s,
                            ReasonPhrase = "OK",
                            StatusCode = "200"
                        };
                    }
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

        public void Stop() {
            httpServer.Stop();
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

    public enum OCR_DATA_TYPE
    {
        NONE,
        DATE_TIME_BIRTHDAY,
        DATE_TIME_EXPIRY
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

        public string signal_description = "N/A";
        public string date_active = "N/A";

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

        string ___remove_startWith(string s, string startWith_ = ".")
        {
            while (s.StartsWith(startWith_)) s = s.Substring(startWith_.Length).Trim();
            return s.Trim();
        }

        string ___remove_endWith(string s, string startWith_ = ".")
        {
            while (s.EndsWith(startWith_)) s = s.Substring(0, s.Length - startWith_.Length).Trim();
            return s.Trim();
        }

        string[] ___extract_startWith(string t, string startWith_, 
            int numberLineOutput = 1, int numberWordOutput = -1, OCR_DATA_TYPE type = OCR_DATA_TYPE.NONE)
        {
            if (string.IsNullOrEmpty(t)) return new string[] { string.Empty, string.Empty, string.Empty };

            string v = "", err = "";
            try
            {
                int k = t.ToLower().IndexOf(startWith_);
                if (k != -1)
                {
                    k = k + startWith_.Length;
                    t = t.Substring(k, t.Length - k).Trim();
                    t = ___remove_startWith(t, ".");
                    t = ___remove_startWith(t, ":");

                    v = string.Join(" ", t.Split('\n').Where((x, i) => i < numberLineOutput)).Trim();

                    k = v.Length;
                    t = t.Substring(k, t.Length - k).Trim();
                    t = ___remove_startWith(t, ".");
                    t = ___remove_startWith(t, ":");
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }

            v = ___remove_endWith(v, ".").Trim();
            switch (type)
            {
                case OCR_DATA_TYPE.DATE_TIME_BIRTHDAY:
                case OCR_DATA_TYPE.DATE_TIME_EXPIRY:
                    //v = Regex.Replace(v, @"[^\d]", " ").Trim();
                    v = Regex.Replace(v, @"[^0-9]", " ").Trim();
                    break;
            }

            v = ___remove_endWith(v, ".").Trim();

            if (numberWordOutput > 0) 
                v = string.Join(" ", v.Split(' ').Where((x, i) => i < numberWordOutput).ToArray());

            // Replace multi space
            v = Regex.Replace(v, @"\s+", " ").Trim();

            switch (type)
            {
                case OCR_DATA_TYPE.DATE_TIME_BIRTHDAY:
                case OCR_DATA_TYPE.DATE_TIME_EXPIRY:
                    v = v.Replace(' ', '-');
                    break;
            }

            return new string[] { v, t, err };
        }

        public OCR_RESULT(bool ok_, OCR_BUF data_)
        {
            var o = this;
            o.ok = ok_;
            o.ocr_result = data_;

            string s = data_.DataFront.Trim(),  err = string.Empty;             
            string[] a;

            // id
            a = ___extract_startWith(s, "số");
            o.id = a[0];
            if (err.Length == 0) err = a[2];

            // fullname
            a = ___extract_startWith(s, "tên");
            o.fullname = a[0];
            if (err.Length == 0) err = a[2];

            // birthday
            a = ___extract_startWith(s, "ngày", 1, -1, OCR_DATA_TYPE.DATE_TIME_BIRTHDAY);
            o.birthday = a[0];
            if (err.Length == 0) err = a[2];

            // address
            a = ___extract_startWith(s, "trú", 2);
            o.address = a[0];
            if (err.Length == 0) err = a[2];

            // expiry
            a = ___extract_startWith(s, "giá trị đến", 1, -1, OCR_DATA_TYPE.DATE_TIME_BIRTHDAY);
            o.expiry = a[0];
            if (err.Length == 0) err = a[2];

            // expiry
            a = ___extract_startWith(s, "giới tính", 1, 1);
            o.gender = a[0];
            if (err.Length == 0) err = a[2];

            //---------------------

            s = data_.DataBack.Trim();

            // signal_description
            a = ___extract_startWith(s, "nhận dạng", 2, -1);
            o.signal_description = a[0];
            if (err.Length == 0) err = a[2];

            // signal_description
            a = ___extract_startWith(s, "ngày", 1, -1, OCR_DATA_TYPE.DATE_TIME_BIRTHDAY);
            o.date_active = a[0];
            if (err.Length == 0) err = a[2];


            ocr_error = err;
        }

        public string getStringJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

    public class OCR_BUF
    {
        public string[] files { set; get; }
        public string[] urls { set; get; }
        public string DataFront { set; get; }
        public string DataBack { set; get; }
    }
}
