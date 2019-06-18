using OZBAY.Core.CrossCuttingConcerns.Validation.FluentValidation;
using FluentValidation.Mvc;
using MyShop.Northwind.Business.DependencyResolvers.Ninject;
using MyShop.Northwind.Entities.ComplexTypes;
using MyShop.Northwind.MvcWebUI.ModelBinders;
using OZBAY.Core.CrossCuttingConcerns.Security.Web;
using OZBAY.Core.Utilities.Mvc.Infrastructure;
using System;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace MyShop.Northwind.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule(), new AutoMapperModule()));
            FluentValidationModelValidatorProvider.Configure(provider =>
            {
                provider.ValidatorFactory = new NinjectValidationFactory(new ValidationModule());
            });
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());

        }

        public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }

        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                var AuthenticationCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (AuthenticationCookie == null)
                {
                    return;
                }

                var encryptedTicket = AuthenticationCookie.Value;
                if (String.IsNullOrEmpty(encryptedTicket))
                {
                    return;
                }

                var ticket = FormsAuthentication.Decrypt(encryptedTicket);

                var securityUtlities = new SecurityUtilities();
                var identity = securityUtlities.FormsAuthTicketToIdentity(ticket);
                var principal = new GenericPrincipal(identity, identity.Roles);

                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = principal;
            }
            catch (Exception)
            {

            }
            
        }
    }
}

