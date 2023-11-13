using Cms.Web.Data.Entities;
using Cms.Web.Shared.ServiceResult;
using Microsoft.Identity.Client;

namespace Cms.Web.Api.Services.TokenService
{
    public interface ITokenService
    {
        IServiceResult<string> CreateToken(UserEntity user);
    }
}
