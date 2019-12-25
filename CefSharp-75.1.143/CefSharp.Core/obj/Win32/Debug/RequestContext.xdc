<?xml version="1.0"?><doc>
<members>
<member name="T:CefSharp.RequestContextSettings" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContextSettings.h" line="12">
<summary>
RequestContextSettings
</summary>
</member>
<member name="M:CefSharp.RequestContextSettings.#ctor" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContextSettings.h" line="27">
<summary>
Default constructor
</summary>
</member>
<member name="P:CefSharp.RequestContextSettings.PersistSessionCookies" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContextSettings.h" line="44">
<summary>
To persist session cookies (cookies without an expiry date or validity
interval) by default when using the global cookie manager set this value to
true. Session cookies are generally intended to be transient and most
Web browsers do not persist them. Can be set globally using the
CefSettings.PersistSessionCookies value. This value will be ignored if
CachePath is empty or if it matches the CefSettings.CachePath value.
</summary>
</member>
<member name="P:CefSharp.RequestContextSettings.PersistUserPreferences" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContextSettings.h" line="58">
<summary>
To persist user preferences as a JSON file in the cache path directory set
this value to true. Can be set globally using the
CefSettings.PersistUserPreferences value. This value will be ignored if
CachePath is empty or if it matches the CefSettings.CachePath value.
</summary>
</member>
<member name="P:CefSharp.RequestContextSettings.CachePath" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContextSettings.h" line="70">
<summary>
The location where cache data for this request context will be stored on
disk. If non-empty this must be either equal to or a child directory of
CefSettings.RootCachePath. If empty then browsers will be created in
"incognito mode" where in-memory caches are used for storage and no data is
persisted to disk. HTML5 databases such as localStorage will only persist
across sessions if a cache path is specified. To share the global browser
cache and related configuration set this value to match the
CefSettings.CachePath value.
</summary>
</member>
<member name="P:CefSharp.RequestContextSettings.AcceptLanguageList" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContextSettings.h" line="86">
<summary>
Comma delimited ordered list of language codes without any whitespace that
will be used in the "Accept-Language" HTTP header. Can be set globally
using the CefSettings.accept_language_list value or overridden on a per-
browser basis using the BrowserSettings.AcceptLanguageList value. If
all values are empty then "en-US,en" will be used. This value will be
ignored if CachePath matches the CefSettings.CachePath value.
</summary>
</member>
<member name="P:CefSharp.RequestContextSettings.EnableNetSecurityExpiration" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContextSettings.h" line="100">
<summary>
Set to true to enable date-based expiration of built in network security information (i.e. certificate transparency logs,
HSTS preloading and pinning information). Enabling this option improves network security but may cause HTTPS load failures when
using CEF binaries built more than 10 weeks in the past. See https://www.certificate-transparency.org/ and
https://www.chromium.org/hsts for details. Can be set globally using the CefSettings.EnableNetSecurityExpiration value.
</summary>
</member>
<member name="P:CefSharp.RequestContextSettings.IgnoreCertificateErrors" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContextSettings.h" line="112">
<summary>
Set to true to ignore errors related to invalid SSL certificates.
Enabling this setting can lead to potential security vulnerabilities like
"man in the middle" attacks. Applications that load content from the
internet should not enable this setting. Can be set globally using the
CefSettings.IgnoreCertificateErrors value. This value will be ignored if
CachePath matches the CefSettings.cache_path value.
</summary>
</member>
<member name="T:CefRequestCallback" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_request_callback.h" line="43">


</member>
<member name="M:CefRequestCallback.Continue(System.Boolean)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_request_callback.h" line="49">


</member>
<member name="M:CefRequestCallback.Cancel" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_request_callback.h" line="56">


</member>
<member name="T:CefResponse" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_response.h" line="44">


</member>
<member name="M:CefResponse.Create" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_response.h" line="53">


</member>
<member name="M:CefResponse.IsReadOnly" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_response.h" line="59">


</member>
<member name="M:CefResponse.GetError" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_response.h" line="65">


</member>
<member name="M:CefResponse.SetError(cef_errorcode_t)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_response.h" line="71">


</member>
<member name="M:CefResponse.GetStatus" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_response.h" line="78">


</member>
<member name="M:CefResponse.SetStatus(System.Int32)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_response.h" line="84">


</member>
<member name="M:CefResponse.GetStatusText" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_response.h" line="90">


</member>
<member name="M:CefResponse.SetStatusText(CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_response.h" line="96">


</member>
<member name="M:CefResponse.GetMimeType" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_response.h" line="102">


</member>
<member name="M:CefResponse.SetMimeType(CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_response.h" line="108">


</member>
<member name="M:CefResponse.GetCharset" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_response.h" line="114">


</member>
<member name="M:CefResponse.SetCharset(CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_response.h" line="120">


</member>
<member name="M:CefResponse.GetHeader(CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_response.h" line="126">


</member>
<member name="M:CefResponse.GetHeaderMap(std.multimap&lt;CefStringBase&lt;CefStringTraitsUTF16&gt;,CefStringBase&lt;CefStringTraitsUTF16&gt;,std.less&lt;CefStringBase&lt;CefStringTraitsUTF16&gt;&gt;,std.allocator&lt;std.pair&lt;CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst,CefStringBase&lt;CefStringTraitsUTF16&gt;&gt;&gt;&gt;*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_response.h" line="132">


</member>
<member name="M:CefResponse.SetHeaderMap(std.multimap&lt;CefStringBase&lt;CefStringTraitsUTF16&gt;,CefStringBase&lt;CefStringTraitsUTF16&gt;,std.less&lt;CefStringBase&lt;CefStringTraitsUTF16&gt;&gt;,std.allocator&lt;std.pair&lt;CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst,CefStringBase&lt;CefStringTraitsUTF16&gt;&gt;&gt;&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_response.h" line="138">


</member>
<member name="M:CefResponse.GetURL" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_response.h" line="144">


</member>
<member name="M:CefResponse.SetURL(CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_response.h" line="150">


</member>
<member name="T:CefResourceSkipCallback" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_resource_handler.h" line="48">


</member>
<member name="M:CefResourceSkipCallback.Continue(System.Int64)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_resource_handler.h" line="54">


</member>
<member name="T:CefResourceReadCallback" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_resource_handler.h" line="64">


</member>
<member name="M:CefResourceReadCallback.Continue(System.Int32)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_resource_handler.h" line="70">


</member>
<member name="T:CefResourceHandler" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_resource_handler.h" line="82">


