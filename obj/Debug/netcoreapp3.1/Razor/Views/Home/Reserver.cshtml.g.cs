#pragma checksum "C:\Users\youcode\source\repos\reservation\reservation\Views\Home\Reserver.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c1e32c3fb2a76c510753ecd3105e0e6b7d15d336"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Reserver), @"mvc.1.0.view", @"/Views/Home/Reserver.cshtml")]
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
#line 1 "C:\Users\youcode\source\repos\reservation\reservation\Views\_ViewImports.cshtml"
using reservation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\youcode\source\repos\reservation\reservation\Views\_ViewImports.cshtml"
using reservation.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\youcode\source\repos\reservation\reservation\Views\Home\Reserver.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1e32c3fb2a76c510753ecd3105e0e6b7d15d336", @"/Views/Home/Reserver.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c501f9f20ca8c065e960e3f33d325e468cae3aa3", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Reserver : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"
<div class=""navigate"">
    <i class=""fas fa-lg fa-chevron-circle-left previous ""></i>
    <i class=""fas fa-lg fa-chevron-circle-right next ""></i>
</div>


<div class=""calandrier-container"">

    <div class=""calandrier-info"">
        <div class=""num-date"">28</div>
        <div class=""num-day"">THURSDAY</div>
        <div class=""num-jour"">Jour</div>
        <button class=""submit-btn"">Reserver</button>
    </div>

    <div class=""calandrier"">

        <div class=""jour"">
            <h2>Jour</h2>
            <h3>9h</h3>
            <h3>5h</h3>
            <h3>8h</h3>

        </div>

        <div class=""lun"">
            <h2>Lundi</h2>

        </div>

        <div class=""mar"">
            <h2>Mardi</h2>

        </div>

        <div class=""mer"">
            <h2>Mercredi</h2>

        </div>
        <div class=""jeu"">
            <h2>Jeudi</h2>

        </div>
        <div class=""ven"">
            <h2>Vendredi</h2>

        </div>

        <div class=""sam"">
       ");
            WriteLiteral("     <h2>Samedi</h2>\r\n        </div>\r\n\r\n        <div class=\"dim\">\r\n            <h2>Dimanche</h2>\r\n        </div>\r\n\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
#nullable restore
#line 66 "C:\Users\youcode\source\repos\reservation\reservation\Views\Home\Reserver.cshtml"
 if (User.IsInRole("Admin"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script>\r\n        const role = \"admin\"\r\n    </script>\r\n");
#nullable restore
#line 71 "C:\Users\youcode\source\repos\reservation\reservation\Views\Home\Reserver.cshtml"

}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script>\r\n        const role = \"etudiant\"\r\n    </script>\r\n");
#nullable restore
#line 78 "C:\Users\youcode\source\repos\reservation\reservation\Views\Home\Reserver.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<User> UserManager { get; private set; }
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
