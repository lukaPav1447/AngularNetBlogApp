using Microsoft.AspNetCore.Identity;

namespace AngularNetBlogApp.API.Repositories.Interface
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