</member>
<member name="M:CefResourceHandler.Open(scoped_refptr&lt;CefRequest&gt;,System.Boolean*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,scoped_refptr&lt;CefCallback&gt;)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_resource_handler.h" line="89">


</member>
<member name="M:CefResourceHandler.ProcessRequest(scoped_refptr&lt;CefRequest&gt;,scoped_refptr&lt;CefCallback&gt;)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_resource_handler.h" line="107">


</member>
<member name="M:CefResourceHandler.GetResponseHeaders(scoped_refptr&lt;CefResponse&gt;,System.Int64*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,CefStringBase&lt;CefStringTraitsUTF16&gt;*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_resource_handler.h" line="122">


</member>
<member name="M:CefResourceHandler.Skip(System.Int64,System.Int64*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,scoped_refptr&lt;CefResourceSkipCallback&gt;)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_resource_handler.h" line="142">


</member>
<member name="M:CefResourceHandler.Read(System.Void*,System.Int32,System.Int32*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,scoped_refptr&lt;CefResourceReadCallback&gt;)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_resource_handler.h" line="159">


</member>
<member name="M:CefResourceHandler.ReadResponse(System.Void*,System.Int32,System.Int32*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,scoped_refptr&lt;CefCallback&gt;)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_resource_handler.h" line="181">


</member>
<member name="M:CefResourceHandler.Cancel" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_resource_handler.h" line="199">


</member>
<member name="T:CefResponseFilter" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_response_filter.h" line="43">


</member>
<member name="M:CefResponseFilter.InitFilter" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_response_filter.h" line="52">


</member>
<member name="M:CefResponseFilter.Filter(System.Void*,System.UInt32,System.UInt32*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,System.Void*,System.UInt32,System.UInt32*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_response_filter.h" line="59">


</member>
<member name="T:CefResourceRequestHandler" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_resource_request_handler.h" line="52">


</member>
<member name="M:CefResourceRequestHandler.GetCookieAccessFilter(scoped_refptr&lt;CefBrowser&gt;,scoped_refptr&lt;CefFrame&gt;,scoped_refptr&lt;CefRequest&gt;)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_resource_request_handler.h" line="63">


</member>
<member name="M:CefResourceRequestHandler.OnBeforeResourceLoad(scoped_refptr&lt;CefBrowser&gt;,scoped_refptr&lt;CefFrame&gt;,scoped_refptr&lt;CefRequest&gt;,scoped_refptr&lt;CefRequestCallback&gt;)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_resource_request_handler.h" line="78">


</member>
<member name="M:CefResourceRequestHandler.GetResourceHandler(scoped_refptr&lt;CefBrowser&gt;,scoped_refptr&lt;CefFrame&gt;,scoped_refptr&lt;CefRequest&gt;)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_resource_request_handler.h" line="99">


</member>
<member name="M:CefResourceRequestHandler.OnResourceRedirect(scoped_refptr&lt;CefBrowser&gt;,scoped_refptr&lt;CefFrame&gt;,scoped_refptr&lt;CefRequest&gt;,scoped_refptr&lt;CefResponse&gt;,CefStringBase&lt;CefStringTraitsUTF16&gt;*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_resource_request_handler.h" line="115">


</member>
<member name="M:CefResourceRequestHandler.OnResourceResponse(scoped_refptr&lt;CefBrowser&gt;,scoped_refptr&lt;CefFrame&gt;,scoped_refptr&lt;CefRequest&gt;,scoped_refptr&lt;CefResponse&gt;)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_resource_request_handler.h" line="132">


</member>
<member name="M:CefResourceRequestHandler.GetResourceResponseFilter(scoped_refptr&lt;CefBrowser&gt;,scoped_refptr&lt;CefFrame&gt;,scoped_refptr&lt;CefRequest&gt;,scoped_refptr&lt;CefResponse&gt;)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_resource_request_handler.h" line="153">


</member>
<member name="M:CefResourceRequestHandler.OnResourceLoadComplete(scoped_refptr&lt;CefBrowser&gt;,scoped_refptr&lt;CefFrame&gt;,scoped_refptr&lt;CefRequest&gt;,scoped_refptr&lt;CefResponse&gt;,cef_urlrequest_status_t,System.Int64)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_resource_request_handler.h" line="169">


</member>
<member name="M:CefResourceRequestHandler.OnProtocolExecution(scoped_refptr&lt;CefBrowser&gt;,scoped_refptr&lt;CefFrame&gt;,scoped_refptr&lt;CefRequest&gt;,System.Boolean*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_resource_request_handler.h" line="192">


</member>
<member name="T:CefCookieAccessFilter" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_resource_request_handler.h" line="209">


</member>
<member name="M:CefCookieAccessFilter.CanSendCookie(scoped_refptr&lt;CefBrowser&gt;,scoped_refptr&lt;CefFrame&gt;,scoped_refptr&lt;CefRequest&gt;,CefStructBase&lt;CefCookieTraits&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_resource_request_handler.h" line="217">


</member>
<member name="M:CefCookieAccessFilter.CanSaveCookie(scoped_refptr&lt;CefBrowser&gt;,scoped_refptr&lt;CefFrame&gt;,scoped_refptr&lt;CefRequest&gt;,scoped_refptr&lt;CefResponse&gt;,CefStructBase&lt;CefCookieTraits&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_resource_request_handler.h" line="232">


</member>
<member name="T:CefWebPluginInfo" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_web_plugin.h" line="44">


</member>
<member name="M:CefWebPluginInfo.GetName" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_web_plugin.h" line="50">


</member>
<member name="M:CefWebPluginInfo.GetPath" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_web_plugin.h" line="56">


</member>
<member name="M:CefWebPluginInfo.GetVersion" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_web_plugin.h" line="62">


</member>
<member name="M:CefWebPluginInfo.GetDescription" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_web_plugin.h" line="68">


</member>
<member name="T:CefWebPluginInfoVisitor" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_web_plugin.h" line="75">


</member>
<member name="M:CefWebPluginInfoVisitor.Visit(scoped_refptr&lt;CefWebPluginInfo&gt;,System.Int32,System.Int32)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_web_plugin.h" line="82">


</member>
<member name="M:CefVisitWebPluginInfo(scoped_refptr&lt;CefWebPluginInfoVisitor&gt;)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_web_plugin.h" line="94">


</member>
<member name="M:CefRefreshWebPlugins" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_web_plugin.h" line="101">


</member>
<member name="M:CefUnregisterInternalWebPlugin(CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_web_plugin.h" line="109">


</member>
<member name="M:CefRegisterWebPluginCrash(CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_web_plugin.h" line="117">


