// Copyright © 2019 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using CefSharp.Example.Filters;
using CefSharp.Handler;

namespace CefSharp.Example.Handlers
{
    public class TestResourceRequestHandler_GooVisionApi : ResourceRequestHandler
    {
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
            var url = request.Url.Split('?')[0];
            if (memoryStream != null)
            {
                byte[] data = null;
                int len = 0;
                string text = string.Empty;

                switch (url)
                {
                    case "https://cxl-services.appspot.com/proxy":
                        data = memoryStream.ToArray();
                        len = data.Length;
                        text = Encoding.UTF8.GetString(data);

                        MemoryCache.Default.Set("URL", request.Url, new CacheItemPolicy());
                        MemoryCache.Default.Set("HEADERS", request.Headers, new CacheItemPolicy());
                        MemoryCache.Default.Set("POST_DATA", request.PostData.Elements[0].Bytes, new CacheItemPolicy());

                        browser.StopLoad();

                        if (_handlerCallback != null) _handlerCallback.responseCalback(request.Url, Encoding.UTF8.GetString(request.PostData.Elements[0].Bytes), text);

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
        public GOO_VISION_API_RET(string image_base64) {
            requests = new GOO_VISION_API_RET_ITEM[] { new GOO_VISION_API_RET_ITEM(image_base64) { } };
        }
    }

    public class GOO_VISION_API_RET_ITEM
    {
        public GOO_VISION_API_RET_ITEM_IMAGE image { get; set; }
        public GOO_VISION_API_RET_ITEM_FEATURE[] features { get; set; }
        public GOO_VISION_API_RET_ITEM_imageContext imageContext { get; set; }

        public GOO_VISION_API_RET_ITEM(string image_base64) {
            this.image = new GOO_VISION_API_RET_ITEM_IMAGE() { content = image_base64 };
            this.features = new GOO_VISION_API_RET_ITEM_FEATURE[] { new GOO_VISION_API_RET_ITEM_FEATURE() { } };
            this.imageContext = new GOO_VISION_API_RET_ITEM_imageContext();
        }
    }

    public class GOO_VISION_API_RET_ITEM_imageContext
    {
        public GOO_VISION_API_RET_ITEM_imageContext_cropHintsParams cropHintsParams { get; set; }
        public GOO_VISION_API_RET_ITEM_imageContext() {
            this.cropHintsParams = new GOO_VISION_API_RET_ITEM_imageContext_cropHintsParams();
        }
    }

    public class GOO_VISION_API_RET_ITEM_imageContext_cropHintsParams
    {
        public float[] aspectRatios { get; set; }
        public GOO_VISION_API_RET_ITEM_imageContext_cropHintsParams() {
            this.aspectRatios = new float[] { 0.8f, 1.0f, 1.2f };
        }
    }

    public class GOO_VISION_API_RET_ITEM_IMAGE
    {
        public string content { get; set; }
        public GOO_VISION_API_RET_ITEM_IMAGE() {
            content = "";
        }
    }

    public class GOO_VISION_API_RET_ITEM_FEATURE
    {
        public string type { get; set; }
        public int maxResults { get; set; }

        public GOO_VISION_API_RET_ITEM_FEATURE() {
            this.maxResults = 50;
            this.type = "DOCUMENT_TEXT_DETECTION";
        }
    }
}
