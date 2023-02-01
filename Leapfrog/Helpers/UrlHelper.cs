using System;
using System.Security.Policy;
using System.Text.RegularExpressions;

namespace Leapfrog.Helpers
{
    internal static class UrlHelper
    {

        /// <summary>
        /// Validate if a URL string is valid
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsValidUrl(string url)
        {
            //string pattern = "(([\\w]+:)?//)?(([\\d\\w]|%[a-fA-f\\d]{2,2})+(:([\\d\\w]|%[a-fA-f\\d]{2,2})+)?@)?([\\d\\w][-\\d\\w]{0,253}[\\d\\w]\\.)+[\\w]{2,63}(:[\\d]+)?(/([-+_~.\\d\\w]|%[a-fA-f\\d]{2,2})*)*(\\?(&?([-+_~.\\d\\w]|%[a-fA-f\\d]{2,2})=?)*)?(#([-+_~.\\d\\w]|%[a-fA-f\\d]{2,2})*)?";
            //Regex ex = new(pattern);

            //var match = ex.Match(url);
            //return match.Success;
            return Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute);

            //return Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out Uri uri);

            //&& uri.Scheme == Uri.UriSchemeHttp
            //     || uri.Scheme == Uri.UriSchemeHttps
            //     || uri.Scheme == Uri.UriSchemeFtp
            //     || uri.Scheme == Uri.UriSchemeMailto
        }
    }
}