</member>
<member name="T:CefWebPluginUnstableCallback" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_web_plugin.h" line="124">


</member>
<member name="M:CefWebPluginUnstableCallback.IsUnstable(CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,System.Boolean)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_web_plugin.h" line="131">


</member>
<member name="M:CefIsWebPluginUnstable(CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,scoped_refptr&lt;CefWebPluginUnstableCallback&gt;)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_web_plugin.h" line="140">


</member>
<member name="T:CefRegisterCdmCallback" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_web_plugin.h" line="148">


</member>
<member name="M:CefRegisterCdmCallback.OnCdmRegistrationComplete(cef_cdm_registration_error_t,CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_web_plugin.h" line="156">


</member>
<member name="M:CefRegisterWidevineCdm(CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,scoped_refptr&lt;CefRegisterCdmCallback&gt;)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_web_plugin.h" line="167">


</member>
<member name="T:CefRequestContextHandler" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_request_context_handler.h" line="48">


</member>
<member name="M:CefRequestContextHandler.OnRequestContextInitialized(scoped_refptr&lt;CefRequestContext&gt;)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_request_context_handler.h" line="58">


</member>
<member name="M:CefRequestContextHandler.OnBeforePluginLoad(CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,System.Boolean,CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,scoped_refptr&lt;CefWebPluginInfo&gt;,cef_plugin_policy_t*)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_request_context_handler.h" line="66">


</member>
<member name="M:CefRequestContextHandler.GetResourceRequestHandler(scoped_refptr&lt;CefBrowser&gt;,scoped_refptr&lt;CefFrame&gt;,scoped_refptr&lt;CefRequest&gt;,System.Boolean,System.Boolean,CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,System.Boolean*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_request_context_handler.h" line="94">


