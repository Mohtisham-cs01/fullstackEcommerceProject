#pragma checksum "C:\Users\AR Computers\Downloads\WatchSpace(1)\WatchSpace\WatchSpace\Views\Admin\Message.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "058d2f9d4916b2b417dcb5acd6cac9b71909ee8a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Message), @"mvc.1.0.view", @"/Views/Admin/Message.cshtml")]
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
#line 1 "C:\Users\AR Computers\Downloads\WatchSpace(1)\WatchSpace\WatchSpace\Views\Admin\Message.cshtml"
using WatchSpace.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"058d2f9d4916b2b417dcb5acd6cac9b71909ee8a", @"/Views/Admin/Message.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"370b43369155ec52fccdd22dd1e202675e8c28d4", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_Message : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ContactUs>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\AR Computers\Downloads\WatchSpace(1)\WatchSpace\WatchSpace\Views\Admin\Message.cshtml"
  
    Layout = "~/Views/Shared/_AdminLayout.cshtml";
    ViewData["Title"] = "Notifications";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2 class=""text-center"">Message</h2>

<div class=""row mt-5"">
    <div class=""col-sm-12"">
        <table id=""messageDatatable"" class=""table table-bordered"">
            <thead>
                <tr>
                    <th class=""text-center"">Name</th>
                    <th class=""text-center"">Phone Number</th>
                    <th class=""text-center"">Email</th>
                    <th class=""text-center"">Message</th>
                    <th class=""text-center"">Date</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 25 "C:\Users\AR Computers\Downloads\WatchSpace(1)\WatchSpace\WatchSpace\Views\Admin\Message.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td class=\"text-center\">");
#nullable restore
#line 28 "C:\Users\AR Computers\Downloads\WatchSpace(1)\WatchSpace\WatchSpace\Views\Admin\Message.cshtml"
                                           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-center\">");
#nullable restore
#line 29 "C:\Users\AR Computers\Downloads\WatchSpace(1)\WatchSpace\WatchSpace\Views\Admin\Message.cshtml"
                                           Write(item.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-center\">");
#nullable restore
#line 30 "C:\Users\AR Computers\Downloads\WatchSpace(1)\WatchSpace\WatchSpace\Views\Admin\Message.cshtml"
                                           Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-center\">");
#nullable restore
#line 31 "C:\Users\AR Computers\Downloads\WatchSpace(1)\WatchSpace\WatchSpace\Views\Admin\Message.cshtml"
                                           Write(item.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-center\">");
#nullable restore
#line 32 "C:\Users\AR Computers\Downloads\WatchSpace(1)\WatchSpace\WatchSpace\Views\Admin\Message.cshtml"
                                           Write(item.Date.ToString("dddd, dd MMMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 34 "C:\Users\AR Computers\Downloads\WatchSpace(1)\WatchSpace\WatchSpace\Views\Admin\Message.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "058d2f9d4916b2b417dcb5acd6cac9b71909ee8a6787", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<script>

    $(document).ready(function () {
        $('#messageDatatable').DataTable({
            ""ordering"": false,
            ""language"": {
                ""lengthMenu"": ""Show _MENU_""
            },
            ""lengthMenu"": [10, 25, 50, 75, 100] // Remove the `Entries` text in pages filter
        });

    });

</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ContactUs>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
