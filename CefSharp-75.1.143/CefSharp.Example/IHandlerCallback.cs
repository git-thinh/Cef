﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefSharp.Example
{
    public interface IHandlerCallback
    {
        void requestOcr(string fileImage);
        void responseCalback(string url, string input, string data);
    }
}
