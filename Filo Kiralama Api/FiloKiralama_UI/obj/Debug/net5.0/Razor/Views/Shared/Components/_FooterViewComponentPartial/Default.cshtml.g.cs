#pragma checksum "C:\Users\HARUN\source\repos\FiloKiralama_Api\FiloKiralama_UI\Views\Shared\Components\_FooterViewComponentPartial\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "605e8b8ed3b3baecec4e3d01b166d6f36753b42a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components__FooterViewComponentPartial_Default), @"mvc.1.0.view", @"/Views/Shared/Components/_FooterViewComponentPartial/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"605e8b8ed3b3baecec4e3d01b166d6f36753b42a", @"/Views/Shared/Components/_FooterViewComponentPartial/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de8d307a536c50e24b1bfc6c2af094f9a99398a0", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components__FooterViewComponentPartial_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!-- Footer Start -->
<div class=""container-fluid bg-secondary py-5 px-sm-3 px-md-5"" style=""margin-top: 5px;"">
    <div class=""row pt-5"">
        <div class=""col-lg-3 col-md-6 mb-5"">
            <h4 class=""text-uppercase text-light mb-4"">İletişim Bilgileri</h4>
            <p class=""mb-2""><i class=""fa fa-map-marker-alt text-white mr-3""></i>123 Street, New York, USA</p>
            <p class=""mb-2""><i class=""fa fa-phone-alt text-white mr-3""></i>+012 345 67890</p>
            <p><i class=""fa fa-envelope text-white mr-3""></i>info@example.com</p>
            <h6 class=""text-uppercase text-white py-2"">Bizi Takip Edin</h6>
            <div class=""d-flex justify-content-start"">
                <a class=""btn btn-lg btn-dark btn-lg-square mr-2"" href=""#""><i class=""fab fa-twitter""></i></a>
                <a class=""btn btn-lg btn-dark btn-lg-square mr-2"" href=""#""><i class=""fab fa-facebook-f""></i></a>
                <a class=""btn btn-lg btn-dark btn-lg-square mr-2"" href=""#""><i class=""fab fa-linkedin-in""></i><");
            WriteLiteral(@"/a>
                <a class=""btn btn-lg btn-dark btn-lg-square"" href=""#""><i class=""fab fa-instagram""></i></a>
            </div>
        </div>

        <div class=""col-lg-3 col-md-6 mb-5"">
            <h4 class=""text-uppercase text-light mb-4"">Araba Galerisi</h4>
            <div class=""row mx-n1"">
                <div class=""col-4 px-1 mb-2"">
                    <a");
            BeginWriteAttribute("href", " href=\"", 1403, "\"", 1410, 0);
            EndWriteAttribute();
            WriteLiteral("><img class=\"w-100\" src=\"/car-rental-html-template/img/gallery-1.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 1480, "\"", 1486, 0);
            EndWriteAttribute();
            WriteLiteral("></a>\r\n                </div>\r\n                <div class=\"col-4 px-1 mb-2\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1587, "\"", 1594, 0);
            EndWriteAttribute();
            WriteLiteral("><img class=\"w-100\" src=\"/car-rental-html-template/img/gallery-2.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 1664, "\"", 1670, 0);
            EndWriteAttribute();
            WriteLiteral("></a>\r\n                </div>\r\n                <div class=\"col-4 px-1 mb-2\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1771, "\"", 1778, 0);
            EndWriteAttribute();
            WriteLiteral("><img class=\"w-100\" src=\"/car-rental-html-template/img/gallery-3.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 1848, "\"", 1854, 0);
            EndWriteAttribute();
            WriteLiteral("></a>\r\n                </div>\r\n                <div class=\"col-4 px-1 mb-2\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1955, "\"", 1962, 0);
            EndWriteAttribute();
            WriteLiteral("><img class=\"w-100\" src=\"/car-rental-html-template/img/gallery-4.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 2032, "\"", 2038, 0);
            EndWriteAttribute();
            WriteLiteral("></a>\r\n                </div>\r\n                <div class=\"col-4 px-1 mb-2\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 2139, "\"", 2146, 0);
            EndWriteAttribute();
            WriteLiteral("><img class=\"w-100\" src=\"/car-rental-html-template/img/gallery-5.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 2216, "\"", 2222, 0);
            EndWriteAttribute();
            WriteLiteral("></a>\r\n                </div>\r\n                <div class=\"col-4 px-1 mb-2\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 2323, "\"", 2330, 0);
            EndWriteAttribute();
            WriteLiteral("><img class=\"w-100\" src=\"/car-rental-html-template/img/gallery-6.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 2400, "\"", 2406, 0);
            EndWriteAttribute();
            WriteLiteral(@"></a>
                </div>
            </div>
        </div>
        <div class=""col-lg-3 col-md-6 mb-5"">
            <h4 class=""text-uppercase text-light mb-4"">Bülten</h4>
            <p class=""mb-4"">Volup amet magna clita tempor. Tempor sea eos vero ipsum. Lorem lorem sit sed elitr sed kasd et</p>
            <div class=""w-100 mb-3"">
                <div class=""input-group"">
                    <input type=""text"" class=""form-control bg-dark border-dark"" style=""padding: 25px;"" placeholder=""Mail adresiniz"">
                    <div class=""input-group-append"">
                        <button class=""btn btn-primary text-uppercase px-3"">Üye Ol</button>
                    </div>
                </div>
            </div>
            <i>Lorem sit sed elitr sed kasd et</i>
        </div>
    </div>
</div>
<div class=""container-fluid bg-dark py-4 px-sm-3 px-md-5"">
    <p class=""mb-2 text-center text-body"">&copy; <a href=""#"">Your Site Name</a>. Tüm hakları saklıdır.</p>

</div>
<!-- Footer En");
            WriteLiteral("d -->");
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
