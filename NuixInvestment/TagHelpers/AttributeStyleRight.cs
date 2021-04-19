using Microsoft.AspNetCore.Razor.TagHelpers;

namespace NuixInvestment.TagHelpers
{
	[HtmlTargetElement("td", Attributes = "right")]
	public class AttributeStyleRight : TagHelper
	{
		public bool Right { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)

		{
			output.Attributes.SetAttribute("style", "text-align:right");
		}
	}
}