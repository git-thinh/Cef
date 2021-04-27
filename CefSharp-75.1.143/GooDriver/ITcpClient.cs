using CefSharp.Example;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefSharp.WinForms.Example
{
    public interface ITcpClient
    {
        IHandlerCallback HandlerCallback { set; get; }
        void SendOcrResult(string data);
    }
}
