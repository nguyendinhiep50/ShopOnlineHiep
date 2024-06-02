using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

public static class HubExtensions
{
    public static void MapHubs(this IEndpointRouteBuilder endpoints)
    {
        //endpoints.MapHub<ChatHub1>("/chatHub1");
        //endpoints.MapHub<ChatHub2>("/chatHub2");
    }
}
