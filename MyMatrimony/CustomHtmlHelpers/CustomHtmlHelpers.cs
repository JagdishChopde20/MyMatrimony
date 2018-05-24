using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMatrimony.CustomHtmlHelpers
{
    public static class CustomHtmlHelpers
    {
        public static IHtmlString MyImage(this HtmlHelper helper, string src, string height, string width, string classes, string styles, string alt = "Image Not Available")
        {
            // Build IMG tag
            TagBuilder tb = new TagBuilder("img");

            // Add "src" attribute
            tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));

            //// Add "height" attribute
            //tb.Attributes.Add("height", height);
            //// Add "width" attribute
            //tb.Attributes.Add("width", width);

            // Add "alt" attribute
            tb.Attributes.Add("alt", alt);
            
            // Add "class" attribute
            tb.Attributes.Add("class", classes);
            
            // Add "style" attribute
            tb.Attributes.Add("style", styles);

            // return MvcHtmlString. This class implements IHtmlString interface. IHtmlStrings will not be html encoded.
            return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
        }
    }
}