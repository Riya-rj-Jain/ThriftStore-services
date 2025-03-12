using Microsoft.AspNetCore.Authorization;

public class ClientRequirement : IAuthorizationRequirement
{
    public string ClientId { get; }

    public ClientRequirement(string clientId)
    {
        ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
    }
}
