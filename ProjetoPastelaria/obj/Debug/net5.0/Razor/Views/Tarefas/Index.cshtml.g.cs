#pragma checksum "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\Tarefas\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aa5bc1c23b95dc20692386a10563fe374c46c026"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tarefas_Index), @"mvc.1.0.view", @"/Views/Tarefas/Index.cshtml")]
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
#line 1 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\_ViewImports.cshtml"
using ProjetoPastelaria;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\_ViewImports.cshtml"
using ProjetoPastelaria.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa5bc1c23b95dc20692386a10563fe374c46c026", @"/Views/Tarefas/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5afdd7634f2cae1b6b98047c1615ce3ac14fdb1", @"/Views/_ViewImports.cshtml")]
    public class Views_Tarefas_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<TarefasModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Tarefas", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Criar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Editar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ApagarConfirmacao", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\Tarefas\Index.cshtml"
  
    ViewData["Title"] = "Lista-Tarefas";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n");
#nullable restore
#line 7 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\Tarefas\Index.cshtml"
     if (ViewBag.PerfilUsuarioLogado != null)
    {
        var perfilUsuario = ViewBag.PerfilUsuarioLogado.ToString();

        if (perfilUsuario == ProjetoPastelaria.Enum.PerfilEnum.Admin.ToString())
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"d-grid gap-2 d-md-flex justify-content-md-start\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aa5bc1c23b95dc20692386a10563fe374c46c0266534", async() => {
                WriteLiteral("Cadastrar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>");
#nullable restore
#line 15 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\Tarefas\Index.cshtml"
                  }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 18 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\Tarefas\Index.cshtml"
     if (TempData["MensagemSucesso"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-success\" role=\"alert\">\r\n            <button type=\"button\" class=\"btn btn-danger btn-sm close-alert\" arial-label=\"Close\">X</button>\r\n            ");
#nullable restore
#line 22 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\Tarefas\Index.cshtml"
       Write(TempData["MensagemSucesso"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 24 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\Tarefas\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 26 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\Tarefas\Index.cshtml"
     if (TempData["MensagemErro"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-danger\" role=\"alert\">\r\n            <button type=\"button\" class=\"btn btn-danger btn-sm close-alert\" arial-label=\"Close\">X</button>\r\n            ");
#nullable restore
#line 30 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\Tarefas\Index.cshtml"
       Write(TempData["MensagemErro"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 32 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\Tarefas\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <br />
    <h1> Listagem-Tarefas</h1>
    <br />
    <table class=""table"" id=""table-tarefas"">
        <thead>
            <tr>
                <th scope=""col"">Funcionário</th>
                <th scope=""col"">Descrição</th>
                <th scope=""col"">Data de Criação</th>
                <th scope=""col"">Prazo de Conclusão</th>              
                <th scope=""col"">Ações</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 48 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\Tarefas\Index.cshtml"
             if (Model != null && Model.Any())
            {
                foreach (TarefasModel tarefas in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td scope=\"row\">");
#nullable restore
#line 53 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\Tarefas\Index.cshtml"
                                   Write(ViewBag.FuncionarioDict[tarefas.IdFuncionario]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td> <!-- Mostra o nome do funcionário -->\r\n                        <td scope=\"row\">");
#nullable restore
#line 54 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\Tarefas\Index.cshtml"
                                   Write(tarefas.Descricao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td scope=\"row\">");
#nullable restore
#line 55 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\Tarefas\Index.cshtml"
                                   Write(tarefas.DataCriacao.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td> <!-- Formata a data -->\r\n                        <td scope=\"row\">");
#nullable restore
#line 56 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\Tarefas\Index.cshtml"
                                   Write(tarefas.PrazoConclusao?.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td> <!-- Formata a data com Nullable -->                     \r\n                        <td>\r\n                            <div class=\"btn-group\" role=\"group\">\r\n");
#nullable restore
#line 59 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\Tarefas\Index.cshtml"
                                 if (ViewBag.PerfilUsuarioLogado != null)
                                {
                                    var perfilUsuario = ViewBag.PerfilUsuarioLogado.ToString();

                                    if (perfilUsuario == ProjetoPastelaria.Enum.PerfilEnum.Admin.ToString())
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aa5bc1c23b95dc20692386a10563fe374c46c02613219", async() => {
                WriteLiteral("Editar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 65 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\Tarefas\Index.cshtml"
                                                                                     WriteLiteral(tarefas.IdTarefa);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aa5bc1c23b95dc20692386a10563fe374c46c02615849", async() => {
                WriteLiteral("Apagar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 66 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\Tarefas\Index.cshtml"
                                                                                  WriteLiteral(tarefas.IdTarefa);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 67 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\Tarefas\Index.cshtml"
                                    }
                                    else if (perfilUsuario == ProjetoPastelaria.Enum.PerfilEnum.padrao.ToString())
                                    {
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\Tarefas\Index.cshtml"
                                         using (Html.BeginForm("Concluir", "Tarefas", FormMethod.Post))
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\Tarefas\Index.cshtml"
                                       Write(Html.Hidden("id", tarefas.IdTarefa));

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <button type=\"submit\" class=\"btn btn-success\">Concluir</button>\r\n");
#nullable restore
#line 74 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\Tarefas\Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 74 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\Tarefas\Index.cshtml"
                                         
                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 80 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\Tarefas\Index.cshtml"
                }
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr class=\"add\"><td valign=\"top\" colspan=\"6\">Nenhuma Tarefa Encontrada</td></tr>\r\n");
#nullable restore
#line 85 "C:\Users\douglas reis\Desktop\ProjetoPastelaria\ProjetoPastelaria\Views\Tarefas\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<TarefasModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
