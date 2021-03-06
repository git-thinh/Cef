// Copyright © 2010 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.Example;
using CefSharp.Example.Callback;
using CefSharp.Example.Handlers;
using Newtonsoft.Json;

namespace CefSharp.WinForms.Example
{
    public partial class BrowserForm : Form, IHandlerCallback
    {
        const bool VISIBLE_CONTROLS_DEBUG = false;
        //private const string DefaultUrlForAddedTabs = "http://opencart.templatemela.com/OPCADD4/OPC094/";
        //private const string DefaultUrlForAddedTabs = "http://192.168.10.54:55555/";
        //private const string DefaultUrlForAddedTabs = "https://cloud.google.com/vision/docs/drag-and-drop";
        private const string DefaultUrlForAddedTabs = "https://drive.google.com/drive/u/0/folders/1819YHOo7QfEf4H_0GDwp5UJkD6HGOzN1";

        #region


        // Default to a small increment:
        private const double ZoomIncrement = 0.10;

        private bool multiThreadedMessageLoopEnabled;

        readonly ITcpClient _tcpClient;
        public BrowserForm(bool multiThreadedMessageLoopEnabled, ITcpClient tcpClient)
        {
            InitializeComponent();

            _tcpClient = tcpClient;
            CheckForIllegalCrossThreadCalls = false;

            //var bitness = Environment.Is64BitProcess ? "x64" : "x86";
            //this.Text = "CefSharp.WinForms.Example - " + bitness;
            //WindowState = FormWindowState.Maximized;

            //Only perform layout when control has completly finished resizing
            ResizeBegin += (s, e) => SuspendLayout();
            ResizeEnd += (s, e) => ResumeLayout(true);

            this.multiThreadedMessageLoopEnabled = multiThreadedMessageLoopEnabled;

            this.MaximizeBox = false;
            this.Text = string.Empty;
            this.menuStrip1.Visible = VISIBLE_CONTROLS_DEBUG;
            this.Shown += form_Shown;
            this.Load += BrowserFormLoad;

        }


        public IContainer Components
        {
            get
            {
                if (components == null)
                {
                    components = new Container();
                }

                return components;
            }
        }

        private void BrowserFormLoad(object sender, EventArgs e)
        {
            AddTab(DefaultUrlForAddedTabs);
            //AddTab(CefExample.DefaultUrl);
        }

        /// <summary>
        /// Used to add a Popup browser as a Tab
        /// </summary>
        /// <param name="browserHostControl"></param>
        public void AddTab(Control browserHostControl, string url)
        {
            browserTabControl.SuspendLayout();

            var tabPage = new TabPage(url)
            {
                Dock = DockStyle.Fill
            };

            tabPage.Controls.Add(browserHostControl);

            browserTabControl.TabPages.Add(tabPage);

            //Make newly created tab active
            browserTabControl.SelectedTab = tabPage;

            browserTabControl.ResumeLayout(true);
        }

        private void AddTab(string url, int? insertIndex = null)
        {
            browserTabControl.SuspendLayout();

            var browser = new BrowserTabUserControl(AddTab, url, multiThreadedMessageLoopEnabled, this)
            {
                Dock = DockStyle.Fill,
            };

            var tabPage = new TabPage(string.Empty)
            {
                Dock = DockStyle.Fill
            };

            //This call isn't required for the sample to work. 
            //It's sole purpose is to demonstrate that #553 has been resolved.
            browser.CreateControl();

            tabPage.Controls.Add(browser);
            browser.Visible_Toolbar(VISIBLE_CONTROLS_DEBUG);

            if (insertIndex == null)
            {
                browserTabControl.TabPages.Add(tabPage);
            }
            else
            {
                browserTabControl.TabPages.Insert(insertIndex.Value, tabPage);
            }

            //Make newly created tab active
            browserTabControl.SelectedTab = tabPage;

            browserTabControl.ResumeLayout(true);
        }

