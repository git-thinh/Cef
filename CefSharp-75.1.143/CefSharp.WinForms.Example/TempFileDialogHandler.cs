using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefSharp.WinForms.Example
{
    public class TempFileDialogHandler : IDialogHandler
    { 
        public bool OnFileDialog(IWebBrowser chromiumWebBrowser, IBrowser browser, CefFileDialogMode mode, CefFileDialogFlags flags, string title, string defaultFilePath, List<string> acceptFilters, int selectedAcceptFilter, IFileDialogCallback callback)
        {
            //callback.Continue(selectedAcceptFilter, new List<string> { Path.GetRandomFileName() });
            string file = Path.Combine(System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location), "test.jpg");
            if (File.Exists(file))
            {
                callback.Continue(selectedAcceptFilter, new List<string> { file });
                return true;
            }
            return false;
        }
    }
}