</member>
<member name="T:CefSharp.RequestContext" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContext.h" line="22">
<summary>
A request context provides request handling for a set of related browser objects.
A request context is specified when creating a new browser object via the CefBrowserHost
static factory methods. Browser objects with different request contexts will never be
hosted in the same render process. Browser objects with the same request context may or
may not be hosted in the same render process depending on the process model.
Browser objects created indirectly via the JavaScript window.open function or targeted
links will share the same render process and the same request context as the source browser.
When running in single-process mode there is only a single render process (the main process)
and so all browsers created in single-process mode will share the same request context.
This will be the first request context passed into a CefBrowserHost static factory method
and all other request context objects will be ignored. 
</summary>
</member>
<member name="M:CefSharp.RequestContext.#ctor(CefSharp.IRequestContext)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContext.h" line="80">
Creates a new context object that shares storage with | other | and uses an optional | handler | .
</member>
<member name="M:CefSharp.RequestContext.CreateContext(CefSharp.IRequestContext,CefSharp.IRequestContextHandler)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContext.h" line="105">
<summary>
Creates a new context object that shares storage with other and uses an
optional handler.
</summary>
<param name="other">shares storage with this RequestContext</param>
<param name="requestContextHandler">optional requestContext handler</param>
<returns>Returns a nre RequestContext</returns>
</member>
<member name="M:CefSharp.RequestContext.IsSame(CefSharp.IRequestContext)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContext.h" line="121">
<summary>
Returns true if this object is pointing to the same context object.
</summary>
<param name="context">context to compare</param>
<returns>Returns true if the same</returns>
</member>
<member name="M:CefSharp.RequestContext.IsSharingWith(CefSharp.IRequestContext)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContext.h" line="128">
<summary>
Returns true if this object is sharing the same storage as the specified context.
</summary>
<param name="context">context to compare</param>
<returns>Returns true if same storage</returns>
</member>
<member name="M:CefSharp.RequestContext.GetCookieManager(CefSharp.ICompletionCallback)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContext.h" line="135">
<summary>
Returns the default cookie manager for this object. This will be the global
cookie manager if this object is the global request context. 
</summary>
<param name="callback">If callback is non-NULL it will be executed asnychronously on the CEF IO thread
after the manager's storage has been initialized.</param>
<returns>Returns the default cookie manager for this object</returns>
</member>
<member name="P:CefSharp.RequestContext.IsGlobal" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContext.h" line="144">
<summary>
Returns true if this object is the global context. The global context is
used by default when creating a browser or URL request with a NULL context
argument.
</summary>
</member>
<member name="M:CefSharp.RequestContext.RegisterSchemeHandlerFactory(System.String,System.String,CefSharp.ISchemeHandlerFactory)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContext.h" line="158">
<summary>
Register a scheme handler factory for the specified schemeName and optional domainName.
An empty domainName value for a standard scheme will cause the factory to match all domain
names. The domainName value will be ignored for non-standard schemes. If schemeName is
a built-in scheme and no handler is returned by factory then the built-in scheme handler
factory will be called. If schemeName is a custom scheme then you must also implement the
IApp.OnRegisterCustomSchemes() method in all processes. This function may be called multiple
times to change or remove the factory that matches the specified schemeName and optional
domainName.
</summary>
<param name="schemeName">Scheme Name</param>
<param name="domainName">Optional domain name</param>
<param name="factory">Scheme handler factory</param>
<returns>Returns false if an error occurs.</returns>
</member>
<member name="M:CefSharp.RequestContext.ClearSchemeHandlerFactories" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContext.h" line="174">
<summary>
Clear all registered scheme handler factories. 
</summary>
<returns>Returns false on error.</returns>
</member>
<member name="P:CefSharp.RequestContext.CachePath" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContext.h" line="180">
<summary>
Returns the cache path for this object. If empty an "incognito mode"
in-memory cache is being used.
</summary>
</member>
<member name="M:CefSharp.RequestContext.PurgePluginListCache(System.Boolean)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContext.h" line="194">
<summary>
Tells all renderer processes associated with this context to throw away
their plugin list cache. If reloadPages is true they will also reload
all pages with plugins. RequestContextHandler.OnBeforePluginLoad may
be called to rebuild the plugin list cache.
</summary>
<param name="reloadPages">reload any pages with pluginst</param>
</member>
<member name="M:CefSharp.RequestContext.HasPreference(System.String)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContext.h" line="203">
<summary>
Returns true if a preference with the specified name exists. This method
must be called on the CEF UI thread.
</summary>
<param name="name">name of preference</param>
<returns>bool if the preference exists</returns>
<remarks>Use Cef.UIThreadTaskFactory to execute this method if required,
<see cref="!:IBrowserProcessHandler.OnContextInitialized"/> and ChromiumWebBrowser.IsBrowserInitializedChanged are both
executed on the CEF UI thread, so can be called directly.
When CefSettings.MultiThreadedMessageLoop == false (the default is true) then the main
application thread will be the CEF UI thread.</remarks>
</member>
<member name="M:CefSharp.RequestContext.GetPreference(System.String)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContext.h" line="216">
<summary>
Returns the value for the preference with the specified name. Returns
NULL if the preference does not exist. The returned object contains a copy
of the underlying preference value and modifications to the returned object
will not modify the underlying preference value. This method must be called
on the CEF UI thread.
</summary>
<param name="name">preference name</param>
<returns>Returns the value for the preference with the specified name</returns>
<remarks>Use Cef.UIThreadTaskFactory to execute this method if required,
<see cref="!:IBrowserProcessHandler.OnContextInitialized"/> and ChromiumWebBrowser.IsBrowserInitializedChanged are both
executed on the CEF UI thread, so can be called directly.
When CefSettings.MultiThreadedMessageLoop == false (the default is true) then the main
application thread will be the CEF UI thread.</remarks>
</member>
<member name="M:CefSharp.RequestContext.GetAllPreferences(System.Boolean)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContext.h" line="232">
<summary>
Returns all preferences as a dictionary. The returned
object contains a copy of the underlying preference values and
modifications to the returned object will not modify the underlying
preference values. This method must be called on the browser process UI
thread.
</summary>
<param name="includeDefaults">If true then
preferences currently at their default value will be included.</param>
<returns>Preferences (dictionary can have sub dictionaries)</returns>
</member>
<member name="M:CefSharp.RequestContext.CanSetPreference(System.String)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContext.h" line="244">
<summary>
Returns true if the preference with the specified name can be modified
using SetPreference. As one example preferences set via the command-line
usually cannot be modified. This method must be called on the CEF UI thread.
</summary>
<param name="name">preference key</param>
<returns>Returns true if the preference with the specified name can be modified
using SetPreference</returns>
<remarks>Use Cef.UIThreadTaskFactory to execute this method if required,
<see cref="!:IBrowserProcessHandler.OnContextInitialized"/> and ChromiumWebBrowser.IsBrowserInitializedChanged are both
executed on the CEF UI thread, so can be called directly.
When CefSettings.MultiThreadedMessageLoop == false (the default is true) then the main
application thread will be the CEF UI thread.</remarks>
</member>
<member name="M:CefSharp.RequestContext.SetPreference(System.String,System.Object,System.String@)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContext.h" line="259">
<summary>
Set the value associated with preference name. If value is null the
preference will be restored to its default value. If setting the preference
fails then error will be populated with a detailed description of the
problem. This method must be called on the CEF UI thread.
Preferences set via the command-line usually cannot be modified.
</summary>
<param name="name">preference key</param>
<param name="value">preference value</param>
<param name="error">out error</param>
<returns>Returns true if the value is set successfully and false otherwise.</returns>
<remarks>Use Cef.UIThreadTaskFactory to execute this method if required,
<see cref="!:IBrowserProcessHandler.OnContextInitialized"/> and ChromiumWebBrowser.IsBrowserInitializedChanged are both
executed on the CEF UI thread, so can be called directly.
When CefSettings.MultiThreadedMessageLoop == false (the default is true) then the main
application thread will be the CEF UI thread.</remarks>
</member>
<member name="M:CefSharp.RequestContext.ClearCertificateExceptions(CefSharp.ICompletionCallback)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContext.h" line="277">
<summary>
Clears all certificate exceptions that were added as part of handling
<see cref="!:IRequestHandler.OnCertificateError"/>. If you call this it is
recommended that you also call <see cref="!:IRequestContext.CloseAllConnections"/> or you risk not
being prompted again for server certificates if you reconnect quickly.
</summary>
<param name="callback">If is non-NULL it will be executed on the CEF UI thread after
completion. This param is optional</param>
</member>
<member name="M:CefSharp.RequestContext.CloseAllConnections(CefSharp.ICompletionCallback)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContext.h" line="287">
<summary>
Clears all active and idle connections that Chromium currently has.
This is only recommended if you have released all other CEF objects but
don't yet want to call Cef.Shutdown().
</summary>
<param name="callback">If is non-NULL it will be executed on the CEF UI thread after
completion. This param is optional</param>
</member>
<member name="M:CefSharp.RequestContext.ResolveHostAsync(System.Uri)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContext.h" line="296">
<summary>
Attempts to resolve origin to a list of associated IP addresses.
</summary>
<param name="origin">host name to resolve</param>
<returns>A task that represents the Resoolve Host operation. The value of the TResult parameter contains ResolveCallbackResult.</returns>
</member>
<member name="M:CefSharp.RequestContext.DidLoadExtension(System.String)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContext.h" line="303">
<summary>
Returns true if this context was used to load the extension identified by extensionId. Other contexts sharing the same storage will also have access to the extension (see HasExtension).
This method must be called on the CEF UI thread.
</summary>
<returns>Returns true if this context was used to load the extension identified by extensionId</returns>
<remarks>Use Cef.UIThreadTaskFactory to execute this method if required,
<see cref="!:IBrowserProcessHandler.OnContextInitialized"/> and ChromiumWebBrowser.IsBrowserInitializedChanged are both
executed on the CEF UI thread, so can be called directly.
When CefSettings.MultiThreadedMessageLoop == false (the default is true) then the main
application thread will be the CEF UI thread.</remarks>
</member>
<member name="M:CefSharp.RequestContext.GetExtension(System.String)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContext.h" line="315">
<summary>
Returns the extension matching extensionId or null if no matching extension is accessible in this context (see HasExtension).
This method must be called on the CEF UI thread.
</summary>
<param name="extensionId">extension Id</param>
<returns>Returns the extension matching extensionId or null if no matching extension is accessible in this context</returns>
<remarks>Use Cef.UIThreadTaskFactory to execute this method if required,
<see cref="!:IBrowserProcessHandler.OnContextInitialized"/> and ChromiumWebBrowser.IsBrowserInitializedChanged are both
executed on the CEF UI thread, so can be called directly.
When CefSettings.MultiThreadedMessageLoop == false (the default is true) then the main
application thread will be the CEF UI thread.</remarks>
</member>
<member name="M:CefSharp.RequestContext.GetExtensions(System.Collections.Generic.IList`1{System.String}@)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContext.h" line="328">
<summary>
Retrieve the list of all extensions that this context has access to (see HasExtension).
<see cref="!:extensionIds"/> will be populated with the list of extension ID values.
This method must be called on the CEF UI thread.
</summary>
<param name="extensionIds">output a list of extensions Ids</param>
<returns>returns true on success otherwise false</returns>
<remarks>Use Cef.UIThreadTaskFactory to execute this method if required,
<see cref="!:IBrowserProcessHandler.OnContextInitialized"/> and ChromiumWebBrowser.IsBrowserInitializedChanged are both
executed on the CEF UI thread, so can be called directly.
When CefSettings.MultiThreadedMessageLoop == false (the default is true) then the main
application thread will be the CEF UI thread.</remarks>
</member>
<member name="M:CefSharp.RequestContext.HasExtension(System.String)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContext.h" line="342">
<summary>
Returns true if this context has access to the extension identified by extensionId.
This may not be the context that was used to load the extension (see DidLoadExtension).
This method must be called on the CEF UI thread.
</summary>
<param name="extensionId">extension id</param>
<returns>Returns true if this context has access to the extension identified by extensionId</returns>
<remarks>Use Cef.UIThreadTaskFactory to execute this method if required,
<see cref="!:IBrowserProcessHandler.OnContextInitialized"/> and ChromiumWebBrowser.IsBrowserInitializedChanged are both
executed on the CEF UI thread, so can be called directly.
When CefSettings.MultiThreadedMessageLoop == false (the default is true) then the main
application thread will be the CEF UI thread.</remarks>
</member>
<member name="M:CefSharp.RequestContext.LoadExtension(System.String,System.String,CefSharp.IExtensionHandler)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\RequestContext.h" line="356">
<summary>
Load an extension. If extension resources will be read from disk using the default load implementation then rootDirectoy
should be the absolute path to the extension resources directory and manifestJson should be null.
If extension resources will be provided by the client (e.g. via IRequestHandler and/or IExtensionHandler) then rootDirectory
should be a path component unique to the extension (if not absolute this will be internally prefixed with the PK_DIR_RESOURCES path)
and manifestJson should contain the contents that would otherwise be read from the "manifest.json" file on disk.
The loaded extension will be accessible in all contexts sharing the same storage (HasExtension returns true).
However, only the context on which this method was called is considered the loader (DidLoadExtension returns true) and only the
loader will receive IRequestContextHandler callbacks for the extension. <see cref="!:IExtensionHandler.OnExtensionLoaded"/> will be
called on load success or <see cref="!:IExtensionHandler.OnExtensionLoadFailed"/> will be called on load failure.
If the extension specifies a background script via the "background" manifest key then <see cref="!:IExtensionHandler.OnBeforeBackgroundBrowser"/>
will be called to create the background browser. See that method for additional information about background scripts.
For visible extension views the client application should evaluate the manifest to determine the correct extension URL to load and then pass
that URL to the IBrowserHost.CreateBrowser* function after the extension has loaded. For example, the client can look for the "browser_action"
manifest key as documented at https://developer.chrome.com/extensions/browserAction. Extension URLs take the form "chrome-extension:///".
Browsers that host extensions differ from normal browsers as follows: - Can access chrome.* JavaScript APIs if allowed by the manifest.
Visit chrome://extensions-support for the list of extension APIs currently supported by CEF. - Main frame navigation to non-extension
content is blocked.
- Pinch-zooming is disabled.
- <see cref="!:IBrowserHost.GetExtension"/> returns the hosted extension.
- CefBrowserHost::IsBackgroundHost returns true for background hosts. See https://developer.chrome.com/extensions for extension implementation and usage documentation.
</summary>
<param name="rootDirectory">If extension resources will be read from disk using the default load implementation then rootDirectoy
should be the absolute path to the extension resources directory and manifestJson should be null</param>
<param name="manifestJson">If extension resources will be provided by the client then rootDirectory should be a path component unique to the extension
and manifestJson should contain the contents that would otherwise be read from the manifest.json file on disk</param>
<param name="handler">handle events related to browser extensions</param>
</member>
<member name="M:CefParseURL(CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,CefStructBase&lt;CefURLPartsTraits&gt;*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_parser.h" line="46">


