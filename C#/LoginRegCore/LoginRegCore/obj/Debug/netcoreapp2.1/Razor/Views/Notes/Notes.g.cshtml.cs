#pragma checksum "/Users/LuchkaMAC/CODE/Portfolio/C#/LoginRegCore/LoginRegCore/Views/Notes/Notes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1ea0d249957b6a7ecda7b3a059a5e35d572cc660"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Notes_Notes), @"mvc.1.0.view", @"/Views/Notes/Notes.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Notes/Notes.cshtml", typeof(AspNetCore.Views_Notes_Notes))]
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
#line 1 "/Users/LuchkaMAC/CODE/Portfolio/C#/LoginRegCore/LoginRegCore/Views/_ViewImports.cshtml"
using LoginRegCore;

#line default
#line hidden
#line 2 "/Users/LuchkaMAC/CODE/Portfolio/C#/LoginRegCore/LoginRegCore/Views/_ViewImports.cshtml"
using LoginRegCore.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ea0d249957b6a7ecda7b3a059a5e35d572cc660", @"/Views/Notes/Notes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d65e52ab07aac636b16dc47ca024f80ce13a3d2", @"/Views/_ViewImports.cshtml")]
    public class Views_Notes_Notes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Note>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "Content", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Notes", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddNote", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "/Users/LuchkaMAC/CODE/Portfolio/C#/LoginRegCore/LoginRegCore/Views/Notes/Notes.cshtml"
  
    ViewData["Title"] = "Notes";

#line default
#line hidden
            BeginContext(54, 94, true);
            WriteLiteral("<link href=\"https://fonts.googleapis.com/icon?family=Material+Icons\" rel=\"stylesheet\">\r\n\r\n<h2>");
            EndContext();
            BeginContext(149, 17, false);
#line 7 "/Users/LuchkaMAC/CODE/Portfolio/C#/LoginRegCore/LoginRegCore/Views/Notes/Notes.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(166, 11, true);
            WriteLiteral("</h2>\r\n<h3>");
            EndContext();
            BeginContext(178, 19, false);
#line 8 "/Users/LuchkaMAC/CODE/Portfolio/C#/LoginRegCore/LoginRegCore/Views/Notes/Notes.cshtml"
Write(ViewData["Message"]);

