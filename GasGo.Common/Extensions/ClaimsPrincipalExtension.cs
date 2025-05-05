using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GasGo.Common.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static string GetValidUserId(this ClaimsPrincipal claimsPrincipal) =>
            claimsPrincipal.GetUserId()
            ?? throw new Exception("Invalid User.");

        private static string? GetUserId(this ClaimsPrincipal claimsPrincipal) =>
            claimsPrincipal.GetValueFromClaims(ClaimTypes.NameIdentifier);

        private static string? GetValueFromClaims(this ClaimsPrincipal claimsPrincipal,
            string claimType) =>
            claimsPrincipal.Claims
            .Where(c => c.Type == claimType)
            .Select(c => c.Value)
            .SingleOrDefault();
    }
}
