#pragma checksum "D:\Projects\ASPPIC-19\asppic-19-public\ASPPIC.Public\ASPPIC.Public.Web\Views\Hospitals\_HospitalFilters.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6afe2b22e46ea3c7a8aafe64323f20d7e2dbab59"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Hospitals__HospitalFilters), @"mvc.1.0.view", @"/Views/Hospitals/_HospitalFilters.cshtml")]
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
#line 1 "D:\Projects\ASPPIC-19\asppic-19-public\ASPPIC.Public\ASPPIC.Public.Web\Views\_ViewImports.cshtml"
using ASPPIC.Public.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6afe2b22e46ea3c7a8aafe64323f20d7e2dbab59", @"/Views/Hospitals/_HospitalFilters.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"662dd196fe0bb5c2fc81a300ec7334fd917569b9", @"/Views/_ViewImports.cshtml")]
    public class Views_Hospitals__HospitalFilters : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""text-center mb-3 d-xl-none"">
    <button class=""btn btn-outline-primary"" type=""button"" data-toggle=""collapse"" data-target=""#collapseLegend"" aria-controls=""collapseLegend"">Legendă</button>
</div>
<div class=""sidebar collapse"" id=""collapseLegend"">
    <ul class=""list-group"">
        <li class=""list-group-item"">
            <h5 class=""text-muted text-center"">LEGENDĂ</h5>
        </li>
        <li class=""list-group-item"">
            <input type=""checkbox"" value=""DSP"" checked/>
            <img class=""legendMarker"" src='https://raw.githubusercontent.com/pointhi/leaflet-color-markers/master/img/marker-icon-yellow.png' />
            Direcție de Sănătate Publică
        </li>
        <li class=""list-group-item"">
");
            WriteLiteral("            <img class=\"legendMarker\" src=\'https://raw.githubusercontent.com/pointhi/leaflet-color-markers/master/img/marker-icon-violet.png\' />\r\n            Centru de Testare COVID\r\n        </li>\r\n        <li class=\"list-group-item\">\r\n");
            WriteLiteral("            <img class=\"legendMarker\" src=\'https://raw.githubusercontent.com/pointhi/leaflet-color-markers/master/img/marker-icon-blue.png\' />\r\n            Unitate medicală suport COVID\r\n        </li>\r\n        <li class=\"list-group-item\">\r\n");
            WriteLiteral("            <img class=\"legendMarker\" src=\'https://raw.githubusercontent.com/pointhi/leaflet-color-markers/master/img/marker-icon-gold.png\' />\r\n            Maternitate suport COVID\r\n        </li>\r\n        <li class=\"list-group-item\">\r\n");
            WriteLiteral("            <img class=\"legendMarker\" src=\'https://raw.githubusercontent.com/pointhi/leaflet-color-markers/master/img/marker-icon-orange.png\' />\r\n            Unitate medicală dedicată COVID - faza 1\r\n        </li>\r\n        <li class=\"list-group-item\">\r\n");
            WriteLiteral("            <img class=\"legendMarker\" src=\'https://raw.githubusercontent.com/pointhi/leaflet-color-markers/master/img/marker-icon-red.png\' />\r\n            Unitate medicală dedicată COVID - faza 2\r\n        </li>\r\n        <li class=\"list-group-item\">\r\n");
            WriteLiteral("            <img class=\"legendMarker\" src=\'https://raw.githubusercontent.com/pointhi/leaflet-color-markers/master/img/marker-icon-green.png\' />\r\n            Centru de dializă suport COVID\r\n        </li>\r\n        <li class=\"list-group-item\">\r\n");
            WriteLiteral("            <img class=\"legendMarker\" src=\'https://raw.githubusercontent.com/pointhi/leaflet-color-markers/master/img/marker-icon-grey.png\' />\r\n            Unitate medicală NON-COVID\r\n        </li>\r\n    </ul>\r\n</div>\r\n\r\n");
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