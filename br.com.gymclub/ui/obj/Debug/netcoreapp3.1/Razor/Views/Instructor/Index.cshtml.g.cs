#pragma checksum "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Instructor/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e1fbe94e9043392fc78bec805534dad54b9d8d89"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Instructor_Index), @"mvc.1.0.view", @"/Views/Instructor/Index.cshtml")]
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
#line 2 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Instructor/Index.cshtml"
using ui.viewmodels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1fbe94e9043392fc78bec805534dad54b9d8d89", @"/Views/Instructor/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4236dedce4ca9c9938da52cf31b42b6356a081af", @"/Views/_ViewImports.cshtml")]
    public class Views_Instructor_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<api.models.Instructor>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-md"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Instructor/Index.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = "Instrutores";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3 class=\"title title-list\">Lista de Instrutores</h3>\r\n\r\n<div id=\"busca\" class=\"form-group col-md-12\">\r\n    <section>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e1fbe94e9043392fc78bec805534dad54b9d8d896122", async() => {
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
#line 12 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Instructor/Index.cshtml"
AddHtmlAttributeValue("", 304, Url.Content("~/Instructor"), 304, 28, false);

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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e1fbe94e9043392fc78bec805534dad54b9d8d898493", async() => {
                WriteLiteral("\r\n            <div class=\"row\" style=\"padding-top:20px\">\r\n                <div class=\"col-sm-3 text-center\">\r\n\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e1fbe94e9043392fc78bec805534dad54b9d8d898891", async() => {
                    WriteLiteral("Novo Instrutor");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 34 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Instructor/Index.cshtml"
                     if (ViewData["searchOld"] != null)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <input type=\"hidden\" name=\"searchOld\"");
                BeginWriteAttribute("value", " value=\"", 1241, "\"", 1271, 1);
#nullable restore
#line 36 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Instructor/Index.cshtml"
WriteAttributeValue("", 1249, ViewData["searchOld"], 1249, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
#nullable restore
#line 37 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Instructor/Index.cshtml"
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
#line 29 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Instructor/Index.cshtml"
AddHtmlAttributeValue("", 843, Url.Content("~/Instructor/Export"), 843, 35, false);

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
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n    </section>\r\n</div>\r\n\r\n");
#nullable restore
#line 54 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Instructor/Index.cshtml"
 if (TempData["_mensagem"] != null)
{
    VMMessages mensagem = (VMMessages)TempData["_mensagem"];

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div id=\"message\"");
            BeginWriteAttribute("class", " class=\"", 1625, "\"", 1646, 1);
#nullable restore
#line 57 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Instructor/Index.cshtml"
WriteAttributeValue("", 1633, mensagem.Css, 1633, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <span>");
#nullable restore
#line 58 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Instructor/Index.cshtml"
         Write(mensagem.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n    </div>\r\n    <script type=\"text/javascript\">hiddenMessage();</script>\r\n");
#nullable restore
#line 61 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Instructor/Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 66 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Instructor/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 69 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Instructor/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.User));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 72 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Instructor/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.User.Rg));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 75 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Instructor/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.User.Cpf));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            \r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 82 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Instructor/Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 86 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Instructor/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 89 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Instructor/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.User.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 92 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Instructor/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.User.Rg));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 95 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Instructor/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.User.Cpf));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n               \r\n\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e1fbe94e9043392fc78bec805534dad54b9d8d8917117", async() => {
                WriteLiteral("Editar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 100 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Instructor/Index.cshtml"
                                                                WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" \r\n\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e1fbe94e9043392fc78bec805534dad54b9d8d8919367", async() => {
                WriteLiteral("Remover");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 102 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Instructor/Index.cshtml"
                                                                    WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 105 "/Users/fernandaabreu/tcc-2020/br.com.gymclub/ui/Views/Instructor/Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<api.models.Instructor>> Html { get; private set; }
    }
}
#pragma warning restore 1591