</member>
<member name="M:CefCreateURL(CefStructBase&lt;CefURLPartsTraits&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,CefStringBase&lt;CefStringTraitsUTF16&gt;*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_parser.h" line="53">


</member>
<member name="M:CefFormatUrlForSecurityDisplay(CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_parser.h" line="61">


</member>
<member name="M:CefGetMimeType(CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_parser.h" line="74">


</member>
<member name="M:CefGetExtensionsForMimeType(CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,std.vector&lt;CefStringBase&lt;CefStringTraitsUTF16&gt;,std.allocator&lt;CefStringBase&lt;CefStringTraitsUTF16&gt;&gt;&gt;*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_parser.h" line="81">


</member>
<member name="M:CefBase64Encode(System.Void!System.Runtime.CompilerServices.IsConst*,System.UInt32)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_parser.h" line="91">


</member>
<member name="M:CefBase64Decode(CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_parser.h" line="97">


</member>
<member name="M:CefURIEncode(CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,System.Boolean)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_parser.h" line="104">


</member>
<member name="M:CefURIDecode(CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,System.Boolean,cef_uri_unescape_rule_t)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_parser.h" line="113">


</member>
<member name="M:CefParseJSON(CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,cef_json_parser_options_t)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_parser.h" line="128">


</member>
<member name="M:CefParseJSONAndReturnError(CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,cef_json_parser_options_t,cef_json_parser_error_t*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,CefStringBase&lt;CefStringTraitsUTF16&gt;*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_parser.h" line="136">


</member>
<member name="M:CefWriteJSON(scoped_refptr&lt;CefValue&gt;,cef_json_writer_options_t)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_parser.h" line="149">


</member>
<member name="M:cef_get_current_platform_thread_id" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\internal\cef_thread_internal.h" line="55">


</member>
<member name="M:cef_get_current_platform_thread_handle" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\internal\cef_thread_internal.h" line="68">


</member>
<member name="M:CefCreateClosureTask(base.Callback&lt;(void)&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\wrapper\cef_closure_task.h" line="44">




</member>
<member name="M:CefPostTask(cef_thread_id_t,base.Callback&lt;(void)&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\wrapper\cef_closure_task.h" line="90">


</member>
<member name="M:CefPostDelayedTask(cef_thread_id_t,base.Callback&lt;(void)&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,System.Int64)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\wrapper\cef_closure_task.h" line="95">


</member>
<member name="M:CefRegisterSchemeHandlerFactory(CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,scoped_refptr&lt;CefSchemeHandlerFactory&gt;)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_scheme.h" line="50">


