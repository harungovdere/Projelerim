#pragma checksum "C:\Users\HARUN\source\repos\FiloKiralama_Api\FiloKiralama_UI\Views\Shared\Components\_ContactViewComponentPartial\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13eaf4d77246a0139480e89e0683aa9925b1f099"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components__ContactViewComponentPartial_Default), @"mvc.1.0.view", @"/Views/Shared/Components/_ContactViewComponentPartial/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13eaf4d77246a0139480e89e0683aa9925b1f099", @"/Views/Shared/Components/_ContactViewComponentPartial/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de8d307a536c50e24b1bfc6c2af094f9a99398a0", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components__ContactViewComponentPartial_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!-- Contact Start -->
<div class=""container-fluid py-5"">
    <div class=""container pt-5 pb-3"">
        <h1 class=""display-4 text-uppercase text-center mb-5"">Bize Ulaşın</h1>
        <div class=""row"">
            <div class=""col-lg-7 mb-2"">
                <div class=""contact-form bg-light mb-4"" style=""padding: 30px;"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13eaf4d77246a0139480e89e0683aa9925b1f0994649", async() => {
                WriteLiteral(@"
                        <div class=""row"">
                            <div class=""col-6 form-group"">
                                <input type=""text"" class=""form-control p-4"" placeholder=""Adınız"" required=""required"">
                            </div>
                            <div class=""col-6 form-group"">
                                <input type=""email"" class=""form-control p-4"" placeholder=""Maili adresiniz"" required=""required"">
                            </div>
                        </div>
                        <div class=""form-group"">
                            <input type=""text"" class=""form-control p-4"" placeholder=""Konu"" required=""required"">
                        </div>
                        <div class=""form-group"">
                            <textarea class=""form-control py-3 px-4"" rows=""5"" placeholder=""Message"" required=""required""></textarea>
                        </div>
                        <div>
                            <button class=""btn btn-primary py-3 px");
                WriteLiteral("-5\" type=\"submit\">Mesaj Gönder</button>\r\n                        </div>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
            </div>
            <div class=""col-lg-5 mb-2"">
                <div class=""bg-secondary d-flex flex-column justify-content-center px-5 mb-4"" style=""height: 435px;"">
                    <div class=""d-flex mb-3"">
                        <i class=""fa fa-2x fa-map-marker-alt text-primary flex-shrink-0 mr-3""></i>
                        <div class=""mt-n1"">
                            <h5 class=""text-light"">Genel Merkez</h5>
                            <p>123 Street, New York, USA</p>
                        </div>
                    </div>
                    <div class=""d-flex mb-3"">
                        <i class=""fa fa-2x fa-map-marker-alt text-primary flex-shrink-0 mr-3""></i>
                        <div class=""mt-n1"">
                            <h5 class=""text-light"">Şube Adresimiz</h5>
                            <p>123 Street, New York, USA</p>
                        </div>
                    </div>
                    <div class=""d-flex mb-3"">
 ");
            WriteLiteral(@"                       <i class=""fa fa-2x fa-envelope-open text-primary flex-shrink-0 mr-3""></i>
                        <div class=""mt-n1"">
                            <h5 class=""text-light"">Müşteri Hizmetleri</h5>
                            <p>customer@example.com</p>
                        </div>
                    </div>
                    <div class=""d-flex"">
                        <i class=""fa fa-2x fa-envelope-open text-primary flex-shrink-0 mr-3""></i>
                        <div class=""mt-n1"">
                            <h5 class=""text-light"">Geri Ödeme İadesi</h5>
                            <p class=""m-0"">refund@example.com</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Contact End -->");
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
