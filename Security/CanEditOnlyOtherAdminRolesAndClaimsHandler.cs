using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FirstSide.Security
{
    public class CanEditOnlyOtherAdminRolesAndClaimsHandler :
    AuthorizationHandler<ManageAdminRolesAndClaimsRequirment>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            ManageAdminRolesAndClaimsRequirment requirement)
        {
            if (context.User.IsInRole("Admin") &&
                context.User.HasClaim(claim =>claim.Type == "Edit Role" && claim.Value == "true"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
