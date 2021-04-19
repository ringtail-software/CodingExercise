using Microsoft.AspNetCore.Razor.TagHelpers;

namespace NuixInvestment.TagHelpers
{
	[HtmlTargetElement("td", Attributes = "center")]
	public class AttributeStyleCenter : TagHelper
	{
		public bool Center { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)

		{
			output.Attributes.SetAttribute("style", "text-align:center");
		}
	}
}