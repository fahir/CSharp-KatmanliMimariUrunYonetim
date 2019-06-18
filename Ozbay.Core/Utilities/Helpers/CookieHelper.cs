using System;
using System.Web;
using System.Web.Security;

namespace OZBAY.Core.Utilities.Helpers
{
    public class CookieHelper : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public static string GetPropertyNameFromCookies(string property)
        {
            return HttpContext.Current.Request.RequestContext.RouteData.Values[property].ToString();
        }

        public static string[] GetUserRolesFromCookie()
        {
            HttpCookie AuthenticationCookie= HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            var encryptedTicket = AuthenticationCookie.Value;
            var ticket = FormsAuthentication.Decrypt(encryptedTicket);
            string[] values = ticket.UserData.Split('|');
            string[] roles = values[1].Split(',');
            return roles;
        }
    }
}
