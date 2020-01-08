// Copyright © 2010 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.Example;
using CefSharp.Example.Handlers;
using CefSharp.WinForms.Example.Handlers;
using CefSharp.WinForms.Example.Minimal;

namespace CefSharp.WinForms.Example
{
    public class OCR_CMT
    {
        public string address { set; get; } 
        public string id { set; get; } 
        public string fullname { set; get; } 
        public string birthday { set; get; }
        public string expiry { set; get; } 
        public string gender { set; get; }
        public string ethnicity { set; get; } 
        public string issue_by { set; get; } 
        public string issue_date { set; get; } 
        public string religion { set; get; }

        public string image { set; get; } 
        public int status_code { set; get; } 
        public string status { set; get; } 

        public OCR_CMT()
        {
            address = "N/A";  // Thuận Tốn, Đa Tốn, Gia Lâm, Hà Nội",
            id = "N/A";  //012925499",
            fullname = "N/A";  //ĐÀO THẾ LONG",
            birthday = "N/A";  //08-02-1992",
            expiry = "N/A";  //N/A",
            gender = "N/A";  //N/A",
            ethnicity = "N/A";  //Kinh",
            issue_by = "N/A";  //TP Hà Nội",
            issue_date = "N/A";  //11-10-2006",
            religion = "N/A";  //Không",
            image = "N/A";  //": 2,
            status_code = 0;  //": 2,
            status = "fail";  //success"
        }
    }


    public class Program
    {
        [STAThread]
        public static int Main(string[] args)
        {
            //string p = "";
            //p = "^/(?=[^/]*$)";
            //p = "/?files=(.*)";
            ////p = "/?files=(.*)&test2=(.*)";

            //string s = "";
            //s = "/";
            //s = "/?files=1.jpg;2.jpg&test2=1";
            ////s = "/api/ocr";

            //bool ok;
            //if (Regex.Match(s, p).Success)
            //    ok = true;
            //else
            //    ok = false;

            ApiServer apiServer = new ApiServer();
            const bool simpleSubProcess = false;

            Cef.EnableHighDPISupport();

            //NOTE: Using a simple sub processes uses your existing application executable to spawn instances of the sub process.
            //Features like JSB, EvaluateScriptAsync, custom schemes require the CefSharp.BrowserSubprocess to function
            if (simpleSubProcess)
            {
                var exitCode = Cef.ExecuteProcess();

                if (exitCode >= 0)
                {
                    return exitCode;
                }

#if DEBUG
                if (!System.Diagnostics.Debugger.IsAttached)
                {
                    MessageBox.Show("When running this Example outside of Visual Studio " +
                                    "please make sure you compile in `Release` mode.", "Warning");
                }
#endif

                var settings = new CefSettings();
                settings.BrowserSubprocessPath = "CefSharp.WinForms.Example.exe";

                Cef.Initialize(settings);

                // replace the IP with your system IP Address...
                var browser = new SimpleBrowserForm(true);
                Application.Run(browser);
            }
            else
            {
#if DEBUG
                if (!System.Diagnostics.Debugger.IsAttached)
                {
                    MessageBox.Show("When running this Example outside of Visual Studio " +
                                    "please make sure you compile in `Release` mode.", "Warning");
                }
#endif

                //When multiThreadedMessageLoop = true then externalMessagePump must be set to false
                // To enable externalMessagePump set  multiThreadedMessageLoop = false and externalMessagePump = true
                const bool multiThreadedMessageLoop = true;
                const bool externalMessagePump = false;

                var browser = new BrowserForm(multiThreadedMessageLoop, apiServer);
                //var browser = new SimpleBrowserForm(multiThreadedMessageLoop);
                //var browser = new TabulationDemoForm();

                IBrowserProcessHandler browserProcessHandler;

                if (multiThreadedMessageLoop)
                {
                    browserProcessHandler = new BrowserProcessHandler();
                }
                else
                {
                    if (externalMessagePump)
                    {
                        //Get the current taskScheduler (must be called after the form is created)
                        var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
                        browserProcessHandler = new ScheduleMessagePumpBrowserProcessHandler(scheduler);
                    }
                    else
                    {
                        //We'll add out WinForms timer to the components container so it's Diposed
                        browserProcessHandler = new WinFormsBrowserProcessHandler(browser.Components);
                    }

                }

                var settings = new CefSettings();
                settings.MultiThreadedMessageLoop = multiThreadedMessageLoop;
                settings.ExternalMessagePump = externalMessagePump;

                CefExample.Init(settings, browserProcessHandler: browserProcessHandler);

                apiServer.HandlerCallback = browser;
                apiServer.Start(); 

                //Application.Run(new MultiFormAppContext(multiThreadedMessageLoop));
                Application.Run(browser);
            }

            return 0;
        }
    }
}
