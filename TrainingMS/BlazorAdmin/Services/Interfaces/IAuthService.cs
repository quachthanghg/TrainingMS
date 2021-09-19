using BlazorAdmin.Models;
using IdentityModel.Client;
using System.Threading.Tasks;

namespace BlazorAdmin.Services.Interfaces
{
    public interface IAuthService
    {
        Task<TokenResponse> LoginAsync(LoginRequest loginRequest);
        Task LogoutAsync();
    }
}
