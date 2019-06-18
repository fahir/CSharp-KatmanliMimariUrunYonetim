using System;
using System.Web.Security;

namespace OZBAY.Core.CrossCuttingConcerns.Security.Web
{
    public class SecurityUtilities
    {

        public Identity FormsAuthTicketToIdentity(FormsAuthenticationTicket ticket)
        {

            var identity = new Identity
            {

                Id = SetId(GetData(ticket)),
                Name = SetName(ticket),
                Email = SetEmail(GetData(ticket)),
                Roles = SetRoles(GetData(ticket)),
                FirstName = SetFirstName(GetData(ticket)),
                LastName = SetLastName(GetData(ticket)),
                AuthenticationType = SetAuthType(),
                IsAuthenticated = SetIsAuthenticated()
            };
            return identity;
        }

        private bool SetIsAuthenticated()
        {
            return true;
        }
        private string[] GetData(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data;
        }
        private string SetAuthType()
        {
            return "Forms";
        }

        private string SetLastName(string[] data)
        {
            return data[3];
        }

        private string SetFirstName(string[] data)
        {
            return data[2];
        }

        private string[] SetRoles(string[] data)
        {
            string[] roles = data[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return roles;
        }

        private string SetEmail(string[] data)
        {
            return data[0];
        }

        private string SetName(FormsAuthenticationTicket ticket)
        {
            return ticket.Name;
        }

        private Guid SetId(string[] data)
        {
            return new Guid(data[4]);
        }
    }
}
