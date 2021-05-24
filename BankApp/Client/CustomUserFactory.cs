using System;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;

public class CustomUserFactory
    : AccountClaimsPrincipalFactory<RemoteUserAccount>
{
    public CustomUserFactory(IAccessTokenProviderAccessor accessor)
        : base(accessor)
    {
    }

    public async override ValueTask<ClaimsPrincipal> CreateUserAsync(
        RemoteUserAccount account,
        RemoteAuthenticationUserOptions options)
    {
        var user = await base.CreateUserAsync(account, options);

        if (user.Identity.IsAuthenticated)
        {
            var identity = (ClaimsIdentity)user.Identity;


            if(identity.Claims.Where(x=> x.Type == ClaimTypes.Role && x.Value == "admin").Any())
            {
                var adminClaim = new Claim(ClaimTypes.Role, "admin");
                var claimsIdentity = new ClaimsIdentity();
                claimsIdentity.AddClaim(adminClaim);
                user.AddIdentity(claimsIdentity);
                Console.WriteLine("Användaren" +  user.Identity.Name + " är admin ");
            }

            if (identity.Claims.Where(x => x.Type == ClaimTypes.Role && x.Value == "customer").Any())
            {
                var adminClaim = new Claim(ClaimTypes.Role, "customer");
                var claimsIdentity = new ClaimsIdentity();
                claimsIdentity.AddClaim(adminClaim);
                user.AddIdentity(claimsIdentity);
                Console.WriteLine("Användaren" + user.Identity.Name + " är customer ");
            }

        }

        return user;
    }
}