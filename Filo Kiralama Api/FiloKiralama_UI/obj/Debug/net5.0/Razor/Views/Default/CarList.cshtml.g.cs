#pragma checksum "C:\Users\HARUN\source\repos\FiloKiralama_Api\FiloKiralama_UI\Views\Default\CarList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "225d264d3fdfd59063af2920c246e68b21eb690a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Default_CarList), @"mvc.1.0.view", @"/Views/Default/CarList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"225d264d3fdfd59063af2920c246e68b21eb690a", @"/Views/Default/CarList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de8d307a536c50e24b1bfc6c2af094f9a99398a0", @"/Views/_ViewImports.cshtml")]
    public class Views_Default_CarList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 3 "C:\Users\HARUN\source\repos\FiloKiralama_Api\FiloKiralama_UI\Views\Default\CarList.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<html lang=\"tr\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "225d264d3fdfd59063af2920c246e68b21eb690a4352", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 10 "C:\Users\HARUN\source\repos\FiloKiralama_Api\FiloKiralama_UI\Views\Default\CarList.cshtml"
Write(await Component.InvokeAsync("_HeadViewComponentPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "225d264d3fdfd59063af2920c246e68b21eb690a5602", async() => {
                WriteLiteral("\r\n\r\n    <!-- Topbar Start -->\r\n    <!-- Navbar Start -->\r\n    ");
#nullable restore
#line 17 "C:\Users\HARUN\source\repos\FiloKiralama_Api\FiloKiralama_UI\Views\Default\CarList.cshtml"
Write(await Component.InvokeAsync("_NavbarViewComponentPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <!-- Topbar End -->\r\n    <!-- Navbar End -->\r\n    <!-- Rent a car Start -->\r\n    ");
#nullable restore
#line 21 "C:\Users\HARUN\source\repos\FiloKiralama_Api\FiloKiralama_UI\Views\Default\CarList.cshtml"
Write(await Component.InvokeAsync("_CarListViewComponentPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <!-- Rent a car End -->\r\n    <!-- Footer Start -->\r\n    ");
#nullable restore
#line 24 "C:\Users\HARUN\source\repos\FiloKiralama_Api\FiloKiralama_UI\Views\Default\CarList.cshtml"
Write(await Component.InvokeAsync("_FooterViewComponentPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <!-- Footer End -->\r\n    <!-- Back to Top -->\r\n    <a href=\"#\" class=\"btn btn-lg btn-primary btn-lg-square back-to-top\"><i class=\"fa fa-angle-double-up\"></i></a>\r\n\r\n\r\n    <!-- JavaScript Libraries -->\r\n    ");
#nullable restore
#line 31 "C:\Users\HARUN\source\repos\FiloKiralama_Api\FiloKiralama_UI\Views\Default\CarList.cshtml"
Write(await Component.InvokeAsync("_ScriptViewComponentPartial"));

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