using Microsoft.AspNetCore.Authorization;

public class OrRequirementHandler : AuthorizationHandler<OrAuthorizationRequirement>
{
    protected override async Task HandleRequirementAsync(
    AuthorizationHandlerContext context,
        IAuthorizationRequirement requirement)
    {
        foreach (var req in requirement.Requirements)
        {
            bool isMet = false;
            if (req is PermissionRequirement permissionReq)
            {
                isMet = context.User.HasClaim("Permission", permissionReq.PermissionName);
            }
            else if (req is ClientRequirement clientReq)
            {
                isMet = await IsValidClient(context.User, clientReq);
            }

            if (isMet)
            {
                context.Succeed(requirement);
                return;
            }
        }

        context.Fail();
    }
}
