﻿#pragma checksum "..\..\..\JavascriptCallbackMainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9B284532949E123B3AADE27FF810A6E24A2F88147E61DCE3F3DDC46667912FFF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CefSharp.Wpf;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace CefSharp.Wpf.Example {
    
    
    /// <summary>
    /// JavascriptCallbackMainWindow
    /// </summary>
    public partial class JavascriptCallbackMainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\JavascriptCallbackMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CefSharp.Wpf.ChromiumWebBrowser BrowserOne;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\JavascriptCallbackMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CefSharp.Wpf.ChromiumWebBrowser BrowserTwo;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CefSharp.Wpf.Example;component/javascriptcallbackmainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\JavascriptCallbackMainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.BrowserOne = ((CefSharp.Wpf.ChromiumWebBrowser)(target));
            return;
            case 2:
            this.BrowserTwo = ((CefSharp.Wpf.ChromiumWebBrowser)(target));
            return;
            case 3:
            
            #line 20 "..\..\..\JavascriptCallbackMainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExecuteCallbackImmediatelyClick);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 21 "..\..\..\JavascriptCallbackMainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExecuteCallbackInThreeSeconds);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

