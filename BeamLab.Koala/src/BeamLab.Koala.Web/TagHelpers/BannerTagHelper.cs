using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeamLab.Koala.Web.TagHelpers
{
    public class BannerTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";
            output.Attributes.SetAttribute("src", "https://placeholdit.imgix.net/~text?txtsize=50&txt=banner&w=600&h=150");
            output.Attributes.SetAttribute("class", "img-responsive");
            output.Attributes.SetAttribute("style", "margin-left: auto; margin-right:auto");
        }
    }
}