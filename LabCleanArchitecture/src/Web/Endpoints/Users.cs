using LabCleanArchitecture.Infrastructure.Identity;

namespace LabCleanArchitecture.Web.Endpoints;
public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapIdentityApi<ApplicationUser>();
    }
}
