// Copyright © 2019 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Text;
using CefSharp.Example.Filters;
using CefSharp.Handler;

namespace CefSharp.Example.Handlers
{
    public class TestResourceRequestHandler_GooVisionApi : ResourceRequestHandler
    {

        protected override CefReturnValue OnBeforeResourceLoad(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
        {
            ////Uri url;
            ////if (Uri.TryCreate(request.Url, UriKind.Absolute, out url) == false)
            ////{
            ////    //If we're unable to parse the Uri then cancel the request
            ////    // avoid throwing any exceptions here as we're being called by unmanaged code
            ////    return CefReturnValue.Cancel;
            ////}

            //////Example of how to set Referer
            ////// Same should work when setting any header

            ////// For this example only set Referer when using our custom scheme
            ////if (url.Scheme == CefSharpSchemeHandlerFactory.SchemeName)
            ////{
            ////    //Referrer is now set using it's own method (was previously set in headers before)
            ////    request.SetReferrer("http://google.com", ReferrerPolicy.Default);
            ////}

            //Example of setting User-Agent in every request.
            //var headers = request.Headers;

            //var userAgent = headers["User-Agent"];
            //headers["User-Agent"] = userAgent + " CefSharp";

            //request.Headers = headers;

            //NOTE: If you do not wish to implement this method returning false is the default behaviour
            // We also suggest you explicitly Dispose of the callback as it wraps an unmanaged resource.
            //callback.Dispose();
            //return false;

            //NOTE: When executing the callback in an async fashion need to check to see if it's disposed
            if (!callback.IsDisposed)
            {
                using (callback)
                {
                    //////if (request.Method == "POST")
                    //////{
                    //////    using (var postData = request.PostData)
                    //////    {
                    //////        if (postData != null)
                    //////        {
                    //////            var elements = postData.Elements;

                    //////            var charSet = request.GetCharSet();

                    //////            foreach (var element in elements)
                    //////            {
                    //////                if (element.Type == PostDataElementType.Bytes)
                    //////                {
                    //////                    var body = element.GetBody(charSet);
                    //////                }
                    //////            }
                    //////        }
                    //////    }
                    //////}

                    //Note to Redirect simply set the request Url
                    //if (request.Url.StartsWith("https://www.google.com", StringComparison.OrdinalIgnoreCase))
                    //{
                    //    request.Url = "https://github.com/";
                    //}

                    if (request.Url.StartsWith("https://www.gstatic.com/cloud-site-ux/vision/vision.min.js", StringComparison.OrdinalIgnoreCase))
                    {
                        request.Url = "http://localhost:1502/vision.min.js";
                    }

                    //if (request.Url.StartsWith("https://fonts.googleapis.com/css?family=Roboto+Mono:400,700", StringComparison.OrdinalIgnoreCase))
                    //{
                    //    request.Url = "http://localhost:1502/a.css";
                    //}


                    /*
                        * Called on the IO thread before a resource is loaded. To allow the resource to load normally return false.
                        * To redirect the resource to a new url populate the |redirectUrl| value and return false.
                        * To specify data for the resource return a CefStream object in |resourceStream|, use the |response| object to set mime type,
                        * HTTP status code and optional header values, and return false. To cancel loading of the resource return true.
                        * Any modifications to |request| will be observed. If the URL in |request| is changed and |redirectUrl| is also set,
                        * the URL in |request| will be used.
                    */


                    //////if (request.Url.StartsWith("https://fonts.googleapis.com/css?family=Roboto+Mono:400,700", StringComparison.OrdinalIgnoreCase))
                    //////{
                    //////    using (HttpClient client = new HttpClient())
                    //////    using (HttpResponseMessage response = client.GetAsync("http://localhost:1502/a.css").Result)
                    //////    using (HttpContent content = response.Content)
                    //////    {
                    //////        // ... Read the response to see if we have the redirected url
                    //////        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    //////        {
                    //////            //HttpResponseHeaders headers = response.Headers;
                    //////            //if (headers != null && headers.Location != null)
                    //////            //{
                    //////            //    redirectedUrl = headers.Location.AbsoluteUri;
                    //////            //}


                    //////            //TODO: Copy to separate memory stream so we can dispose of parent HttpResponseMessage
                    //////            var responseContent = response.Content.ReadAsStreamAsync().Result;

                    //////            var responseHeaders = response.Headers.ToDictionary(x => x.Key, x => x.Value.First());

                    //////            var responseMime = response.IsSuccessStatusCode
                    //////                ? response.Content.Headers.ContentType.MediaType
                    //////                : "text/css"; //CEFSharp demands a MimeType of some kind...

                    //////            requestResponse.RespondWith(responseContent, responseMime, String.Empty, (int)response.StatusCode, responseHeaders);

                    //////        }
                    //////    }
                    //////}


                    //Callback in async fashion
                    //callback.Continue(true);
                    //return CefReturnValue.ContinueAsync;
                }
            }

            return CefReturnValue.Continue;
        }

        protected override void OnResourceRedirect(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response, ref string newUrl)
        {
            //Example of how to redirect - need to check `newUrl` in the second pass
            //if (request.Url.StartsWith("https://www.google.com", StringComparison.OrdinalIgnoreCase) && !newUrl.Contains("github"))
            //{
            //    newUrl = "https://github.com";
            //}
        }

        readonly string m_strUrlMain = string.Empty;
        readonly IHandlerCallback _handlerCallback;
        public TestResourceRequestHandler_GooVisionApi(string strUrlMain, IHandlerCallback handlerCallback = null) : base()
        {
            _handlerCallback = handlerCallback;
            m_strUrlMain = strUrlMain;
        }

        MemoryStream memoryStream;
        string m_strContentType = string.Empty;

        protected override bool OnResourceResponse(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            //NOTE: You cannot modify the response, only the request. You can now access the headers
            var headers = response.Headers;

            m_strContentType = headers.Get("Content-Type");
            if (string.IsNullOrWhiteSpace(m_strContentType)) m_strContentType = string.Empty;
            m_strContentType = m_strContentType.Split(';')[0].Trim().ToLower();
            return false;
        }
         
        protected override IResponseFilter GetResourceResponseFilter(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            //string URL_JS_HOOK_OCR;
            var url = request.Url.Split('?')[0];
            switch (url)
            {
                case "https://cloud.google.com/vision/docs/drag-and-drop":
                    //URL_JS_HOOK_OCR = ConfigurationManager.AppSettings["URL_JS_HOOK_OCR"];
                    //if (!string.IsNullOrEmpty(URL_JS_HOOK_OCR))
                    //{
                    //    return new AppendResponseFilter(System.Environment.NewLine + "<script src=\"" + URL_JS_HOOK_OCR + "\"></script>");
                    //}
                    //break;
                case "https://www.google.com/recaptcha/api2/payload":
                    // response captcha image 
                    if (_handlerCallback != null && _handlerCallback.StepId == 2)
                        _handlerCallback.captcha_visbleChooseImage();
                    break; 
                case "https://www.google.com/recaptcha/api2/userverify":
                    // response token info
                    break; 
                default: 
                    memoryStream = new MemoryStream();
                    return new StreamResponseFilter(memoryStream); 
            }

            return null;
        }
         
        protected override void OnResourceLoadComplete(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response, UrlRequestStatus status, long receivedContentLength)
        {
            var url = request.Url.Split('?')[0];
            if (memoryStream != null)
            {
                byte[] data = null;
                int len = 0;
                string text = string.Empty;
                 
                switch (url)
                {
                    //case "https://cloud.google.com/vision/docs/drag-and-drop":
                    //    break;
                    //case "https://www.google.com/recaptcha/api2/webworker.js":
                    //    break;
                    //case "https://www.google.com/recaptcha/api2/payload":
                    //    // response captcha image 
                    //    if (_handlerCallback != null)
                    //        _handlerCallback.captchaVisbleChooseImage();
                    //    break;
                    case "https://www.google.com/recaptcha/api2/userverify":
                        // response token info
                        data = memoryStream.ToArray();
                        len = data.Length;
                        text = Encoding.UTF8.GetString(data);

                        if (_handlerCallback != null)
                            _handlerCallback.response_tokenInfo(text);

                        break;
                    case "https://www.gstatic.com/recaptcha/releases/eQmzkx3d5dtuXlLOA4pEID3I/recaptcha__en.js": 
                        if (request.ReferrerUrl != null && request.ReferrerUrl.Contains("https://www.google.com/recaptcha/api2/webworker.js"))
                        {
                            if (_handlerCallback != null)
                                _handlerCallback.captcha_visbleCheckNotBeRobot();
                        } 
                        break;
                    case "https://cxl-services.appspot.com/proxy":
                        #region
                        data = memoryStream.ToArray();
                        len = data.Length;
                        text = Encoding.UTF8.GetString(data);

                        MemoryCache.Default.Set("URL", request.Url, new CacheItemPolicy());
                        MemoryCache.Default.Set("HEADERS", request.Headers, new CacheItemPolicy());
                        MemoryCache.Default.Set("POST_DATA", request.PostData.Elements[0].Bytes, new CacheItemPolicy());

                        browser.StopLoad();

                        if (_handlerCallback != null)
                            _handlerCallback.response_calbackSuccess(request.Url, Encoding.UTF8.GetString(request.PostData.Elements[0].Bytes), text);


                        #endregion
                        break;
                }
            }
        } 
    }

