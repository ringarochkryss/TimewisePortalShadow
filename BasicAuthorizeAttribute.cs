using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimewisePortalShadow
{
    public class BasicAuthorizeAttribute : AuthorizeAttribute
    {
        public BasicAuthorizeAttribute() 
            {
                Policy = "BasicAuthentication";
            }

    }
}
