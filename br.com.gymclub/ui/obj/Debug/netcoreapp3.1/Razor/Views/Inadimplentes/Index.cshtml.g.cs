#pragma checksum "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "920b6f0cb228c22f42e86cc73fefd0a2261da458"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Inadimplentes_Index), @"mvc.1.0.view", @"/Views/Inadimplentes/Index.cshtml")]
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
#line 2 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml"
using ui.viewmodels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"920b6f0cb228c22f42e86cc73fefd0a2261da458", @"/Views/Inadimplentes/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4236dedce4ca9c9938da52cf31b42b6356a081af", @"/Views/_ViewImports.cshtml")]
    public class Views_Inadimplentes_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<api.models.Payment>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = "Instrutores";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3 class=\"title title-list\">Lista de Inadimplentes</h3>\r\n\r\n<div id=\"busca\" class=\"form-group col-md-12\">\r\n    <section>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "920b6f0cb228c22f42e86cc73fefd0a2261da4584048", async() => {
                WriteLiteral(@"
            <div class=""row"">


                <div class=""col-sm-10 form-group text-center"">
                    <input type=""text"" name=""searchValue"" class=""form-control"" placeholder=""Digite Nome, Rg o CPF do cliente"" />

                </div>
                <div class=""col-sm-2 text-center"">
                    <input type=""submit"" value=""Buscar"" id=""busca"" class=""btn btn-primary"" />
                </div>
            </div>



        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 12 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml"
AddHtmlAttributeValue("", 303, Url.Content("~/Inadimplentes"), 303, 31, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "920b6f0cb228c22f42e86cc73fefd0a2261da4586425", async() => {
                WriteLiteral("\r\n            <div class=\"row\" style=\"padding-top:20px\">\r\n                <div class=\"col-sm-3 text-center\">\r\n\r\n                   \r\n");
#nullable restore
#line 34 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml"
                     if (ViewData["searchOld"] != null)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <input type=\"hidden\" name=\"searchOld\"");
                BeginWriteAttribute("value", " value=\"", 1173, "\"", 1203, 1);
#nullable restore
#line 36 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml"
WriteAttributeValue("", 1181, ViewData["searchOld"], 1181, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
#nullable restore
#line 37 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <input type=\"submit\" value=\"Export\" id=\"busca\" class=\"btn btn-secondary\" />\r\n                </div>\r\n\r\n\r\n            </div>\r\n\r\n\r\n\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 29 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml"
AddHtmlAttributeValue("", 845, Url.Content("~/Inadimplentes/Export"), 845, 38, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n    </section>\r\n</div>\r\n\r\n");
#nullable restore
#line 55 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml"
 if (TempData["_mensagem"] != null)
{
    VMMessages mensagem = (VMMessages)TempData["_mensagem"];

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div id=\"message\"");
            BeginWriteAttribute("class", " class=\"", 1559, "\"", 1580, 1);
#nullable restore
#line 58 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml"
WriteAttributeValue("", 1567, mensagem.Css, 1567, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <span>");
#nullable restore
#line 59 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml"
         Write(mensagem.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n    </div>\r\n    <script type=\"text/javascript\">hiddenMessage();</script>\r\n");
#nullable restore
#line 62 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 67 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 70 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.client.User));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 73 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.client.User.Rg));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 76 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.client.User.Cpf));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n            <th>\r\n                ");
#nullable restore
#line 80 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.planType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 83 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DueDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 88 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 92 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 95 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.client.User.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 99 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.client.User.Rg));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 102 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.client.User.Cpf));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 105 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.client.planType.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 108 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.DueDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n           \r\n        </tr>\r\n");
#nullable restore
#line 112 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Inadimplentes/Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<api.models.Payment>> Html { get; private set; }
    }
}
#pragma warning restore 1591
