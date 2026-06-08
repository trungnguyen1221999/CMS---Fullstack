using BlogProject.Core.Models.Auth;

namespace BlogProject.Api.Services
{
    public interface IAuthService
    {
        Task<AuthenticatedResult?> LoginAsync(LoginRequest request);
    }
}
