using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SugarFreeDiet.Extensions
{
    public static class HtmlExtensions
    {
        public static IHtmlString EmbedCss(this HtmlHelper htmlHelper, string path)
        {
            var cssFilePath = HttpContext.Current.Server.MapPath(path);

            try
            {
                var cssText = File.ReadAllText(cssFilePath);
                return htmlHelper.Raw("<style>\n" + cssText + "\n</style>");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static IHtmlString PreserveNewLine(this HtmlHelper htmlHelper, string value)
        {
            return new HtmlString(value == null ? value : value.Replace(Environment.NewLine, "<br/>"));
        }
    }
}