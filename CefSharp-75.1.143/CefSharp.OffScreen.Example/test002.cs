// Copyright © 2014 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using CefSharp.Example;
using CefSharp.Example.Handlers;

namespace CefSharp.OffScreen.Example
{
    public class test002
    {
        //private const string TestUrl = "https://www.google.com/";
        private const string TestUrl = "http://192.168.10.54:55555/";

        public static int run(string[] args)
        {
            // You need to replace this with your own call to Cef.Initialize();
            CefExample.f_initDownload(new CefSettings(), browserProcessHandler: new BrowserProcessHandler());

            MainAsync("cachePath1", 1.0);
            //Demo showing Zoom Level of 3.0
            //Using seperate request contexts allows the urls from the same domain to have independent zoom levels
            //otherwise they would be the same - default behaviour of Chromium
            //MainAsync("cachePath2", 3.0);

            // We have to wait for something, otherwise the process will exit too soon.
            Console.ReadKey();

            // Clean up Chromium objects.  You need to call this in your application otherwise
            // you will get a crash when closing.
            Cef.Shutdown();

            //Success
            return 0;
        }

        private static async void MainAsync(string cachePath, double zoomLevel)
        {
            var browserSettings = new BrowserSettings();
            //Reduce rendering speed to one frame per second so it's easier to take screen shots
            browserSettings.WindowlessFrameRate = 1;
            var requestContextSettings = new RequestContextSettings { CachePath = cachePath };

            // RequestContext can be shared between browser instances and allows for custom settings
            // e.g. CachePath
            using (var requestContext = new RequestContext(requestContextSettings))
            using (var browser = new ChromiumWebBrowser(TestUrl, browserSettings, requestContext))
            {
                browser.RequestHandler = new TestRequestHandler(TestUrl);

                if (zoomLevel > 1)
                {
                    browser.FrameLoadStart += (s, argsi) =>
                    {
                        var b = (ChromiumWebBrowser)s;
                        if (argsi.Frame.IsMain)
                        {
                            b.SetZoomLevel(zoomLevel);
                        }
                    };
                }
                await LoadPageAsync(browser);

                //Check preferences on the CEF UI Thread
                await Cef.UIThreadTaskFactory.StartNew(delegate
                {
                    var preferences = requestContext.GetAllPreferences(true);

                    //Check do not track status
                    var doNotTrack = (bool)preferences["enable_do_not_track"];

                    Debug.WriteLine("DoNotTrack: " + doNotTrack);
                });

                var onUi = Cef.CurrentlyOnThread(CefThreadIds.TID_UI);
















            }
        }

        public static Task LoadPageAsync(IWebBrowser browser, string address = null)
        {
            var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            EventHandler<LoadingStateChangedEventArgs> handler = null;
            handler = (sender, args) =>
            {
                //Wait for while page to finish loading not just the first frame
                if (!args.IsLoading)
                {
                    browser.LoadingStateChanged -= handler;
                    //Important that the continuation runs async using TaskCreationOptions.RunContinuationsAsynchronously
                    tcs.TrySetResult(true);
                }
            };

            browser.LoadingStateChanged += handler;

            if (!string.IsNullOrEmpty(address))
            {
                browser.Load(address);
            }
            return tcs.Task;
        }








    }
}
