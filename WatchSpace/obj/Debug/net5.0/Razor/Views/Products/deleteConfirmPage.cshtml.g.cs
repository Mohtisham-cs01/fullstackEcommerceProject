#pragma checksum "C:\Users\AR Computers\Downloads\WatchSpace(1)\WatchSpace\WatchSpace\Views\Products\deleteConfirmPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8df3a94ff10cdf9c437afec2afb62b13f73799f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_deleteConfirmPage), @"mvc.1.0.view", @"/Views/Products/deleteConfirmPage.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\AR Computers\Downloads\WatchSpace(1)\WatchSpace\WatchSpace\Views\_ViewImports.cshtml"
using WatchSpace;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\AR Computers\Downloads\WatchSpace(1)\WatchSpace\WatchSpace\Views\_ViewImports.cshtml"
using WatchSpace.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8df3a94ff10cdf9c437afec2afb62b13f73799f9", @"/Views/Products/deleteConfirmPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"370b43369155ec52fccdd22dd1e202675e8c28d4", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Products_deleteConfirmPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WatchSpace.Models.Product>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\AR Computers\Downloads\WatchSpace(1)\WatchSpace\WatchSpace\Views\Products\deleteConfirmPage.cshtml"
  
    Layout = "~/Views/Shared/_AdminLayout.cshtml";
    var count = ViewBag.count;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n<div class=\"alert alert-success mb-5\" role=\"alert\" style=\" color: #856404; background-color: #fff3cd; border-color: #ffeeba; \">\r\n    <h4 class=\"alert-heading\">Alert!</h4>\r\n    <h1>This products has been ordered ");
#nullable restore
#line 13 "C:\Users\AR Computers\Downloads\WatchSpace(1)\WatchSpace\WatchSpace\Views\Products\deleteConfirmPage.cshtml"
                                  Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" times , deletion will cause error in genrating reports!</h1>\r\n\r\n</div>\r\n\r\n<button class=\"btn btn-primary\" onclick=\"goBack()\">Go Back</button>\r\n<script>\r\n    function goBack() {\r\n        window.history.back();\r\n    }\r\n</script>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WatchSpace.Models.Product> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