#line default
#line hidden
            EndContext();
            BeginContext(197, 850, true);
            WriteLiteral(@"</h3>


<div class=""leftPane"" style=""display:inline-block; margin-right: 25%"">


<button type=""button"" id=""getnote"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#get-note"" >
    Add note
</button>

<div class=""modal fade"" id=""get-note"" tabindex=""-1"" role=""dialog"" aria-labelledby=""getNoteLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
                    <div class=""modal-header"">
                        <h5 class=""modal-title"" id=""addNoteLabel"">Add note</h5>
                        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                            <span aria-hidden=""true"">×</span>
                        </button>
                    </div>
                    <div class=""modal-body"">
                        ");
            EndContext();
            BeginContext(1047, 1078, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e3270277a4f145c397a5ac9ddfcb1610", async() => {
                BeginContext(1111, 88, true);
                WriteLiteral("\r\n                            <div class=\"form-group\">\r\n                                ");
                EndContext();
                BeginContext(1199, 31, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a41b594a6a154e559520f9d01fcbe662", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#line 30 "/Users/LuchkaMAC/CODE/Portfolio/C#/LoginRegCore/LoginRegCore/Views/Notes/Notes.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Title);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1230, 34, true);
                WriteLiteral("\r\n                                ");
                EndContext();
                BeginContext(1264, 46, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "fdbe0975fee142148d4df47367dbd888", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 31 "/Users/LuchkaMAC/CODE/Portfolio/C#/LoginRegCore/LoginRegCore/Views/Notes/Notes.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Title);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1310, 34, true);
                WriteLiteral("\r\n                                ");
                EndContext();
                BeginContext(1344, 60, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "287bd83720a04e9b81b54c833cddea7e", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#line 32 "/Users/LuchkaMAC/CODE/Portfolio/C#/LoginRegCore/LoginRegCore/Views/Notes/Notes.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Title);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1404, 177, true);
                WriteLiteral("\r\n                            </div>\r\n                            <div class=\"form-group\">\r\n                                <label>Note</label>\r\n                                ");
                EndContext();
                BeginContext(1581, 75, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("textarea", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "932019e8c557460fa99842b08a103227", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper);
#line 36 "/Users/LuchkaMAC/CODE/Portfolio/C#/LoginRegCore/LoginRegCore/Views/Notes/Notes.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Content);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper.Name = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1656, 34, true);
                WriteLiteral("\r\n                                ");
                EndContext();
                BeginContext(1690, 62, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dbfdf8ddac6a4259a481b3a46bfa0577", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#line 37 "/Users/LuchkaMAC/CODE/Portfolio/C#/LoginRegCore/LoginRegCore/Views/Notes/Notes.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Content);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1752, 366, true);
                WriteLiteral(@"
                            </div>
                            <div class=""modal-footer"">
                                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                                <button type=""submit"" class=""btn btn-primary"">Create</button>
                            </div>
                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2125, 154, true);
            WriteLiteral("\r\n                    </div>\r\n            \r\n\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<br />\r\n<div id=\"modal-placeholder\"></div>\r\n<ul class=\"noteslist\">\r\n");
            EndContext();
#line 55 "/Users/LuchkaMAC/CODE/Portfolio/C#/LoginRegCore/LoginRegCore/Views/Notes/Notes.cshtml"
      
        foreach (var note in @ViewBag.UserNotes)
        {

#line default
#line hidden
            BeginContext(2348, 86, true);
            WriteLiteral("            <li class=\"subnoteslist\">\r\n                <a id=\"title_list\" data-target=");
            EndContext();
            BeginContext(2435, 11, false);
#line 59 "/Users/LuchkaMAC/CODE/Portfolio/C#/LoginRegCore/LoginRegCore/Views/Notes/Notes.cshtml"
                                          Write(note.NoteID);

#line default
#line hidden
            EndContext();
            BeginContext(2446, 2, true);
            WriteLiteral("> ");
            EndContext();
            BeginContext(2449, 10, false);
#line 59 "/Users/LuchkaMAC/CODE/Portfolio/C#/LoginRegCore/LoginRegCore/Views/Notes/Notes.cshtml"
                                                        Write(note.Title);

#line default
#line hidden
            EndContext();
            BeginContext(2459, 53, true);
            WriteLiteral("</a>\r\n                <a id=\"title_edit\" data-target=");
            EndContext();
            BeginContext(2513, 11, false);
#line 60 "/Users/LuchkaMAC/CODE/Portfolio/C#/LoginRegCore/LoginRegCore/Views/Notes/Notes.cshtml"
                                          Write(note.NoteID);

#line default
#line hidden
            EndContext();
            BeginContext(2524, 60, true);
            WriteLiteral("> <i class=\"material-icons\">menu</i></a>\r\n                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2584, "\"", 2610, 2);
            WriteAttributeValue("", 2591, "delete/", 2591, 7, true);
#line 61 "/Users/LuchkaMAC/CODE/Portfolio/C#/LoginRegCore/LoginRegCore/Views/Notes/Notes.cshtml"
WriteAttributeValue("", 2598, note.NoteID, 2598, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2611, 62, true);
            WriteLiteral("><i class=\"material-icons\">delete</i></a>\r\n            </li>\r\n");
            EndContext();
#line 63 "/Users/LuchkaMAC/CODE/Portfolio/C#/LoginRegCore/LoginRegCore/Views/Notes/Notes.cshtml"
        }
    

#line default
#line hidden
            BeginContext(2691, 353, true);
            WriteLiteral(@"</ul>
<a href=""/logout"">Logout</a>
    </div>
<div class=""rightPane"" style=""display:inline-block; vertical-align:top"">
    
    <p class=""note_content"" style=""font-size:20px""></p>
    <input id=""content_input"" class=""form-control"" value="""" type=""hidden"" />
    <input class=""form-control"" id=""save_title"" type=""hidden"" value=""Save"" />
</div>

");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Note> Html { get; private set; }
    }
}
#pragma warning restore 1591
