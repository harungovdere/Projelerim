#pragma checksum "C:\Users\HARUN\source\repos\FiloKiralama_Api\FiloKiralama_UI\Views\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9f6b0401042a34f81e248063300dc0d16d161ff0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Index), @"mvc.1.0.view", @"/Views/Admin/Index.cshtml")]
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
#line 1 "C:\Users\HARUN\source\repos\FiloKiralama_Api\FiloKiralama_UI\Views\_ViewImports.cshtml"
using FiloKiralama_UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HARUN\source\repos\FiloKiralama_Api\FiloKiralama_UI\Views\_ViewImports.cshtml"
using FiloKiralama_UI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HARUN\source\repos\FiloKiralama_Api\FiloKiralama_UI\Views\_ViewImports.cshtml"
using FiloKiralama_UI.Dtos.CarDtos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HARUN\source\repos\FiloKiralama_Api\FiloKiralama_UI\Views\_ViewImports.cshtml"
using FiloKiralama_UI.Dtos.InsuranceDtos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HARUN\source\repos\FiloKiralama_Api\FiloKiralama_UI\Views\_ViewImports.cshtml"
using FiloKiralama_UI.Dtos.BrandsDtos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HARUN\source\repos\FiloKiralama_Api\FiloKiralama_UI\Views\_ViewImports.cshtml"
using FiloKiralama_UI.Dtos.ModelsDtos;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f6b0401042a34f81e248063300dc0d16d161ff0", @"/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de8d307a536c50e24b1bfc6c2af094f9a99398a0", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\HARUN\source\repos\FiloKiralama_Api\FiloKiralama_UI\Views\Admin\Index.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n");
#nullable restore
#line 9 "C:\Users\HARUN\source\repos\FiloKiralama_Api\FiloKiralama_UI\Views\Admin\Index.cshtml"
Write(await Component.InvokeAsync("_AdminLayoutHeadComponentPartial"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9f6b0401042a34f81e248063300dc0d16d161ff04481", async() => {
                WriteLiteral("\r\n\r\n    <div class=\"container-fluid position-relative bg-white d-flex p-0\">\r\n\r\n        <!-- Spinner Start -->\r\n        ");
#nullable restore
#line 16 "C:\Users\HARUN\source\repos\FiloKiralama_Api\FiloKiralama_UI\Views\Admin\Index.cshtml"
   Write(await Component.InvokeAsync("_AdminLayoutSpinnerComponentPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        <!-- Spinner End -->\r\n        <!-- Sidebar Start -->\r\n        ");
#nullable restore
#line 19 "C:\Users\HARUN\source\repos\FiloKiralama_Api\FiloKiralama_UI\Views\Admin\Index.cshtml"
   Write(await Component.InvokeAsync("_AdminLayoutSidebarComponentPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        <!-- Sidebar End -->\r\n        <!-- Content Start -->\r\n        <div class=\"content\">\r\n            <!-- Navbar Start -->\r\n            ");
#nullable restore
#line 24 "C:\Users\HARUN\source\repos\FiloKiralama_Api\FiloKiralama_UI\Views\Admin\Index.cshtml"
       Write(await Component.InvokeAsync("_AdminLayoutNavbarComponentPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            <!-- Navbar End -->\r\n            <!-- Blank Start -->\r\n            ");
#nullable restore
#line 27 "C:\Users\HARUN\source\repos\FiloKiralama_Api\FiloKiralama_UI\Views\Admin\Index.cshtml"
       Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n            <!-- Blank End -->\r\n            <!-- Footer Start -->\r\n            ");
#nullable restore
#line 31 "C:\Users\HARUN\source\repos\FiloKiralama_Api\FiloKiralama_UI\Views\Admin\Index.cshtml"
       Write(await Component.InvokeAsync("_AdminLayoutFooterComponentPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            <!-- Footer End -->
        </div>
        <!-- Content End -->
        <!-- Back to Top -->
        <a href=""#"" class=""btn btn-lg btn-primary btn-lg-square back-to-top""><i class=""bi bi-arrow-up""></i></a>
    </div>

    <!-- JavaScript Libraries -->
    ");
#nullable restore
#line 40 "C:\Users\HARUN\source\repos\FiloKiralama_Api\FiloKiralama_UI\Views\Admin\Index.cshtml"
Write(await Component.InvokeAsync("_AdminLayoutScriptComponentPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
