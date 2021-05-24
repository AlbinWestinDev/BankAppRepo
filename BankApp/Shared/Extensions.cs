using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Shared
{
    public static class Extensions
    {
        public static Guid GetIdentityId(this System.Security.Claims.ClaimsPrincipal claimsPrincipal)
        {

            var iDIdentifier = claimsPrincipal.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
            return Guid.Parse(iDIdentifier.Value);
        }
    }
}