</member>
<member name="M:CefClearSchemeHandlerFactories" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_scheme.h" line="70">


</member>
<member name="T:CefSchemeRegistrar" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_scheme.h" line="79">


</member>
<member name="M:CefSchemeRegistrar.AddCustomScheme(CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,System.Int32)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_scheme.h" line="85">


</member>
<member name="T:CefSchemeHandlerFactory" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_scheme.h" line="99">


</member>
<member name="M:CefSchemeHandlerFactory.Create(scoped_refptr&lt;CefBrowser&gt;,scoped_refptr&lt;CefFrame&gt;,CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,scoped_refptr&lt;CefRequest&gt;)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_scheme.h" line="106">


</member>
<member name="T:CefStreamResourceHandler" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\wrapper\cef_stream_resource_handler.h" line="49">


</member>
<member name="M:CefStreamResourceHandler.#ctor(CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,scoped_refptr&lt;CefStreamReader&gt;)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\wrapper\cef_stream_resource_handler.h" line="54">


</member>
<member name="M:CefStreamResourceHandler.#ctor(System.Int32,CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,std.multimap&lt;CefStringBase&lt;CefStringTraitsUTF16&gt;,CefStringBase&lt;CefStringTraitsUTF16&gt;,std.less&lt;CefStringBase&lt;CefStringTraitsUTF16&gt;&gt;,std.allocator&lt;std.pair&lt;CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst,CefStringBase&lt;CefStringTraitsUTF16&gt;&gt;&gt;&gt;,scoped_refptr&lt;CefStreamReader&gt;)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\wrapper\cef_stream_resource_handler.h" line="59">


</member>
<member name="M:CefSharp.Internals.CefSharpBrowserWrapper.GetHost" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefSharpBrowserWrapper.h" line="48">


</member>
<member name="P:CefSharp.Internals.CefSharpBrowserWrapper.CanGoBack" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefSharpBrowserWrapper.h" line="55">


</member>
<member name="M:CefSharp.Internals.CefSharpBrowserWrapper.GoBack" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefSharpBrowserWrapper.h" line="64">


</member>
<member name="P:CefSharp.Internals.CefSharpBrowserWrapper.CanGoForward" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefSharpBrowserWrapper.h" line="70">


</member>
<member name="M:CefSharp.Internals.CefSharpBrowserWrapper.GoForward" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefSharpBrowserWrapper.h" line="79">


</member>
<member name="P:CefSharp.Internals.CefSharpBrowserWrapper.IsLoading" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefSharpBrowserWrapper.h" line="85">


</member>
<member name="M:CefSharp.Internals.CefSharpBrowserWrapper.Reload(System.Boolean)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefSharpBrowserWrapper.h" line="96">


</member>
<member name="M:CefSharp.Internals.CefSharpBrowserWrapper.StopLoad" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefSharpBrowserWrapper.h" line="102">


</member>
<member name="P:CefSharp.Internals.CefSharpBrowserWrapper.Identifier" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefSharpBrowserWrapper.h" line="108">


</member>
<member name="M:CefSharp.Internals.CefSharpBrowserWrapper.IsSame(CefSharp.IBrowser)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefSharpBrowserWrapper.h" line="117">


</member>
<member name="P:CefSharp.Internals.CefSharpBrowserWrapper.IsPopup" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefSharpBrowserWrapper.h" line="124">


</member>
<member name="P:CefSharp.Internals.CefSharpBrowserWrapper.HasDocument" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefSharpBrowserWrapper.h" line="133">


</member>
<member name="P:CefSharp.Internals.CefSharpBrowserWrapper.MainFrame" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefSharpBrowserWrapper.h" line="142">


</member>
<member name="P:CefSharp.Internals.CefSharpBrowserWrapper.FocusedFrame" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefSharpBrowserWrapper.h" line="151">


</member>
<member name="M:CefSharp.Internals.CefSharpBrowserWrapper.GetFrame(System.Int64)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefSharpBrowserWrapper.h" line="160">


</member>
<member name="M:CefSharp.Internals.CefSharpBrowserWrapper.GetFrame(System.String)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefSharpBrowserWrapper.h" line="166">


</member>
<member name="M:CefSharp.Internals.CefSharpBrowserWrapper.GetFrameCount" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefSharpBrowserWrapper.h" line="172">


</member>
<member name="M:CefSharp.Internals.CefSharpBrowserWrapper.GetFrameIdentifiers" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefSharpBrowserWrapper.h" line="178">


</member>
<member name="M:CefSharp.Internals.CefSharpBrowserWrapper.GetFrameNames" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefSharpBrowserWrapper.h" line="184">


</member>
<member name="T:CefSharp.Internals.CefFrameWrapper" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="19">


</member>
<member name="P:CefSharp.Internals.CefFrameWrapper.IsValid" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="59">


</member>
<member name="M:CefSharp.Internals.CefFrameWrapper.Undo" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="68">


</member>
<member name="M:CefSharp.Internals.CefFrameWrapper.Redo" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="74">


</member>
<member name="M:CefSharp.Internals.CefFrameWrapper.Cut" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="80">


</member>
<member name="M:CefSharp.Internals.CefFrameWrapper.Copy" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="86">


</member>
<member name="M:CefSharp.Internals.CefFrameWrapper.Paste" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="92">


</member>
<member name="M:CefSharp.Internals.CefFrameWrapper.Delete" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="98">


</member>
<member name="M:CefSharp.Internals.CefFrameWrapper.SelectAll" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="104">


</member>
<member name="M:CefSharp.Internals.CefFrameWrapper.ViewSource" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="110">


</member>
<member name="M:CefSharp.Internals.CefFrameWrapper.GetSourceAsync" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="118">


</member>
<member name="M:CefSharp.Internals.CefFrameWrapper.GetSource(CefSharp.IStringVisitor)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="125">


</member>
<member name="M:CefSharp.Internals.CefFrameWrapper.GetTextAsync" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="132">


</member>
<member name="M:CefSharp.Internals.CefFrameWrapper.GetText(CefSharp.IStringVisitor)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="139">


</member>
<member name="M:CefSharp.Internals.CefFrameWrapper.LoadRequest(CefSharp.IRequest)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="146">

Load the request represented by the |request| object.

</member>
<member name="M:CefSharp.Internals.CefFrameWrapper.LoadUrl(System.String)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="152">


</member>
<member name="M:CefSharp.Internals.CefFrameWrapper.LoadStringForUrl(System.String,System.String)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="158">


</member>
<member name="M:CefSharp.Internals.CefFrameWrapper.ExecuteJavaScriptAsync(System.String,System.String,System.Int32)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="166">


