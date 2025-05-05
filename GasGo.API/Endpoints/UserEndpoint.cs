using System.Security.Claims;
using Carter;
using GasGo.Common.Extensions;
using GasGo.Handlers.Interface;
using static GasGo.Handlers.Users.GetUserById;

namespace GasGo.API.Endpoints
{
    public class UserEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/users/me", async (
                ClaimsPrincipal claimsPrincipal,
                IQueryHandler<GetUserByIdQuery, GetUserByIdResponse?> handler) =>
            {
                var externalUserId = GetUserId(claimsPrincipal);
                var query = new GetUserByIdQuery(externalUserId);

                var user = await handler.Handle(query);

                return user is not null
                    ? Results.Ok(user)
                    : Results.NotFound($"User with External ID {externalUserId} not found.");
            }).RequireAuthorization();
        }

        private static string GetUserId(ClaimsPrincipal claimsPrincipal) =>
            claimsPrincipal.GetValidUserId();
    }
}
