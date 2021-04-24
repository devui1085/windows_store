using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsStore.Client.User.Common.ExtensionMethod;

namespace WindowsStore.Client.User.Common.Web
{
    public static class HttpUtility
    {
        public static NameValueCollection ParseQueryString(string queryString)
        {
            var nameValues = new NameValueCollection();
            var querySegments = queryString.Split('&');
            querySegments.ForEach(querySegment =>
            {
                var segmentParts = querySegment.Split('=');
                var name = segmentParts[0].Trim();
                var value = segmentParts[1].Trim();
                nameValues.Add(name, value);
            });

            return nameValues;
        }
    }
}
