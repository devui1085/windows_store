using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    class HttpSessionCookieHelper
    {
        const string AspNetSessionIdCookieName = "ASP.NET_SessionId";
        string aspNetSessionId = string.Empty;
        HttpSessionCookieHelper()
        { }

        public static HttpSessionCookieHelper Create(string cookieString)
        {
            HttpSessionCookieHelper helper = new HttpSessionCookieHelper();
            helper.ParseCookieString(cookieString);
            return helper;
        }

        public static HttpSessionCookieHelper CreateFromSessionId(string sessionId)
        {
            HttpSessionCookieHelper helper = new HttpSessionCookieHelper();
            helper.aspNetSessionId = sessionId;
            return helper;
        }

        public void AddSessionIdToRequest(HttpRequestMessageProperty requestProperty)
        {
            if (string.IsNullOrEmpty(this.aspNetSessionId))
                return;

            string sessionCookieString = string.Format("{0}={1}", AspNetSessionIdCookieName, this.aspNetSessionId);
            string cookieString = (string)requestProperty.Headers[HttpRequestHeader.Cookie];
            if (string.IsNullOrEmpty(cookieString))
            {
                cookieString = sessionCookieString;
            }
            else
            {
                cookieString = string.Format("{0}; {1}", cookieString, sessionCookieString);
            }

            requestProperty.Headers[HttpRequestHeader.Cookie] = cookieString;
        }

        void ParseCookieString(string cookieString)
        {
            if (string.IsNullOrEmpty(cookieString))
                return;

            string[] cookies = cookieString.Split(';');
            for (int i = 0; i < cookies.Length; i++)
            {
                string[] cookieNameValues = cookies[i].Split('=');
                if (cookieNameValues[0] == AspNetSessionIdCookieName)
                {
                    this.aspNetSessionId = cookieNameValues[1];
                    return;
                }
            }
        }

        public string AspNetSessionId
        {
            get
            {
                return this.aspNetSessionId;
            }
        }
    }
}
