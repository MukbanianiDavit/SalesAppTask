using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SalesApp.Panel.Web.Helpers;
using System.Linq;

namespace SalesApp.Panel.Web.TagHelpers
{
    [HtmlTargetElement(Attributes = IsActiveAttributeName)]
    [HtmlTargetElement(Attributes = IgnoreActionAttributeName)]
    [HtmlTargetElement(Attributes = ActiveClassAttributeName)]
    [HtmlTargetElement(Attributes = ActionAttributeName)]
    [HtmlTargetElement(Attributes = ControllerAttributeName)]
    public class CheckActiveTagHelper : TagHelper
    {
        private const string ActionAttributeName = "asp-action";
        private const string ControllerAttributeName = "asp-controller";
        private const string IsActiveAttributeName = "check-active";
        private const string ActiveClassAttributeName = "active-class";
        private const string IgnoreActionAttributeName = "ignore-action";

        [HtmlAttributeName(ActionAttributeName)]
        public string Action { get; set; } = null!;

        [HtmlAttributeName(IgnoreActionAttributeName)]
        public bool Ignore { get; set; } = false;

        [HtmlAttributeName(ControllerAttributeName)]
        public string Controller { get; set; } = null!;

        [HtmlAttributeName(IsActiveAttributeName)]
        public bool CheckActive { get; set; } = false;

        [HtmlAttributeName(ActiveClassAttributeName)]
        public string ActiveClass { get; set; } = null!;

        private readonly IHtmlHelper _htmlHelper;


        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }


        public CheckActiveTagHelper(IHtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            (_htmlHelper as IViewContextAware)?.Contextualize(ViewContext);
            if (CheckActive)
            {
                if (Ignore) { Action = null; }

                var classes = output.Attributes.FirstOrDefault(a => a.Name == "class")?.Value.ToString();

                if (Controller is not null && !string.IsNullOrEmpty(_htmlHelper.IsActive(Controller, Action)))
                {
                    classes += ActiveClass != null ? " " + ActiveClass : " active";
                    output.Attributes.SetAttribute("class", classes);
                }
            }
            base.Process(context, output);
        }
    }
}
