#pragma checksum "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b412aed4897ac58a5a2f7e4c5a9a9834ed9a43a7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_Details), @"mvc.1.0.view", @"/Views/Movies/Details.cshtml")]
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
#line 1 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/_ViewImports.cshtml"
using MovieShopMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/_ViewImports.cshtml"
using MovieShopMVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
using ApplicationCore.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b412aed4897ac58a5a2f7e4c5a9a9834ed9a43a7", @"/Views/Movies/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0d2154f16347fb0df8a919e414827cd460665e4", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ApplicationCore.Models.MovieDetailsResponseModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary bg-dark btn-outline-light btn-block btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary btn-outline-dark bg-white btn-block btn-sm "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-light btn-block btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 5 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
  
  ViewData["Title"] = "Details";
  // ViewBag.Title = "title";
  // Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"container-fluid bg-dark\">\n  <div class=\"row\">\n    <div class=\"col\">\n      <img");
            BeginWriteAttribute("src", " src=\"", 303, "\"", 325, 1);
#nullable restore
#line 14 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
WriteAttributeValue("", 309, Model.PosterUrl, 309, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 326, "\"", 344, 1);
#nullable restore
#line 14 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
WriteAttributeValue("", 332, Model.Title, 332, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/>\n      \n    </div>\n    <div class=\"col-6\">\n      <div class=\"row mt-3\">\n        <div class=\"col-12\">\n          <h1 class=\"text-white\">\n            ");
#nullable restore
#line 21 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
       Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n          </h1>\n          <p class=\"text-muted\">\n            ");
#nullable restore
#line 24 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
       Write(Model.Tagline);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n          </p>\n        </div>\n      </div>\n      <div class=\"row\">\n        <div class=\"col-6 col-md-4 text-muted\">\n          ");
#nullable restore
#line 30 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
     Write(Model.RunTime);

#line default
#line hidden
#nullable disable
            WriteLiteral(" | ");
#nullable restore
#line 30 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
                      Write(Model.ReleaseDate.Value.Date.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n        <a href=\"#\" class=\"badge badge-dark\">\n");
#nullable restore
#line 33 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
           foreach (var genre in Model.Genres)
          {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div>\n              ");
#nullable restore
#line 36 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
         Write(genre.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n");
#nullable restore
#line 38 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
          }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </a>\n      </div>\n      <div class=\"row\">\n        <span class=\"badge badge-pill badge-success\">\n          ");
#nullable restore
#line 43 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
     Write(Model.Rating);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </span>\n      </div>\n      <div class=\"row text-white\">\n        <div clas=\"col-12\">\n          ");
#nullable restore
#line 48 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
     Write(Model.Overview);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n      </div>\n    </div>\n    <div class=\"col mr-3 mt-5\">\n      ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b412aed4897ac58a5a2f7e4c5a9a9834ed9a43a79027", async() => {
                WriteLiteral("\n        <i class=\"far fa-edit\"></i>\n        REVIEW\n      ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n      ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b412aed4897ac58a5a2f7e4c5a9a9834ed9a43a710410", async() => {
                WriteLiteral("\n        BUY ");
#nullable restore
#line 58 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
       Write(Model.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral("\n      ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
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
</div>

<div class=""container-fluid mt-3"">
  <div class=""row"">
      <div class=""col-4"">
        <h5 class=""mb-3"">MOVIE FACT</h5>
        <ul class=""list-group"">
          <li class=""list-group-item"">
            Release Date
            <span class=""badge badge-pill badge-dark"">
              ");
#nullable restore
#line 72 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
         Write(Model.ReleaseDate.Value.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </span>\n          </li>\n          <li class=\"list-group-item\">\n            Run Time\n            <span class=\"badge badge-pill badge-dark\">\n              ");
#nullable restore
#line 78 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
         Write(Model.RunTime.Value.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </span>\n          </li>\n          <li class=\"list-group-item\">\n            Box Office\n            <span class=\"badge badge-pill badge-dark\">\n              ");
#nullable restore
#line 84 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
         Write(Model.Revenue.Value.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </span>\n          </li>\n          <li class=\"list-group-item\">\n            Budget\n            <span class=\"badge badge-pill badge-dark\">\n              ");
#nullable restore
#line 90 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
         Write(Model.Budget);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </span>\n          </li>\n        </ul>\n        \n        <h5 class=\"mt-lg-5\">TRAILERS</h5>\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b412aed4897ac58a5a2f7e4c5a9a9834ed9a43a713855", async() => {
                WriteLiteral("\n          <i class=\"far fa-edit\"></i>\n          ");
#nullable restore
#line 98 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
     Write(Model.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n      </div>\n  \n    <div class=\"col ml-lg-5\">\n      <h5>CAST</h5>\n      <table>\n");
#nullable restore
#line 105 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
         foreach (var cast in Model.Casts)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\n           <td>\n             <img");
            BeginWriteAttribute("src", " src=\"", 2964, "\"", 2988, 2);
#nullable restore
#line 108 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
WriteAttributeValue("", 2970, cast.ProfilePath, 2970, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 2987, "", 2988, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 2989, "\"", 3005, 1);
#nullable restore
#line 108 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
WriteAttributeValue("", 2995, cast.Name, 2995, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"rounded-circle mr-5 ml-lg-4\" width=\"50\" />\n           </td>\n           <td>");
#nullable restore
#line 110 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
          Write(cast.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n           <td>");
#nullable restore
#line 111 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
          Write(cast.Character);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n         </tr>\n");
#nullable restore
#line 113 "/Users/yangxueyi/Projects/movie_shop/MovieShopMVC/Views/Movies/Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("      </table>\n    </div>\n  </div>\n</div>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ApplicationCore.Models.MovieDetailsResponseModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