</member>
<member name="P:CefSharp.Internals.CefFrameWrapper.IsMain" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="178">


</member>
<member name="P:CefSharp.Internals.CefFrameWrapper.IsFocused" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="187">


</member>
<member name="P:CefSharp.Internals.CefFrameWrapper.Name" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="196">


</member>
<member name="P:CefSharp.Internals.CefFrameWrapper.Identifier" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="209">


</member>
<member name="P:CefSharp.Internals.CefFrameWrapper.Parent" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="218">


</member>
<member name="P:CefSharp.Internals.CefFrameWrapper.Url" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="228">


</member>
<member name="P:CefSharp.Internals.CefFrameWrapper.Browser" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="237">


</member>
<member name="M:CefSharp.Internals.CefFrameWrapper.GetV8Context" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="246">


</member>
<member name="M:CefSharp.Internals.CefFrameWrapper.CreateUrlRequest(CefSharp.IRequest,CefSharp.IUrlRequestClient)" decl="true" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefFrameWrapper.h" line="258">


</member>
<member name="T:CefDownloadItem" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_item.h" line="43">


</member>
<member name="M:CefDownloadItem.IsValid" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_item.h" line="49">


</member>
<member name="M:CefDownloadItem.IsInProgress" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_item.h" line="56">


</member>
<member name="M:CefDownloadItem.IsComplete" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_item.h" line="62">


</member>
<member name="M:CefDownloadItem.IsCanceled" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_item.h" line="68">


</member>
<member name="M:CefDownloadItem.GetCurrentSpeed" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_item.h" line="74">


</member>
<member name="M:CefDownloadItem.GetPercentComplete" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_item.h" line="80">


</member>
<member name="M:CefDownloadItem.GetTotalBytes" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_item.h" line="87">


</member>
<member name="M:CefDownloadItem.GetReceivedBytes" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_item.h" line="93">


</member>
<member name="M:CefDownloadItem.GetStartTime" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_item.h" line="99">


</member>
<member name="M:CefDownloadItem.GetEndTime" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_item.h" line="105">


</member>
<member name="M:CefDownloadItem.GetFullPath" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_item.h" line="111">


</member>
<member name="M:CefDownloadItem.GetId" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_item.h" line="117">


</member>
<member name="M:CefDownloadItem.GetURL" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_item.h" line="123">


</member>
<member name="M:CefDownloadItem.GetOriginalUrl" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_item.h" line="129">


</member>
<member name="M:CefDownloadItem.GetSuggestedFileName" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_item.h" line="135">


</member>
<member name="M:CefDownloadItem.GetContentDisposition" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_item.h" line="141">


</member>
<member name="M:CefDownloadItem.GetMimeType" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_item.h" line="147">


</member>
<member name="T:CefSharp.BrowserSettings" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="13">
<summary>
Browser initialization settings. Specify NULL or 0 to get the recommended
default values. The consequences of using custom values may not be well
tested. Many of these and other settings can also configured using command-
line switches.
</summary>
</member>
<member name="M:CefSharp.BrowserSettings.#ctor(CefStructBase&lt;CefBrowserSettingsTraits&gt;*)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="28">
<summary>
Internal Constructor
</summary>
</member>
<member name="M:CefSharp.BrowserSettings.#ctor" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="43">
<summary>
Default Constructor
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.StandardFontFamily" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="67">
<summary>
StandardFontFamily
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.FixedFontFamily" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="76">
<summary>
FixedFontFamily
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.SerifFontFamily" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="85">
<summary>
SerifFontFamily
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.SansSerifFontFamily" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="94">
<summary>
SansSerifFontFamily
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.CursiveFontFamily" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="103">
<summary>
CursiveFontFamily
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.FantasyFontFamily" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="112">
<summary>
FantasyFontFamily
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.DefaultFontSize" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="121">
<summary>
DefaultFontSize
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.DefaultFixedFontSize" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="130">
<summary>
DefaultFixedFontSize
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.MinimumFontSize" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="139">
<summary>
MinimumFontSize
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.MinimumLogicalFontSize" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="148">
<summary>
MinimumLogicalFontSize
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.DefaultEncoding" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="157">
<summary>
Default encoding for Web content. If empty "ISO-8859-1" will be used. Also
configurable using the "default-encoding" command-line switch.
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.RemoteFonts" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="167">
<summary>
Controls the loading of fonts from remote sources. Also configurable using
the "disable-remote-fonts" command-line switch.
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.Javascript" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="177">
<summary>
Controls whether JavaScript can be executed. (Used to Enable/Disable javascript)
Also configurable using the "disable-javascript" command-line switch.
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.JavascriptCloseWindows" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="187">
<summary>
Controls whether JavaScript can be used to close windows that were not
opened via JavaScript. JavaScript can still be used to close windows that
were opened via JavaScript. Also configurable using the
"disable-javascript-close-windows" command-line switch.
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.JavascriptAccessClipboard" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="199">
<summary>
Controls whether JavaScript can access the clipboard. Also configurable
using the "disable-javascript-access-clipboard" command-line switch.
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.JavascriptDomPaste" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="209">
<summary>
Controls whether DOM pasting is supported in the editor via
execCommand("paste"). The |javascript_access_clipboard| setting must also
be enabled. Also configurable using the "disable-javascript-dom-paste"
command-line switch.
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.Plugins" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="221">
<summary>
Controls whether any plugins will be loaded. Also configurable using the
"disable-plugins" command-line switch.
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.UniversalAccessFromFileUrls" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="231">
<summary>
Controls whether file URLs will have access to all URLs. Also configurable
using the "allow-universal-access-from-files" command-line switch.
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.FileAccessFromFileUrls" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="241">
<summary>
Controls whether file URLs will have access to other file URLs. Also
configurable using the "allow-access-from-files" command-line switch.
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.WebSecurity" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="251">
<summary>
Controls whether web security restrictions (same-origin policy) will be
enforced. Disabling this setting is not recommend as it will allow risky
security behavior such as cross-site scripting (XSS). Also configurable
using the "disable-web-security" command-line switch.
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.ImageLoading" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="263">
<summary>
Controls whether image URLs will be loaded from the network. A cached image
will still be rendered if requested. Also configurable using the
"disable-image-loading" command-line switch.
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.ImageShrinkStandaloneToFit" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="274">
<summary>
Controls whether standalone images will be shrunk to fit the page. Also
configurable using the "image-shrink-standalone-to-fit" command-line
switch.
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.TextAreaResize" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="285">
<summary>
Controls whether text areas can be resized. Also configurable using the
"disable-text-area-resize" command-line switch.
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.TabToLinks" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="295">
<summary>
Controls whether the tab key can advance focus to links. Also configurable
using the "disable-tab-to-links" command-line switch.
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.LocalStorage" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="305">
<summary>
Controls whether local storage can be used. Also configurable using the
"disable-local-storage" command-line switch.
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.Databases" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="315">
<summary>
Controls whether databases can be used. Also configurable using the
"disable-databases" command-line switch.
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.ApplicationCache" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="325">
<summary>
Controls whether the application cache can be used. Also configurable using
the "disable-application-cache" command-line switch.
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.WebGl" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="335">
<summary>
Controls whether WebGL can be used. Note that WebGL requires hardware
support and may not work on all systems even when enabled. Also
configurable using the "disable-webgl" command-line switch.
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.BackgroundColor" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="346">
<summary>
Background color used for the browser before a document is loaded and when no document color
is specified. The alpha component must be either fully opaque (0xFF) or fully transparent (0x00).
If the alpha component is fully opaque then the RGB components will be used as the background
color. If the alpha component is fully transparent for a WinForms browser then the
CefSettings.BackgroundColor value will be used. If the alpha component is fully transparent
for a windowless (WPF/OffScreen) browser then transparent painting will be enabled.
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.AcceptLanguageList" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="360">
<summary>
Comma delimited ordered list of language codes without any whitespace that
will be used in the "Accept-Language" HTTP header. May be overridden on a
per-browser basis using the CefBrowserSettings.AcceptLanguageList value.
If both values are empty then "en-US,en" will be used. Can be overridden
for individual RequestContext instances via the
RequestContextSettings.AcceptLanguageList value.
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.WindowlessFrameRate" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="374">
<summary>
The maximum rate in frames per second (fps) that CefRenderHandler::OnPaint
will be called for a windowless browser. The actual fps may be lower if
the browser cannot generate frames at the requested rate. The minimum
value is 1 and the maximum value is 60 (default 30). This value can also be
changed dynamically via IBrowserHost.SetWindowlessFrameRate.
</summary>
</member>
<member name="P:CefSharp.BrowserSettings.IsDisposed" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\BrowserSettings.h" line="387">
<summary>
Gets a value indicating if the browser settings has been disposed.
</summary>
</member>
<member name="T:CefBeforeDownloadCallback" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_handler.h" line="45">