    public class GOO_VISION_API_RES_TEXT
    {
        public string description { get; set; }
    }

    public class GOO_VISION_API_RES
    {
        public GOO_VISION_API_RES_TEXT[] textAnnotations { get; set; }
    }

    public class GOO_VISION_API
    {
        public GOO_VISION_API_RES[] responses { get; set; }
    }

    public class GOO_VISION_API_RET
    {
        public GOO_VISION_API_RET_ITEM[] requests { get; set; }
        public GOO_VISION_API_RET(string image_base64)
        {
            requests = new GOO_VISION_API_RET_ITEM[] { new GOO_VISION_API_RET_ITEM(image_base64) { } };
        }
    }

    public class GOO_VISION_API_RET_ITEM
    {
        public GOO_VISION_API_RET_ITEM_IMAGE image { get; set; }
        public GOO_VISION_API_RET_ITEM_FEATURE[] features { get; set; }
        public GOO_VISION_API_RET_ITEM_imageContext imageContext { get; set; }

        public GOO_VISION_API_RET_ITEM(string image_base64)
        {
            this.image = new GOO_VISION_API_RET_ITEM_IMAGE() { content = image_base64 };
            this.features = new GOO_VISION_API_RET_ITEM_FEATURE[] { new GOO_VISION_API_RET_ITEM_FEATURE() { } };
            this.imageContext = new GOO_VISION_API_RET_ITEM_imageContext();
        }
    }

    public class GOO_VISION_API_RET_ITEM_imageContext
    {
        public GOO_VISION_API_RET_ITEM_imageContext_cropHintsParams cropHintsParams { get; set; }
        public GOO_VISION_API_RET_ITEM_imageContext()
        {
            this.cropHintsParams = new GOO_VISION_API_RET_ITEM_imageContext_cropHintsParams();
        }
    }

    public class GOO_VISION_API_RET_ITEM_imageContext_cropHintsParams
    {
        public float[] aspectRatios { get; set; }
        public GOO_VISION_API_RET_ITEM_imageContext_cropHintsParams()
        {
            this.aspectRatios = new float[] { 0.8f, 1.0f, 1.2f };
        }
    }

    public class GOO_VISION_API_RET_ITEM_IMAGE
    {
        public string content { get; set; }
        public GOO_VISION_API_RET_ITEM_IMAGE()
        {
            content = "";
        }
    }

    public class GOO_VISION_API_RET_ITEM_FEATURE
    {
        public string type { get; set; }
        public int maxResults { get; set; }

        public GOO_VISION_API_RET_ITEM_FEATURE()
        {
            this.maxResults = 50;
            this.type = "DOCUMENT_TEXT_DETECTION";
        }
    }
}
