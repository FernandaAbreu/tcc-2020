#pragma checksum "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Shared/Messages.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "11481e326ab307d56abeda262bb499bb850b1cdc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Messages), @"mvc.1.0.view", @"/Views/Shared/Messages.cshtml")]
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
#line 1 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/_ViewImports.cshtml"
using ui;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/_ViewImports.cshtml"
using ui.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Shared/Messages.cshtml"
using ui.viewmodels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11481e326ab307d56abeda262bb499bb850b1cdc", @"/Views/Shared/Messages.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4236dedce4ca9c9938da52cf31b42b6356a081af", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Messages : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Shared/Messages.cshtml"
 if (TempData["_mensagem"] != null)
{
    VMMessages mensagem = (VMMessages)TempData["_mensagem"];

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div id=\"message\"");
            BeginWriteAttribute("class", " class=\"", 145, "\"", 166, 1);
#nullable restore
#line 5 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Shared/Messages.cshtml"
WriteAttributeValue("", 153, mensagem.Css, 153, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <span>");
#nullable restore
#line 6 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Shared/Messages.cshtml"
         Write(mensagem.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n    </div>\r\n    <script type=\"text/javascript\">hiddenMessage();</script>\r\n");
#nullable restore
#line 9 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Shared/Messages.cshtml"
}

#line default
#line hidden
#nullable disable
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