</member>
<member name="M:CefBeforeDownloadCallback.Continue(CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,System.Boolean)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_handler.h" line="51">


</member>
<member name="T:CefDownloadItemCallback" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_handler.h" line="61">


</member>
<member name="M:CefDownloadItemCallback.Cancel" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_handler.h" line="67">


</member>
<member name="M:CefDownloadItemCallback.Pause" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_handler.h" line="73">


</member>
<member name="M:CefDownloadItemCallback.Resume" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_handler.h" line="79">


</member>
<member name="T:CefDownloadHandler" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_handler.h" line="86">


</member>
<member name="M:CefDownloadHandler.OnBeforeDownload(scoped_refptr&lt;CefBrowser&gt;,scoped_refptr&lt;CefDownloadItem&gt;,CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,scoped_refptr&lt;CefBeforeDownloadCallback&gt;)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_handler.h" line="93">


</member>
<member name="M:CefDownloadHandler.OnDownloadUpdated(scoped_refptr&lt;CefBrowser&gt;,scoped_refptr&lt;CefDownloadItem&gt;,scoped_refptr&lt;CefDownloadItemCallback&gt;)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\packages\cef.sdk.75.1.14\CEF\include\cef_download_handler.h" line="107">


</member>
<member name="M:CefSharp.Internals.CefExtensionHandlerAdapter.OnExtensionLoadFailed(cef_errorcode_t)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefExtensionHandlerAdapter.h" line="39">


</member>
<member name="M:CefSharp.Internals.CefExtensionHandlerAdapter.OnExtensionLoaded(scoped_refptr&lt;CefExtension&gt;)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefExtensionHandlerAdapter.h" line="49">


</member>
<member name="M:CefSharp.Internals.CefExtensionHandlerAdapter.OnExtensionUnloaded(scoped_refptr&lt;CefExtension&gt;)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefExtensionHandlerAdapter.h" line="60">


</member>
<member name="M:CefSharp.Internals.CefExtensionHandlerAdapter.OnBeforeBackgroundBrowser(scoped_refptr&lt;CefExtension&gt;,CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,scoped_refptr&lt;CefClient&gt;*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,CefStructBase&lt;CefBrowserSettingsTraits&gt;*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefExtensionHandlerAdapter.h" line="72">


</member>
<member name="M:CefSharp.Internals.CefExtensionHandlerAdapter.OnBeforeBrowser(scoped_refptr&lt;CefExtension&gt;,scoped_refptr&lt;CefBrowser&gt;,scoped_refptr&lt;CefBrowser&gt;,System.Int32,CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,System.Boolean,CefWindowInfo*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,scoped_refptr&lt;CefClient&gt;*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,CefStructBase&lt;CefBrowserSettingsTraits&gt;*!System.Runtime.CompilerServices.IsImplicitlyDereferenced)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefExtensionHandlerAdapter.h" line="100">


</member>
<member name="M:CefSharp.Internals.CefExtensionHandlerAdapter.GetActiveBrowser(scoped_refptr&lt;CefExtension&gt;,scoped_refptr&lt;CefBrowser&gt;,System.Boolean)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefExtensionHandlerAdapter.h" line="137">


</member>
<member name="M:CefSharp.Internals.CefExtensionHandlerAdapter.CanAccessBrowser(scoped_refptr&lt;CefExtension&gt;,scoped_refptr&lt;CefBrowser&gt;,System.Boolean,scoped_refptr&lt;CefBrowser&gt;)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefExtensionHandlerAdapter.h" line="168">


</member>
<member name="M:CefSharp.Internals.CefExtensionHandlerAdapter.GetExtensionResource(scoped_refptr&lt;CefExtension&gt;,scoped_refptr&lt;CefBrowser&gt;,CefStringBase&lt;CefStringTraitsUTF16&gt;!System.Runtime.CompilerServices.IsConst*!System.Runtime.CompilerServices.IsImplicitlyDereferenced,scoped_refptr&lt;CefGetExtensionResourceCallback&gt;)" decl="false" source="D:\Projects\Cef\CefSharp-75.1.143\CefSharp.Core\Internals\CefExtensionHandlerAdapter.h" line="188">


</member>
</members>
</doc>