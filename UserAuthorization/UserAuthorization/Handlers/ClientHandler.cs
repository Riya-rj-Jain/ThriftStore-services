using Microsoft.AspNetCore.Authorization;

public class ClientHandler : AuthorizationHandler<ClientRequirement>
{
    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        ClientRequirement requirement)
    {
        if (await IsValidClient(context.User, requirement))
        {
            context.Succeed(requirement);
        }
    }
}
