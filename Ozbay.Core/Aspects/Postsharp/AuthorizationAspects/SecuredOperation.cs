using System;
using PostSharp.Aspects;

namespace OZBAY.Core.Aspects.Postsharp.AuthorizationAspects
{
    [Serializable]
    public class SecuredOperation : OnMethodBoundaryAspect
    {
        public string Roles { get; set; }

        public override void OnEntry(MethodExecutionArgs args)
        {
            string[] roles = Roles.Split(',');
            bool isAuthorized = false;
            for (int i = 0; i < roles.Length; i++)
            {
                var user = System.Threading.Thread.CurrentPrincipal;
                if (System.Threading.Thread.CurrentPrincipal.IsInRole(roles[i]))
                {
                    isAuthorized = true;
                }
            }
            if (isAuthorized == false)
            {
                throw new Exception("You are not authorized!");
            }
        }
    }
}
