using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefSharp.Example
{
    public interface IHandlerCallback
    {
        bool OcrRunning { set; get; }
        int StepId { set; get; }

        void captchaVisble();
        void captchaVisbleChooseImage();
        void page_frameLoadEnd(string url);
        void response_tokenInfo(string data);
        void browser_Ininited();
        void browserF5();
        void requestOcr(string fileImage);
        void responseCalback(string url, string input, string data);
    }
}
