using Microsoft.AspNetCore.Authorization;

public class PermissionRequirement : IAuthorizationRequirement
{
    public List<string> Permissions { get; }

    public PermissionRequirement(params string[] permissions)
    {
        Permissions = permissions?.ToList() ?? new List<string>();
    }
}
