using System;
using System.Web;
using System.Web.Mvc;

namespace DevRainSolutions.KyivSmartCity.New.Models
{
    public static class UrlHelperExtensions
    {
        public static string ContentAbsUrl(this UrlHelper url, string relativeContentPath)
        {
            Uri contextUri = HttpContext.Current.Request.Url;

            var baseUri = string.Format("{0}://{1}{2}", contextUri.Scheme,
                contextUri.Host, contextUri.Port == 80 ? string.Empty : ":" + contextUri.Port);

            return string.Format("{0}{1}", baseUri, VirtualPathUtility.ToAbsolute(relativeContentPath));
        }
    }
}