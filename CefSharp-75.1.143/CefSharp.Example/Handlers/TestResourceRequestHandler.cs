// Copyright © 2019 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CefSharp.Example.Filters;
using CefSharp.Handler;

namespace CefSharp.Example.Handlers
{
    public class TestResourceRequestHandler : ResourceRequestHandler
    {
        readonly string m_strUrlMain = string.Empty;
        public TestResourceRequestHandler(string strUrlMain) : base()
        {
            m_strUrlMain = strUrlMain;
        }

        MemoryStream memoryStream;
        string m_strContentType = string.Empty;

        protected override bool OnResourceResponse(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            //NOTE: You cannot modify the response, only the request
            // You can now access the headers
            var headers = response.Headers;

            m_strContentType = headers.Get("Content-Type");
            if (string.IsNullOrWhiteSpace(m_strContentType)) m_strContentType = string.Empty;
            m_strContentType = m_strContentType.Split(';')[0].Trim().ToLower();
            return false;
        }

        //private Dictionary<ulong, MemoryStreamResponseFilter> responseDictionary = new Dictionary<ulong, MemoryStreamResponseFilter>();
        protected override IResponseFilter GetResourceResponseFilter(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            //var dataFilter = new MemoryStreamResponseFilter();
            //responseDictionary.Add(request.Identifier, dataFilter);
            //return dataFilter;
            memoryStream = new MemoryStream();
            return new StreamResponseFilter(memoryStream);
            //return null;
        }

        protected override void OnResourceLoadComplete(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response, UrlRequestStatus status, long receivedContentLength)
        {
            var url = request.Url;
            if (memoryStream != null && url.StartsWith(m_strUrlMain))
            {
                //TODO: Do something with the data here
                var data = memoryStream.ToArray();
                //File.WriteAllBytes("c:/save/path", data); 

                int len = data.Length;
                string text = string.Empty;
                ////////NOTE: You may need to use a different encoding depending on the request

                bool isText = false;
                switch (m_strContentType)
                {
                    case "text/html":
                    case "text/css":
                    case "application/json":
                    case "application/javascript":
                    case "application/x-javascript":
                        isText = true;
                        break;
                    default:
                        if (url.ToLower().EndsWith(".js"))
                            isText = true;
                        break;
                }

                var uri = new Uri(url);
                string path = uri.AbsolutePath;
                string fileName = uri.Segments[uri.Segments.Length - 1];
                if (path == "/" || path.Length == 0) fileName = "index.html";

                string dir = uri.Host + "\\" + string.Join("\\", uri.Segments.Where((x, i) => i < uri.Segments.Length - 1));
                if (uri.Segments.Length > 1 && uri.Segments[uri.Segments.Length - 1] == "/")
                {
                    fileName = uri.Segments[uri.Segments.Length - 2];
                    dir = string.Join("\\", uri.Segments.Where((x, i) => i < uri.Segments.Length - 2));
                }

                string file = Path.Combine(dir, fileName);
                file = file.Replace("/", "\\").Replace("\\\\\\", "\\").Replace("\\\\", "\\");

                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                if (isText)
                {
                    text = Encoding.UTF8.GetString(data);
                    File.WriteAllText(file, text);
                }
                else
                {
                    File.WriteAllBytes(file, data);
                }

                using (StreamWriter w = File.AppendText("_type.txt"))
                    w.WriteLine(m_strContentType + ": \t\t\t " + url + " \t\t\t " + file);
            }
        }

    }
}
