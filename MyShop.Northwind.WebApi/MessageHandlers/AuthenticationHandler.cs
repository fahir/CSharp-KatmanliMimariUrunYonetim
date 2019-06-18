using OZBAY.Core.Utilities.Helpers;
using MyShop.Northwind.Business.Abstract;
using MyShop.Northwind.Business.DependencyResolvers.Ninject;
using MyShop.Northwind.Entities.Concrete;
using System;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Collections.Generic;

namespace MyShop.Northwind.WebApi.MessageHandlers
{
    public class AuthenticationHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            IUserService userService2 = InstanceFactory.GetInstace<IUserService>();
            IUserService userService22 = InstanceFactory.GetInstace<IUserService>();

            try
            {

                var token = request.Headers.GetValues("Authorization").FirstOrDefault();
                if (token != null)
                {

                    byte[] data = Convert.FromBase64String(token);
                    string decodedString = Encoding.UTF8.GetString(data);

                    string[] tokenValues = decodedString.Split(':');
                    string password = HashwordHelper.GenerateSHA512String(tokenValues[1]);


                    IUserService userService = InstanceFactory.GetInstace<IUserService>();
                    User user2 = userService.GetByUserNameAndPassword("ratapan", "9C1AC8DDA7DCD059CC8A1E9ED31C83587C8613A2BFAD72AFB17F9A775611604E140FD138F69B30D9804482DCEC40771E6B25DC94C8108BF283B84D446BF01CAA");
                    User user = userService.GetByUserNameAndPassword(tokenValues[0], password);
                    if (user != null)
                    {
                        IPrincipal principal = new GenericPrincipal(new GenericIdentity(tokenValues[0]), userService.GetUserRoles(user).Select(u => u.RoleName).ToArray());
                        Thread.CurrentPrincipal = principal;
                        HttpContext.Current.User = principal;
                    }
                }
            }
            catch
            {
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}