        private void ExitMenuItemClick(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void ExitApplication()
        {
            Close();
        }

        private void AboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        public void RemoveTab(IntPtr windowHandle)
        {
            var parentControl = FromChildHandle(windowHandle);
            if (!parentControl.IsDisposed)
            {
                if (parentControl.Parent is TabPage tabPage)
                {
                    browserTabControl.TabPages.Remove(tabPage);
                }
                else if (parentControl.Parent is Panel panel)
                {
                    var browserTabUserControl = (BrowserTabUserControl)panel.Parent;

                    var tab = (TabPage)browserTabUserControl.Parent;
                    browserTabControl.TabPages.Remove(tab);
                }
            }
        }

        private void FindMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.ShowFind();
            }
        }

        private void CopySourceToClipBoardAsyncClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.CopySourceToClipBoardAsync();
            }
        }

        private BrowserTabUserControl GetCurrentTabControl()
        {
            if (browserTabControl.SelectedIndex == -1)
            {
                return null;
            }

            if (browserTabControl.Controls.Count == 0) return null;

            var tabPage = browserTabControl.Controls[browserTabControl.SelectedIndex];
            var control = tabPage.Controls[0] as BrowserTabUserControl;

            return control;
        }

        private void NewTabToolStripMenuItemClick(object sender, EventArgs e)
        {
            AddTab(DefaultUrlForAddedTabs);
        }

        private void CloseTabToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (browserTabControl.TabPages.Count == 0)
            {
                return;
            }

            var currentIndex = browserTabControl.SelectedIndex;

            var tabPage = browserTabControl.TabPages[currentIndex];

            var control = GetCurrentTabControl();
            if (control != null && !control.IsDisposed)
            {
                control.Dispose();
            }

            browserTabControl.TabPages.Remove(tabPage);

            tabPage.Dispose();

            browserTabControl.SelectedIndex = currentIndex - 1;

            if (browserTabControl.TabPages.Count == 0)
            {
                ExitApplication();
            }
        }

        private void UndoMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.Undo();
            }
        }

        private void RedoMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.Redo();
            }
        }

        private void CutMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.Cut();
            }
        }

        private void CopyMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.Copy();
            }
        }

        private void PasteMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.Paste();
            }
        }

        private void DeleteMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.Delete();
            }
        }

        private void SelectAllMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.SelectAll();
            }
        }

        private void PrintToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.Print();
            }
        }

        private void ShowDevToolsMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.ShowDevTools();

                //EXPERIMENTAL Example below shows how to use a control to host DevTools
                //(in this case it's added as a new TabPage)
                // NOTE: Does not currently move/resize correctly
                //var tabPage = new TabPage("DevTools")
                //{
                //    Dock = DockStyle.Fill
                //};

                //var panel = new Panel
                //{
                //    Dock = DockStyle.Fill
                //};

                ////We need to call CreateControl as we need the Handle later
                //panel.CreateControl();

                //tabPage.Controls.Add(panel);

                //browserTabControl.TabPages.Add(tabPage);

                ////Make newly created tab active
                //browserTabControl.SelectedTab = tabPage;

                ////Grab the client rect
                //var rect = panel.ClientRectangle;
                //var webBrowser = control.Browser;
                //var browser = webBrowser.GetBrowser().GetHost();
                //var windowInfo = new WindowInfo();
                ////DevTools becomes a child of the panel, we use it's dimesions
                //windowInfo.SetAsChild(panel.Handle, rect.Left, rect.Top, rect.Right, rect.Bottom);
                ////Show DevTools in our panel 
                //browser.ShowDevTools(windowInfo);
            }
        }

        private void CloseDevToolsMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.CloseDevTools();
            }
        }

        private void ZoomInToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                var task = control.Browser.GetZoomLevelAsync();

                task.ContinueWith(previous =>
                {
                    if (previous.Status == TaskStatus.RanToCompletion)
                    {
                        var currentLevel = previous.Result;
                        control.Browser.SetZoomLevel(currentLevel + ZoomIncrement);
                    }
                    else
                    {
                        throw new InvalidOperationException("Unexpected failure of calling CEF->GetZoomLevelAsync", previous.Exception);
                    }
                }, TaskContinuationOptions.ExecuteSynchronously);
            }
        }

        private void ZoomOutToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                var task = control.Browser.GetZoomLevelAsync();
                task.ContinueWith(previous =>
                {
                    if (previous.Status == TaskStatus.RanToCompletion)
                    {
                        var currentLevel = previous.Result;
                        control.Browser.SetZoomLevel(currentLevel - ZoomIncrement);
                    }
                    else
                    {
                        throw new InvalidOperationException("Unexpected failure of calling CEF->GetZoomLevelAsync", previous.Exception);
                    }
                }, TaskContinuationOptions.ExecuteSynchronously);
            }
        }

        private void CurrentZoomLevelToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                var task = control.Browser.GetZoomLevelAsync();
                task.ContinueWith(previous =>
                {
                    if (previous.Status == TaskStatus.RanToCompletion)
                    {
                        var currentLevel = previous.Result;
                        MessageBox.Show("Current ZoomLevel: " + currentLevel.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Unexpected failure of calling CEF->GetZoomLevelAsync: " + previous.Exception.ToString());
                    }
                }, TaskContinuationOptions.HideScheduler);
            }
        }

        private void DoesActiveElementAcceptTextInputToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                var frame = control.Browser.GetFocusedFrame();

                //Execute extension method
                frame.ActiveElementAcceptsTextInput().ContinueWith(task =>
                {
                    string message;
                    var icon = MessageBoxIcon.Information;
                    if (task.Exception == null)
                    {
                        var isText = task.Result;
                        message = string.Format("The active element is{0}a text entry element.", isText ? " " : " not ");
                    }
                    else
                    {
                        message = string.Format("Script evaluation failed. {0}", task.Exception.Message);
                        icon = MessageBoxIcon.Error;
                    }

                    MessageBox.Show(message, "Does active element accept text input", MessageBoxButtons.OK, icon);
                });
            }
        }

        private void DoesElementWithIdExistToolStripMenuItemClick(object sender, EventArgs e)
        {
            // This is the main thread, it's safe to create and manipulate form
            // UI controls.
            var dialog = new InputBox
            {
                Instructions = "Enter an element ID to find.",
                Title = "Find an element with an ID"
            };

            dialog.OnEvaluate += (senderDlg, eDlg) =>
            {
                // This is also the main thread.
                var control = GetCurrentTabControl();
                if (control != null)
                {
                    var frame = control.Browser.GetFocusedFrame();

                    //Execute extension method
                    frame.ElementWithIdExists(dialog.Value).ContinueWith(task =>
                    {
                        // Now we're not on the main thread, perhaps the
                        // Cef UI thread. It's not safe to work with
                        // form UI controls or to block this thread.
                        // Queue up a delegate to be executed on the
                        // main thread.
                        BeginInvoke(new Action(() =>
                        {
                            string message;
                            if (task.Exception == null)
                            {
                                message = task.Result.ToString();
                            }
                            else
                            {
                                message = string.Format("Script evaluation failed. {0}", task.Exception.Message);
                            }

                            dialog.Result = message;
                        }));
                    });
                }
            };

            dialog.Show(this);
        }

        private void GoToDemoPageToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.Load("custom://cefsharp/ScriptedMethodsTest.html");
            }
        }

        private void InjectJavascriptCodeToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                var frame = control.Browser.GetFocusedFrame();

                //Execute extension method
                frame.ListenForEvent("test-button", "click");
            }
        }

        private async void PrintToPdfToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                var dialog = new SaveFileDialog
                {
                    DefaultExt = ".pdf",
                    Filter = "Pdf documents (.pdf)|*.pdf"
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var success = await control.Browser.PrintToPdfAsync(dialog.FileName, new PdfPrintSettings
                    {
                        MarginType = CefPdfPrintMarginType.Custom,
                        MarginBottom = 10,
                        MarginTop = 0,
                        MarginLeft = 20,
                        MarginRight = 10
                    });

                    if (success)
                    {
                        MessageBox.Show("Pdf was saved to " + dialog.FileName);
                    }
                    else
                    {
                        MessageBox.Show("Unable to save Pdf, check you have write permissions to " + dialog.FileName);
                    }

                }

            }
        }

        private void OpenDataUrlToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                const string html = "<html><head><title>Test</title></head><body><h1>Html Encoded in URL!</h1></body></html>";
                control.Browser.LoadHtml(html, false);
            }
        }

        private void OpenHttpBinOrgToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.Load("https://httpbin.org/");
            }
        }

        private void RunFileDialogToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.GetBrowserHost().RunFileDialog(CefFileDialogMode.Open, "Open", null, new List<string> { "*.*" }, 0, new RunFileDialogCallback());
            }
        }

        private void LoadExtensionsToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                //The sample extension only works for http(s) schemes
                if (control.Browser.Address.StartsWith("http"))
                {
                    var requestContext = control.Browser.GetBrowserHost().RequestContext;

                    var dir = Path.Combine(AppContext.BaseDirectory, @"..\extensions");
                    dir = Path.GetFullPath(dir);
                    if (!Directory.Exists(dir))
                    {
                        throw new DirectoryNotFoundException("Unable to locate example extensions folder - " + dir);
                    }

                    var extensionHandler = new ExtensionHandler
                    {
                        LoadExtensionPopup = (url) =>
                        {
                            BeginInvoke(new Action(() =>
                            {
                                var extensionForm = new Form();

                                var extensionBrowser = new ChromiumWebBrowser(url);
                                //extensionBrowser.IsBrowserInitializedChanged += (s, args) =>
                                //{
                                //    extensionBrowser.ShowDevTools();
                                //};

                                extensionForm.Controls.Add(extensionBrowser);

                                extensionForm.Show(this);
                            }));
                        },
                        GetActiveBrowser = (extension, isIncognito) =>
                        {
                            //Return the active browser for which the extension will act upon
                            return control.Browser.GetBrowser();
                        }
                    };

                    requestContext.LoadExtensionsFromDirectory(dir, extensionHandler);
                }
                else
                {
                    MessageBox.Show("The sample extension only works with http(s) schemes, please load a different website and try again", "Unable to load Extension");
                }
            }
        }

        private void JavascriptBindingStressTestToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.Load(CefExample.BindingTestUrl);
                control.Browser.LoadingStateChanged += (o, args) =>
                {
                    if (args.IsLoading == false)
                    {
                        Task.Delay(10000).ContinueWith(t =>
                        {
                            if (control.Browser != null)
                            {
                                control.Browser.Reload();
                            }
                        });
                    }
                };
            }
        }

        public void post_test()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            dlg.Multiselect = false;
            dlg.Title = "Select images";

            DialogResult dr = dlg.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string imgBase64 = "";
                using (Image image = Image.FromFile(dlg.FileName))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        byte[] imageBytes = m.ToArray();
                        imgBase64 = Convert.ToBase64String(imageBytes);
                    }
                }
                var input = JsonConvert.SerializeObject(new GOO_VISION_API_RET(imgBase64), Formatting.Indented);


                var control = GetCurrentTabControl();
                if (control != null)
                {
                    string url = MemoryCache.Default.Get("URL") as string;
                    NameValueCollection headers = MemoryCache.Default.Get("HEADERS") as NameValueCollection;
                    var postDataBytes = MemoryCache.Default.Get("POST_DATA") as byte[];
                    string json = Encoding.UTF8.GetString(postDataBytes);
                    postDataBytes = Encoding.UTF8.GetBytes(input);

                    var frame = control.Browser.GetFocusedFrame();
                    IRequest request = frame.CreateRequest();

                    request.Url = url;
                    request.Method = "POST";

                    request.InitializePostData();
                    var element = request.PostData.CreatePostDataElement();
                    element.Bytes = postDataBytes;
                    request.PostData.AddElement(element);

                    request.Headers = headers;

                    frame.LoadRequest(request);
                }
            }
        }

        private void postTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            post_test();
        }

        #endregion

        void form_Shown(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;

            Top = 0;
            Left = 0;
            //Width = 600;
            //Height = 560;

            Width = 1024;
            Height = 768;

            var b1 = new Button() { Dock = DockStyle.None, Height = 22, Location = new Point(0, 0), Text = "Debug", Width = 50 };
            b1.Click += (si, ei) => debug_command("OPEN_DEV_TOOL");
            this.Controls.Add(b1);
            b1.BringToFront();

            var b2 = new Button() { Dock = DockStyle.None, Height = 22, Location = new Point(55, 0), Text = "ReStart", Width = 60 };
            b2.Click += (si, ei) => debug_command("RE_OPEN");
            this.Controls.Add(b2);
            b2.BringToFront();

            this.FormClosing += (se, ev) =>
            {
                ___exit();
            };
        }

        void debug_command(string cmd)
        {
            switch (cmd)
            {
                case "OPEN_DEV_TOOL":
                    ___show_DevTool();
                    break;
                case "RE_OPEN":
                    ___exit(true);
                    break;
            }
        }

        void ___exit(bool isRestart = false)
        {

            if (isRestart)
                Process.Start(Application.ExecutablePath, "");

            Process.GetCurrentProcess().Kill(); 
        }

        public int StepId { set; get; }

        public void browser_onFrameLoadEnd(string url)
        {
            StepId = 1;

            //var control = GetCurrentTabControl();
            //if (control != null)
            //{
            //    if (File.Exists("a.js"))
            //    {
            //        string js = File.ReadAllText("a.js");
            //        control.Browser.GetBrowser().MainFrame.ExecuteJavaScriptAsync(js);

            //        Thread.Sleep(200);
            //        ___clickAutoOnForm();
            //    }
            //}
        }
        public void captcha_visbleCheckNotBeRobot()
        {
            StepId = 2;
            Thread.Sleep(300);
            ___clickAutoOnForm();
        }

        public void browser_onIninited()
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
            }
        }

        public void response_tokenInfo(string data)
        {
            MessageBox.Show(data);
        }

        static string root = ConfigurationManager.AppSettings["ROOT_PATH"];
        OCR_BUF ocr = null;
        public void ocr_request_actractImage2Text(string fileImage)
        {
            ocr = null;
            if (fileImage.Split(';').Length == 2)
            {
                ocr = new OCR_BUF();
                ocr.files = fileImage.Split(';');
                OcrRunning = true;
                postApiOcr(ocr.files[0]);
            }
        }

        void postApiOcr(string fileImage)
        {
            string file = Path.Combine(root, fileImage);
            if (File.Exists(file))
            {
                string imgBase64 = "";
                using (Image image = Image.FromFile(file))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        byte[] imageBytes = m.ToArray();
                        imgBase64 = Convert.ToBase64String(imageBytes);
                    }
                }
                var input = JsonConvert.SerializeObject(new GOO_VISION_API_RET(imgBase64), Formatting.Indented);

                var control = GetCurrentTabControl();
                if (control != null)
                {
                    string url = MemoryCache.Default.Get("URL") as string;
                    NameValueCollection headers = MemoryCache.Default.Get("HEADERS") as NameValueCollection;
                    var postDataBytes = MemoryCache.Default.Get("POST_DATA") as byte[];
                    string json = Encoding.UTF8.GetString(postDataBytes);
                    postDataBytes = Encoding.UTF8.GetBytes(input);

                    var frame = control.Browser.GetFocusedFrame();
                    IRequest request = frame.CreateRequest();

                    request.Url = url;
                    request.Method = "POST";

                    request.InitializePostData();
                    var element = request.PostData.CreatePostDataElement();
                    element.Bytes = postDataBytes;
                    request.PostData.AddElement(element);

                    request.Headers = headers;

                    frame.LoadRequest(request);
                }
            }
            else
            {
                response_calbackSuccess(fileImage, "", "");
            }
        }

        public void response_calbackSuccess(string url, string input, string data)
        {
            if (ocr == null)
            {
                StepId = 3;
                var control = GetCurrentTabControl();
                if (control != null)
                {
                    if (File.Exists("ok.js"))
                    {
                        string js = File.ReadAllText("ok.js");
                        control.Browser.GetBrowser().MainFrame.ExecuteJavaScriptAsync(js);
                    }
                }
                return;
            }

            string s = "";
            string[] a = new string[] { };
            if (ocr.DataFront == null)
            {
                a = new string[] { };
                try
                {
                    var o = JsonConvert.DeserializeObject<GOO_VISION_API>(data);
                    if (o.responses.Length > 0)
                        a = o.responses[0].textAnnotations.Select(x => x.description).ToArray();
                    if (a.Length > 0) s = a[0];
                }
                catch (Exception ex)
                {
                    s = "ERROR:" + ex.Message;
                }

                ocr.DataFront = s;
                postApiOcr(ocr.files[1]);
            }
            else
            {
                a = new string[] { };
                try
                {
                    var o = JsonConvert.DeserializeObject<GOO_VISION_API>(data);
                    if (o.responses.Length > 0)
                        a = o.responses[0].textAnnotations.Select(x => x.description).ToArray();
                    if (a.Length > 0) s = a[0];
                }
                catch (Exception ex)
                {
                    s = "ERROR:" + ex.Message;
                }

                OcrRunning = false;

                ocr.DataBack = s;
                string json = JsonConvert.SerializeObject(ocr, Formatting.Indented);
                ocr = null;
                _tcpClient.SendOcrResult(json);
            }
        }

        public void browser_goF5()
        {
            var control = GetCurrentTabControl();
            if (control != null)
                control.Browser.Reload(false);
        }

        public bool OcrRunning { set; get; }

        static bool AUTO_RE_START_IF_REQUEST_TOKEN_FAIL = ConfigurationManager.AppSettings["AUTO_RE_START_IF_REQUEST_TOKEN_FAIL"] == "1" ? true : false;
        public void captcha_visbleChooseImage()
        {
            if (AUTO_RE_START_IF_REQUEST_TOKEN_FAIL)
            { 
                //Thread.Sleep(300);
                ___exit(true);
            }
        }


        void ___clickAutoOnForm(int y = 150)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                int x = this.Width / 2;
                //int y = 150;

                MouseLeftDown(x, y);
                MouseLeftUp(x, y);
            }
        }

        void ___show_DevTool()
        {
            var control = GetCurrentTabControl();
            if (control != null)
                control.Browser.ShowDevTools();
        }

        #region [ MOUSE RAISE CLICK ]

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
                control.Browser.Reload(false);
        }

        private void mouseClickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                int x = this.Width / 2;
                int y = 100;// this.Height / 5;

                //control.Browser.GetBrowser().GetHost().SendMouseClickEvent(x, y, MouseButtonType.Left, false, 1, CefEventFlags.None);
                //System.Threading.Thread.Sleep(100);
                //control.Browser.GetBrowser().GetHost().SendMouseClickEvent(0, 0, MouseButtonType.Left, true, 1, CefEventFlags.None);

                MouseLeftDown(x, y);
                MouseLeftUp(x, y);
            }
        }

        public void MouseLeftDown(int x, int y)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.GetBrowser().GetHost()
                .SendMouseClickEvent(x, y, MouseButtonType.Left, false, 1, CefEventFlags.None);
                Thread.Sleep(15);
            }
        }

        public void MouseLeftUp(int x, int y)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.GetBrowser().GetHost()
                .SendMouseClickEvent(x, y, MouseButtonType.Left, true, 1, CefEventFlags.None);
                Thread.Sleep(15);
            }
        }

        public void HitEnter(int x, int y)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                KeyEvent k = new KeyEvent
                {
                    WindowsKeyCode = 0x0D, // Enter
                    FocusOnEditableField = true,
                    IsSystemKey = false,
                    Type = KeyEventType.KeyDown
                };

                control.Browser.GetBrowser().GetHost().SendKeyEvent(k);

                Thread.Sleep(100);

                k = new KeyEvent
                {
                    WindowsKeyCode = 0x0D, // Enter
                    FocusOnEditableField = true,
                    IsSystemKey = false,
                    Type = KeyEventType.KeyUp
                };

                control.Browser.GetBrowser().GetHost().SendKeyEvent(k);

                Thread.Sleep(100);
            }
        }

        #endregion

    }

}
